using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Data.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        public RestaurantRepository() : base() { }

        public RestaurantRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
