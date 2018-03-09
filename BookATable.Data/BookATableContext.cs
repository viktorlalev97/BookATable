using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Data
{
    public class BookATableContext : DbContext
    {
        public BookATableContext() : base("BookATableDB") { }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
