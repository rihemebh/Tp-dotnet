using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2.Repositories
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly ShoppingContext _context;
        private CategoryRepository categoryRepository;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        private bool _disposed = false;

        public UnitOfWork(ShoppingContext context)
        {
            this._context = context;
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(_context);
                }
              
                return this.categoryRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(_context);
                }
                
                return this.productRepository;

            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(_context);
                }
                return this.orderRepository;
            }
        }


   


        public void Complete()
        {
            _context.SaveChanges();
        }

     
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }



    }


}
