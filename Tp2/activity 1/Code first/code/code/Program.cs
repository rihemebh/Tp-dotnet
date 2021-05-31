using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PersonneDBContext context = new PersonneDBContext())
            {

                // 1. Ajout 
                Console.WriteLine(" *********** AJOUTER  ***********");
                  Personne s = new Personne();
            
                  s.name = "riheme";
                  s.phone = "93686935";
                  context.personnes.Add(s);
                  context.SaveChanges();

                var pers = context.personnes;

                foreach (var p1 in pers)
                {
                    Console.WriteLine("id : " + p1.Id + ", nom : " + p1.name + " , numero :" + p1.phone);
                 

                }
                //3. Search 

                Console.WriteLine(" *********** FILTER  ***********");
                Personne p =
                context.personnes.FirstOrDefault(st => st.name == "riheme");
                Console.WriteLine("id : " + p.Id + ", nom : " + p.name + " , numero :" + p.phone);
                Console.Read();

                //4. Update
                Console.WriteLine(" *********** MODIFIER  ***********");

                p.name = "riheme ben hassan";
                context.SaveChanges();
                pers = context.personnes;

                foreach (var p1 in pers)
                {
                    Console.WriteLine("id : " + p1.Id + ", nom : " + p1.name + " , numero :" + p1.phone);
                    Console.Read();

                }

                // 2. Suppression

                Console.WriteLine(" *********** SUPPRIMER  ***********");
                context.personnes.Remove(p);
                context.SaveChanges();

                pers = context.personnes;

                foreach (var p1 in pers)
                {
                    Console.WriteLine("id : " + p1.Id + ", nom : " + p1.name + " , numero :" + p1.phone);
                    Console.Read();

                }

                Console.Read();

            }







        }
    }
}

