using ShowRoomManagement.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomManagement.DataLayer
{
    public class ShowRoomDbContext : DbContext
    {

        public ShowRoomDbContext() : base("Connection")
        {

        }


        public DbSet<Brand> Brands { get; set; }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
