using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace a1
{
    class Program
    {
        static void Main(string[] args)
        {//Question 1 

    
            Ado ado = new Ado(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = student; Integrated Security = True; Connect Timeout = 30; 
                              Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            Console.WriteLine("Connected mode\n");
            ado.connectedMode();
            
           Console.WriteLine("\n \nDeconnected mode");
           ado.diconnectedMode();



            Console.Read();




        }

       
    }
}
