using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancaire
{
    class Compte
    {
        protected decimal  solde;
        public virtual decimal Solde { get => solde; set => solde = value; }
        public string Prop { set; get; }
        public  List<operationBancaire> operations;
       
        public Compte() : this("",0)
        {

        }
        public Compte(string prop, decimal solde)
        {
            this.Solde = solde;
            this.Prop = prop;
            operations = new List<operationBancaire>();

        }
        public  void Addoperation(decimal montant, string type)
        {
            operations.Add(new operationBancaire(montant, type));
        }
        public virtual void Crediter(decimal Somme)
        {
            Addoperation(Somme, "Crediter");
            Solde +=Somme;

        }
        public virtual void Crediter(decimal Somme, Compte Cpt)
        {
         
            Cpt.Crediter(Somme);
        }

        public virtual void Debiter(decimal Somme)
        {
            Addoperation(Somme, "Debiter");
            Solde -=Somme;
        }
        public virtual void Debiter(decimal Somme, Compte Cpt)
        {
            Cpt.Debiter(Somme);
        }
         public virtual void Afficher()
        {
            Console.WriteLine("le compte de " + this.Prop + " \n contient une somme de " + this.Solde.ToString() + " Dt \n");
            foreach (var op in operations)
            {
                Console.WriteLine(op.type + " : " + op.montant);
            }
        } 

    }
    class operationBancaire
    {

        public decimal montant { get; set; }
        public string type;

        public operationBancaire(decimal montant, string type)
        {
            this.montant = montant;
            this.type = type;
        }
        public operationBancaire()
        {
           
        }
       
    }
    class CompteCourant : Compte
    {
        private readonly double decouvert;

      
    public CompteCourant(double decouvert) : base()
        {
            this.decouvert = decouvert;
        }
        public CompteCourant(double decouvert, string prop, decimal solde) : base(prop, solde)
        {
            this.decouvert = decouvert;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("decouvert : " + decouvert);


        }

    }
    class CompteEpargne : Compte
    {
        public decimal TauxAbond{ get; set; }

     public  override decimal Solde { get { return base.solde + base.solde * TauxAbond; } set { base.solde = value; } }

    public CompteEpargne(decimal solde, string proprietaire, decimal tauxAbond) : base(proprietaire, solde)
    {
        TauxAbond = tauxAbond;
    }
    public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("taux  : " + TauxAbond);


        }

    }
}
