using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libCptBq;

namespace consCptBq
{
    class Program
    {
        static void Main(string[] args)
        {

            Compte c2 = new Compte(45657, "titi", 2000, -1000);
            Banque b = new Banque();
            b.AjouteCompte(c2);
            Compte c1 = new Compte
            {
                Numero = 123456,
                Nom = "toto",
                Solde = 1000.50m,
                DecouvertAutorise = -500.00m
            };
            b.AjouteCompte(c1);
            Console.WriteLine(b);
            try
            {
                c1.AjouterMouvement(600, DateTime.Now, "pre");
                c1.AjouterMouvement(300, DateTime.Now, "dab");
                c1.AjouterMouvement(2000, DateTime.Now, "ret");
                c1.AjouterMouvement(-4200, DateTime.Now, "vir");
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(b);

        }
    }
}
