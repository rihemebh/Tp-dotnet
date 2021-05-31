using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2.Repositories
{
    interface IUnitOfWork : IDisposable
    {

        void Complete();
       
    }
}
