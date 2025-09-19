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

            Compte c1 = new Compte(12345, "toto", 1000, -500);
            Compte c2 = new Compte(45657, "titi", 2000, -1000);
            c1.Transferer(3300, c2);

            if (c1.Superieur(c2))
            { Console.WriteLine("supérieur"); }
            else
            {
                Console.WriteLine("inférieur");
                Console.WriteLine(c2.ToString());
            }

            c1.Crediter(2000);
            c1.Debiter(5300);

            Banque b = new Banque();
            b.AjouteCompte(c1);
            b.AjouteCompte(c2);
            b.AjouteCompte(1245, "dutronc", 4500, -500);

            //Console.WriteLine(b.compteMax().ToString());

        }
    }
}
