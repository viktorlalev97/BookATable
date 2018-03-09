using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : base() { }

        public UserRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
