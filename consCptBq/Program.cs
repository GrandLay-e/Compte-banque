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
            
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
        }
    }
}
