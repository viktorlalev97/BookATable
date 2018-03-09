using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Data.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>
    {
        public ReservationRepository() : base() { }

        public ReservationRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
