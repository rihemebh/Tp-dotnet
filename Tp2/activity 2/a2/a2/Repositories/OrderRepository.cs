using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a2.Models;

namespace a2.Repositories
{
    class OrderRepository : Repository<Order>
    {

        public OrderRepository(ShoppingContext context) : base(context) { }
    
    }
}
