using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Eleve : Intervenant
    {
        //Attributs
        private int _anneeEntree;

        //Acsesseurs
        public int AnneeEntree { get => _anneeEntree; set => _anneeEntree = value; }

        public Eleve (int anneeEntree)
        {
            this.AnneeEntree = anneeEntree;
        }
    }
}
