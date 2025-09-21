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
        private List<Mouvement> mesMouvements;

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

        public List<Mouvement> MesMouvements
        {
            get { return mesMouvements; }
            set { mesMouvements = value; }
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
            MesMouvements = new List<Mouvement>();
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
            MesMouvements = new List<Mouvement>();
        }

        /// <summary>
        /// Crédite le compte du montant spécifié
        /// </summary>
        /// <param name="montant">Le montant à créditer</param>
        public void Crediter(decimal montant)
        {
            if(montant > 0)
                Solde += montant;
        }

        /// <summary>
        /// Débite le compte du montant spécifié si le solde le permet
        /// </summary>
        /// <param name="montant">Le montant à débiter</param>
        /// <returns>True si le débit a été effectué, False sinon</returns>
        public bool Debiter(decimal montant)
        {
            if (montant < 0 || montant == 0 || montant > (Solde + Math.Abs(DecouvertAutorise)))
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
            this.Debiter(n);
            c.Crediter(n);
            return true;
        }

        /// <summary>
        /// Savoir si le solde est supérieur à celui d'un autre compte
        /// </summary>
        /// <param name="compteDestination"></param>
        /// <returns></returns>
        public bool Superieur(Compte c)
        {
            return this.solde > c.solde;
        }

        public void AjouterMouvement(Mouvement m)
        {
            MesMouvements.Add(m);
        }

        public void AjouterMouvement(decimal montant, DateTime dateMvt, string codeType)
        {
            Mouvement m = new Mouvement(montant, dateMvt, codeType);
            decimal tempsSolde = Solde;
            if (m.LeType.Sens == '-')
            {
                if (!this.Debiter(montant))
                    throw new InvalidOperationException("Débit impossible, solde insuffisant.");
            }
            else
                this.Crediter(montant);

            if (tempsSolde != Solde)
                AjouterMouvement(m);
        }

        /// <summary>
        /// Réecriture de la méthode ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder infosCompte =  new StringBuilder();
            infosCompte.AppendLine($"numero: {Numero} nom: {Nom} solde: {Solde} decouvert autorisé: {DecouvertAutorise}");
            foreach(Mouvement m in MesMouvements)
            {
                infosCompte.AppendLine(m.ToString());
            }
            return infosCompte.ToString();
        }
    }
}
