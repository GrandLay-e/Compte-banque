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

            Compte c1 = new Compte(12345, "toto", 10000, -500);
            Compte c2 = new Compte(45657, "titi", 2000, -1000);

            Console.WriteLine(c1);
            c1.AjouterMouvement(600, DateTime.Now, "pre");
            c1.AjouterMouvement(300, DateTime.Now, "dab");
            c1.AjouterMouvement(2000, DateTime.Now, "ret");
            c1.AjouterMouvement(-4200, DateTime.Now, "vir");
            Console.WriteLine(c1);
        }
    }
}
