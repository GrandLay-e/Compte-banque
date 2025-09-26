using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCptBq
{
    public class Type_
    {
        /// <summary>
        /// Attributs qui permet de valider le code, le libellé et le sens. 
        /// Le code est la clé, le libellé et le sens sont les valeurs.
        /// Si le code n'existe pas dans le dictionnaire, une exception est levée.
        /// Si le code existe mais que le libellé ou le sens ne correspondent pas, une exception est également levée.
        /// </summary>
        private static Dictionary<string, (string libelle, char sens)> valideCodeLibelleEtSens
            = new Dictionary<string, (string libelle, char sens)>
            {
                { "pre", ("Prélèvement", '-') },
                { "ch" , ("Chèque débité", '-') },
                { "dch", ("Chèque déposé", '+') },
                { "des", ("Dépôt d'espèce", '+') },
                { "vir", ("Virement", '+') },
                { "dab", ("Retrait distributeur", '-') },
                { "ret", ("Retrait en guichet", '-') }
            };

        /// <summary>
        /// Les attributs de la classe TypeMouvement
        /// </summary>
        private string code;
        private string libelle;
        private char sens; // '-' pour débit, '+' pour crédit


        /// <summary>
        /// Propriétés de la classe pour accéder aux attributs privés
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }
        public char Sens
        {
            get { return sens; }
            set { sens = value; }
        }

        /// <summary>
        /// Le constructeur par défaut initialise les attributs à des valeurs par défaut
        /// </summary>
        public Type_()
        {
            Code = "";
            Libelle = "";
            Sens = ' ';
        }

        /// <summary>
        /// Le constructeur surchargé initialise les attributs avec les valeurs passées en paramètres
        /// Il vérifie que le code, le libellé et le sens sont valides en utilisant le dictionnaire valideCodeLibelleEtSens.
        /// Si les valeurs ne sont pas valides, une exception ArgumentException est levée.
        /// sinon, les attributs sont initialisés avec les valeurs passées en paramètres.
        /// </summary>
        /// <param name="code"> Le code du Type de Mouvement </param>
        /// <param name="libelle"> Le libellé du Type de Mouvement </param>
        /// <param name="sens"> Le sens du Type de Mouvement </param>
        /// <exception cref="ArgumentException"> L'exception est levée si les valeurs ne sont pas valides. </exception>
        public Type_(string code, string libelle, char sens)
        {
            if (!valideCodeLibelleEtSens.ContainsKey(code) || 
                valideCodeLibelleEtSens[code].libelle != libelle || 
                valideCodeLibelleEtSens[code].sens != sens){

                throw new ArgumentException($"Le libellé, '{libelle}' le sens '{sens}', et/ou le code '{code}' ne correspondent pas !");
            }
            this.Code = code;
            this.Libelle = libelle;
            this.Sens = sens;
        }

        /// <summary>
        /// Le constructeur qui initialise les attributs avec le code passé en paramètre.
        /// Si le code n'existe pas dans le dictionnaire valideCodeLibelleEtSens, une exception ArgumentException est levée.
        /// Sinon, les attributs sont initialisés avec les valeurs correspondantes dans le dictionnaire.
        /// </summary>
        /// <param name="code"> Le code du Type de Mouvement </param>
        /// <exception cref="ArgumentException"> L'exception est levée si le code est inconnu. </exception>
        public Type_(string code)
        {
            if (!valideCodeLibelleEtSens.ContainsKey(code))
            {
                throw new ArgumentException($"Le code '{code}' n'est pas valide.");
            }
            this.Code = code;
            this.Libelle = valideCodeLibelleEtSens[code].libelle;
            this.Sens = valideCodeLibelleEtSens[code].sens;
        }

        /// <summary>
        /// Méthode qui retourne le code du type de mouvement
        /// </summary>
        /// <returns> Code du type </returns>
        public string GetCode() => Code;

        /// <summary>
        /// Méthode qui retourne le type de mouvement sous forme de chaine formatée
        /// Si les attributs ne sont pas initialisés ou sont vides, retourne null
        /// </summary>
        /// <returns> Null | Chaîne formatée du type de mouvement </returns>
        public override string ToString()
            //vérifie que les attributs ne sont pas vides ou non initialisés
            => Code == "" || Libelle == "" || Sens == ' ' ? null : //si c'est le cas, retourne null
            $"{Code} - {Libelle} ({Sens})"; //sinon, retourne la chaîne formatée
    }
}
