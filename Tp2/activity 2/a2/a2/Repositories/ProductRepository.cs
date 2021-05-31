using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a2.Models;


namespace a2.Repositories
{
    class ProductRepository : Repository<Product>
    {

        public ProductRepository(ShoppingContext context) : base(context) { }
        
    }
}
