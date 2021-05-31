using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a2.Repositories;
using a2.Models;
namespace a2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ShoppingContext();
            var unitOfWork = new UnitOfWork(dbContext);

      /*      unitOfWork.OrderRepository.Remove(2);
            unitOfWork.Complete();
            unitOfWork.CategoryRepository.Remove(3);
            unitOfWork.Complete();
            unitOfWork.CategoryRepository.Remove(4);
            unitOfWork.Complete();
            unitOfWork.ProductRepository.Remove(1009);
            unitOfWork.Complete();
            unitOfWork.ProductRepository.Remove(1010);
            unitOfWork.Complete();
      */
            Console.WriteLine(" Inserting data .. \n");
                  //1. Add a category
                  //1.1 category 1
                  Category c = new Category();
                  c.Name = "c1";
                 
                  //Console.WriteLine( c.Name );
                  unitOfWork.CategoryRepository.Add(c);
                  unitOfWork.Complete();

                  // Console.WriteLine(unitOfWork.CategoryRepository.GetByID(c.IdOrder).Name);

                  //1.2 Category 2

                    Category c1 = new Category();
                    c1.Name = "c2";
                    unitOfWork.CategoryRepository.Add(c1);
                     unitOfWork.Complete();


                    // 2. Add an Order 
                    Order order = new Order();
                    unitOfWork.OrderRepository.Add(order);
                     unitOfWork.Complete();
            
            //3. Add a product
            //3.1 product 1


                  Product p = new Product();
                  p.Category = c1;
                  p.Order = order;
                  p.Name = "produit1";
                  unitOfWork.ProductRepository.Add(p);
                  unitOfWork.Complete();
            //3.2 product 2

               Product p1 = new Product();
               p1.Category = c;
              p1.Order = order;
               p1.Name = "produit2";
               unitOfWork.ProductRepository.Add(p1);
               unitOfWork.Complete();
           

            // 4. Get All data after insert

               Console.WriteLine(" ******************* Get All Product ******************* \n");

                 var products = unitOfWork.ProductRepository.GetAll();

                 foreach (var pr in products)
                 {
                   if(pr.Category
                    != null)
                     Console.WriteLine(
                         "Id : " + pr.IdOrder + "\n Name : " + pr.Name + "\n Category : " + pr.Category.Name + "\n"
                         );
                else Console.WriteLine(
                     "Id : " + pr.IdOrder + "\n Name : " + pr.Name + "\n Category : null"  + "\n"
                     );
            }


                 Console.WriteLine(" ******************* Updating A Product ******************* \n");

                 var product = unitOfWork.ProductRepository.GetByID(p.IdOrder);
                 product.Name = "produit3";
                 unitOfWork.ProductRepository.Update(product
                     );
                 unitOfWork.Complete();


                 Console.WriteLine(" ******************* Get All Product after Update ******************* \n");

                  products = unitOfWork.ProductRepository.GetAll();

                 foreach(var pr in products)
                 {
                if (pr.Category
          != null)
                    Console.WriteLine(
                        "Id : " + pr.IdOrder + "\n Name : " + pr.Name + "\n Category : " + pr.Category.Name + "\n"
                        );
                else Console.WriteLine(
                     "Id : " + pr.IdOrder + "\n Name : " + pr.Name + "\n Category : null" + "\n"
                     );
            }

                 Console.WriteLine(" ******************* Remove Product ******************* \n");


                 unitOfWork.ProductRepository.Remove(p1.IdOrder
                     );
                 unitOfWork.Complete();



                 Console.WriteLine(" ******************* Get All Product after Remove ******************* \n");

                 products = unitOfWork.ProductRepository.GetAll();

                 foreach (var pr in products)
                 {
                if (pr.Category
         != null)
                    Console.WriteLine(
                        "Id : " + pr.IdOrder + "\n Name : " + pr.Name + "\n Category : " + pr.Category.Name + "\n"
                        );
                else Console.WriteLine(
                     "Id : " + pr.IdOrder + "\n Name : " + pr.Name + "\n Category : null" + "\n"
                     );
            }
            
            Console.Read();
            
        }
    }
}
