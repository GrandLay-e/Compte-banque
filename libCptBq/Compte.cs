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
            if (montant < 0 || montant > (Solde + Math.Abs(DecouvertAutorise)))
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


        /// <summary>
        /// Méthode pour ajouter un mouvement au compte en fonction de son type (débit/crédit)  
        /// </summary>
        /// <param name="m"> Le paramètre Mouvement </param>
        /// <exception cref="InvalidOperationException"> Exception levée dans le cas où le débit est impossible </exception>
        public void AjouterMouvement(Mouvement m)
        {
            decimal tempsSolde = Solde; // stocker le solde actuel avant modification
            if (m.LeType.Sens == '-') // Débit
            {
                if (!this.Debiter(m.Montant)) // Si le débit échoue
                    throw new InvalidOperationException("Débit impossible, solde insuffisant."); // Lever une exception
            }
            else //Si Crédit : Créditer
                this.Crediter(m.Montant);

            // Ajouter le mouvement à la liste seulement si le solde a changé
            if (tempsSolde != Solde)
                MesMouvements.Add(m);
        }


        /// <summary>
        ///  Méthode pour ajouter un mouvement avec les éléments constitutifs d'un mouvement    
        /// </summary>
        /// <param name="montant"> Le montant du mouvement </param>
        /// <param name="dateMvt"> La date du mouvement </param>
        /// <param name="codeType">Le code qui permet d'initialiser un objet Type </param>
        public void AjouterMouvement(decimal montant, DateTime dateMvt, string codeType)
        {
            Mouvement m = new Mouvement(montant, dateMvt, codeType);
            AjouterMouvement(m);
        }


        /// <summary>
        /// Méthode pour ajouter un mouvement avec les éléments constitutifs d'un mouvement
        /// différement de la méthode précédente, on passe un Type en paramètre
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="dateMvt"></param>
        /// <param name="type"></param>
        public void AjouterMouvement(decimal montant, DateTime dateMvt, Type_ type)
        {
            Mouvement m = new Mouvement(montant, dateMvt, type);
            AjouterMouvement(m);
        }

        /// <summary>
        /// Réecriture de la méthode ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string euroSolde = Solde > 1m ? "euros" : "euro";
            string euroDecouvert = DecouvertAutorise < -1m ? "euros" : "euro";

            StringBuilder infosCompte =  new StringBuilder();
            infosCompte.AppendLine($"numero: {Numero} nom: {Nom} solde: {Solde} {euroSolde} decouvert autorisé: {DecouvertAutorise} {euroDecouvert}");
            foreach(Mouvement m in MesMouvements)
            {
                infosCompte.AppendLine(m.ToString());
            }
            return infosCompte.ToString();
        }
    }
}
