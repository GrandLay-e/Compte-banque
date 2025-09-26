using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using libCptBq;

namespace consCptBq
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque b = new Banque();
            b.AjouteCompte(new Compte(45657, "titi", 2000, -1000));
            Compte c;

            Type_ t = new Type_("vir");
            Type_ t_ = new Type_("ret");
            c = b.RendCompte(45657);
            c.AjouterMouvement(200, new DateTime(2017, 09, 11), "vir");
            c.AjouterMouvement(100, new DateTime(2017, 09, 12), "ret");
            c.AjouterMouvement(500, new DateTime(2017, 09, 13), "vir");
            Console.WriteLine(c);

        }
    }
}
