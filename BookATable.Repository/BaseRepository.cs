using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookATable.Data.Repositories
{
    public class BaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;
        protected UnitOfWork unitOfWork;

        public BaseRepository()
        {
            this.context = new BookATableContext();
            this.dbSet = context.Set<T>();
        }

        public BaseRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.context = this.unitOfWork.Context;
            this.dbSet = this.context.Set<T>();
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

 
        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T,bool>>filter)
        {

            return dbSet.Where(filter).ToList();
        }

        public void Insert(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            dbSet.Remove(GetByID(id));
            context.SaveChanges();
        }

        public void Save(T item)
        {
            if (item.ID > 0)
                Update(item);
            else
                Insert(item);

            context.SaveChanges();
        }
    }
}
