using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCptBq
{
    public class Mouvement
    {
        private DateTime dateMvt;
        private decimal montant;
        private TypeMouvement leType;

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
        public TypeMouvement LeType
        {
            get { return leType; }
            set { leType = value; }
        }   

        public Mouvement()
        {
            DateMvt = DateTime.Now;
            Montant = 0m;
            LeType = new TypeMouvement();
        }
        public Mouvement(decimal montant, DateTime dateMvt, TypeMouvement leType)
        {
            DateMvt = dateMvt;
            Montant = montant;
            LeType = leType;
        }

        public Mouvement(decimal montant, DateTime dateMvt, string codeType)
        {
            DateMvt = dateMvt;
            Montant = montant;
            LeType = new TypeMouvement(codeType);
        }

        public override string ToString()
        {
            return $"{DateMvt.ToShortDateString()} - {LeType.Libelle} de {Montant}";
        }
    }
}
