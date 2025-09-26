using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace libCptBq
{
    /// <summary>
    /// Classe Mouvement qui définit le mouvement d'un compte bancaire
    /// </summary>
    public class Mouvement
    {
        /// <summary>
        /// Les attributs de la classe Mouvement (date, montant, type)
        /// </summary>
        private DateTime dateMvt;
        private decimal montant;
        private Type_ leType;

        /// <summary>
        /// Les propriétés de la classe pour accéder aux attributs privés
        /// </summary>
        public DateTime DateMvt
        {
            get { return dateMvt; }
            set { dateMvt = value; }
        }
        public decimal Montant
        {
            get { return montant; }
            set { montant = value; }
        }
        public Type_ LeType
        {
            get { return leType; }
            set { leType = value; }
        }

        /// <summary>
        /// Le constructeur par défaut initialise la date au jour courant, 
        /// le montant à 0 et le type à un type par défaut
        /// </summary>
        public Mouvement()
        {
            DateMvt = DateTime.Now;
            Montant = 0m;
            LeType = new Type_();
        }

        /// <summary>
        /// Le constructeur surchargé initialise les attributs avec les valeurs passées en paramètres
        /// Il vérifie que le type n'est pas null, sinon une exception ArgumentException est levée
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="dateMvt"></param>
        /// <param name="leType"></param>
        /// <exception cref="ArgumentException"></exception>
        public Mouvement(decimal montant, DateTime dateMvt, Type_ leType)
        {
            if(leType.ToString() == null)
            {
                throw new ArgumentException("Le type n'est pas valable");
            }
            DateMvt = dateMvt;
            Montant = montant;
            LeType = leType;
        }


        /// <summary>
        /// Le constructeur surchargé initialise les attributs avec les valeurs passées en paramètres
        /// à la place du type, on passe le code qui permet d'initialiser un objet Type
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="dateMvt"></param>
        /// <param name="codeType"></param>
        public Mouvement(decimal montant, DateTime dateMvt, string codeType)
        {
            DateMvt = dateMvt;
            Montant = montant;
            LeType = new Type_(codeType);
        }

        /// <summary>
        /// La méthode ToString réécrite pour afficher les informations du mouvement
        /// </summary>
        /// <returns> 00/00/0000 - Libellé de 0000 euros</returns>
        public override string ToString()
        {
            string euro = Montant > 1m || Montant < -1m ? "euros" : "euro";
            return $"{DateMvt.ToShortDateString()} - {LeType.Libelle} de {Montant} {euro}";
        }
    }
}
