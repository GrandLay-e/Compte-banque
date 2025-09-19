using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCptBq
{
    public class Banque
    {
        private List<Compte> mesComptes;
        //private List<Type> mesTypes;

        public Banque()
        {
            mesComptes = new List<Compte>();
            //mesTypes = new List<Type>();
        }
        //public void AjouterType(string code, string libelle, char sens)
        //{
        //    this.mesTypes.Add(new Type(code, libelle, sens));
        //}
        //public void AjouterType(Type unType)
        //{
        //    this.mesTypes.Add(unType);
        //}

        public List<Compte> MesComptes
        {
            get { return mesComptes; }
            set { mesComptes = value; }
        }

        public void AjouteCompte(Compte c)
        {
            if(!MesComptes.Contains(c))
                MesComptes.Add(c);
        }

        public void AjouteCompte(int numero, string proprietaire, decimal solde, decimal decouverte)
        {
            Compte c = new Compte();
            AjouteCompte(c);
        }

        public Compte RendCompte(int numero)
        {
            foreach (Compte c in MesComptes)
            {
                if (c.Numero == numero)
                {
                    return c;
                }
            }
            return null;
        }
        public override string ToString()
        {
            string infos = "";
            foreach (Compte c in MesComptes)
            {
                infos += c.ToString();
            }
            return infos;
        }
    }
}
