using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    public class Matiere
    {
        //Attributs de la classe
        private string _nomMatiere;
        private int _ref;

        public string NomMatiere { get => _nomMatiere; set => _nomMatiere = value; }
        public int Ref { get => _ref; set => _ref = value; }
        //private string _codeUE;

        public Matiere (string nomMatiere, int reference)
        {
            this.NomMatiere = nomMatiere;
            this.Ref = reference;
        }

        public Matiere() { }
    }
}
