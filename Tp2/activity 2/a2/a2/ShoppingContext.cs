using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using a2.Models;

namespace a2
{
    class ShoppingContext : DbContext
    {

        public ShoppingContext() : base("name=Shopping")
        { }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
