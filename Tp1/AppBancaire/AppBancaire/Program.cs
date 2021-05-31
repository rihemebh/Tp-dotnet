using System;

namespace AppBancaire
{
    class Program
    {
        static void Main(string[] args)
        {
           

            CompteCourant cr = new CompteCourant(0.0, "david", 1000);
      
            CompteCourant cr1= new CompteCourant(0.0, "omar", 20000);
          
            CompteEpargne ce = new CompteEpargne( 5000, "salim",(decimal) 0.12);
        
            CompteEpargne ce1 = new CompteEpargne(5000, "Mourad", (decimal)0.02);
        

            cr.Crediter(50);
            cr.Crediter(150);
            cr.Debiter(70);
            Console.WriteLine("******************************************");
            cr.Afficher();


            cr1.Crediter(150);
            cr1.Crediter(20);
            cr1.Debiter(700);
            Console.WriteLine("******************************************");
            cr1.Afficher();



            ce.Crediter(60);
            ce.Crediter(80);
            ce.Debiter(25);
            Console.WriteLine("******************************************");
            ce.Afficher();


            ce1.Crediter(5);
            ce1.Crediter(58);
            ce1.Debiter(87);
            Console.WriteLine("******************************************");
            ce1.Afficher();


        }
    }
}
