using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class PersonneDBContext : DbContext
    {
        public PersonneDBContext() : base("name=pers")
        { }
        public DbSet<Personne> personnes { get; set; }
       
    }
}
