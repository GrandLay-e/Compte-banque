using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libCptBq
{
    /// <summary>
    /// Classe Compte
    /// </summary>
    public class Compte
    {
        private int numero;
        private string nom;
        private decimal solde;
        private decimal decouvertAutorise; // valeur négative

        /// <summary>
        /// Propriétés implémentées automatiquement
        /// </summary>
        public int Numero
        {
            get{return numero;}
            set{numero = value;}
        }
        public string Nom
        {
            get{return nom;}
            set{nom = value;}
        }
        public decimal Solde
        {
            get{return solde;}
            set{solde = value;}
        }
        public decimal DecouvertAutorise
        {
            get{return decouvertAutorise;}
            set{decouvertAutorise = value;}
        }


        /// <summary>
        /// Constructeur à 4 arguments
        /// </summary>
        /// <param name="numero">le numéro</param>
        /// <param name="nom">le nom</param>
        /// <param name="solde">le solde</param>
        /// <param name="decouvertAutorise">le découvert autorisé</param>
        public Compte(int numero, string nom, decimal solde, decimal decouvertAutorise)
        {
            Numero = numero;
            Nom = nom;
            Solde = solde;
            DecouvertAutorise = decouvertAutorise;
        }
        /// <summary>
        /// Constructeur de compte par défaut
        /// </summary>
        public Compte()
        {
            this.Numero = 0;
            this.Nom = "";
            this.Solde = 0;
            this.DecouvertAutorise = 0;
        }
        /// <summary>
        /// Réecriture de la méthode ToString
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Crédite le compte du montant spécifié
        /// </summary>
        /// <param name="montant">Le montant à créditer</param>
        public void Crediter(decimal montant)
        {
            if (montant < 1m || montant == 0)
            {
                return;
            }
            Solde += montant;
        }

        /// <summary>
        /// Débite le compte du montant spécifié si le solde le permet
        /// </summary>
        /// <param name="montant">Le montant à débiter</param>
        /// <returns>True si le débit a été effectué, False sinon</returns>
        public bool Debiter(decimal montant)
        {
            if (montant < 0 || montant == 0 || montant > Solde)
            {
                return false;
            }
            Solde -= montant;
            return true;
        }


        /// <summary>
        /// Transférer un montant vers un autre compte
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="compteDestination"></param>
        /// <returns></returns>
        public bool Transferer(decimal n, Compte c)
        {
            if(n < 1 || n > Solde)
            {
                return false;
            }
            else
            {
                this.Debiter(n);
                c.Crediter(n);
            } 
            return true;
        }


        /// <summary>
        /// Savoir si le solde est supérieur à celui d'un autre compte
        /// </summary>
        /// <param name="compteDestination"></param>
        /// <returns></returns>
        public bool Superieur(Compte c)
        {
            if(this.solde > c.solde)
                return true;
            return false;
        }
        public override string ToString()
        {
            return $"numero: {Numero} nom: {Nom} solde: {Solde} decouvert autorisé: {DecouvertAutorise}\n";
        }
    }
}
