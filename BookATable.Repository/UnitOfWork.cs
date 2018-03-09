using System;
using System.Data.Entity;

namespace BookATable.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public DbContext Context { get; set; }

        private DbContextTransaction trans = null;

        public UnitOfWork()
        {
            Context = new BookATableContext();
            this.trans = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (this.trans != null)
            {
                this.trans.Commit();
                this.trans = null;
            }
        }

        public void RollBack()
        {
            if (this.trans != null)
            {
                this.trans.Rollback();
                this.trans = null;
            }
        }

        public void Dispose()
        {
            Commit();
            Context.Dispose();
        }
    }
}
