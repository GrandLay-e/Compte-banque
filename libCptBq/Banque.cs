using System.Collections.Generic;
using System.Text;

namespace libCptBq
{
    public class Banque
    {
        /// <summary>
        /// Les attributs de la classe Banque
        /// </summary>
        private List<Compte> mesComptes;
        private List<TypeMouvement> mesTypes;


        /// <summary>
        /// Les propriétés de la classe Banque
        /// </summary>
        public List<Compte> MesComptes
        {
            get { return mesComptes; }
            set { mesComptes = value; }
        }

        public List<TypeMouvement> MesTypes
        {
            get { return mesTypes; }
            set { mesTypes = value; }
        }

        /// <summary>
        /// Le constructeur par défaut de la classe Banque
        /// </summary>
        public Banque()
        {
            mesComptes = new List<Compte>();
            mesTypes = new List<TypeMouvement>();
        }

        /// <summary>
        /// Adds a new type to the collection.
        /// </summary>
        /// <param name="unType">The type to add to the collection. Cannot be <see langword="null"/>.</param>
        public void AjouterType(TypeMouvement unType)
        {
            this.mesTypes.Add(unType);
        }

        /// <summary>
        /// Ajout d'un type dans la liste des types de la banque
        /// </summary>
        /// <param name="code"> Le code du type </param>
        /// <param name="libelle"> Le libellé du type </param>
        /// <param name="sens"> Le sens du type </param>
        public void AjouterType(string code, string libelle, char sens)
        {
            // On crée un nouveau type et on l'ajoute à la liste
            AjouterType(new TypeMouvement(code, libelle, sens));
        }

        /// <summary>
        /// Ajouter un compte dans la liste des comptes de la banque
        /// </summary>
        /// <param name="c"> Le compte à ajouter </param>
        public void AjouteCompte(Compte c)
        {
            if(!MesComptes.Contains(c))
                MesComptes.Add(c);
        }

        /// <summary>
        /// Méthode d'ajout d'un compte dans la liste des comptes de la banque avec les paramètres de compte
        /// </summary>
        /// <param name="numero"> Le numéro du compte </param>
        /// <param name="nom"> Le nom du propriétaire du compte </param>
        /// <param name="solde"> Le solde du compte </param>
        /// <param name="decouverte"> Le découvert autorisé du compte </param>
        public void AjouteCompte(int numero, string nom, decimal solde, decimal decouverte)
        {
            AjouteCompte(new Compte(numero, nom, solde, decouverte));
        }

        /// <summary>
        /// Recupèrer un compte par son numéro
        /// </summary>
        /// <param name="numero"> Le numéro du compte à récupérer </param>
        /// <returns> Le compte correspondant au numéro, ou null s'il n'existe pas </returns>
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

        /// <summary>
        /// Méthode qui retourne le compte avec le solde le plus élevé
        /// </summary>      
        /// <returns> Retourne le compte en question </returns>
        public Compte CompteMax()
        {
            // Si la liste est vide, on retourne null
            if (MesComptes.Count == 0) return null;

            // On initialise le compte max avec le premier compte de la liste
            Compte maxCompte = MesComptes[0];
            foreach (Compte c in MesComptes)
            {
                if (c.Superieur(maxCompte))
                {
                    // On met à jour le compte max si on trouve un compte avec un solde plus élevé que le max actuel
                    maxCompte = c;
                }
            }
            return maxCompte;
        }

        /// <summary>
        /// Méthode ToString de la classe Banque
        /// </summary>
        /// <returns> Les informations sur les comptes de la banque </returns>
        public override string ToString()
        {
            StringBuilder infos = new StringBuilder();
            foreach (Compte c in MesComptes)
            {
                infos.Append(c.ToString());
            }
            return infos.ToString();
        }
    }
}
