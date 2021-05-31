using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancaire
{
    class Compte
    {
        public decimal Solde { get;  }
        public string Prop { set; get; }
        public Compte() : this("",0)
        {

        }
        public Compte(string prop, decimal solde)
        {
            this.Solde = solde;
            this.Prop = prop;

        }
      
        private void Crediter(decimal Somme)
        {

        }
        private void Crediter(decimal Somme,  Compte Cpt)
        {

        }
        private void Debiter(decimal Somme)
        {

        }
        private void Debiter(decimal Somme, Compte Cpt)
        {

        }
         public void Afficher()
        {
            Console.WriteLine("le compte de " + this.Prop + "contient une somme de " + this.Solde.ToString() + " Dt");
        } 

    }

    class CompteEpargne : Compte
    {

    }
    class CompteCourant : Compte
    {
        public 
    }
}
