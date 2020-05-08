﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Projet
    {
        //Attributs de la classe
        private String _nomProjet;
        private int _dureeSemaine;
        private int _nbIntervenant;
        private int _nbRole;  //A VOIR
        private int _nbLivrable;
        private int _nbMatiere;

        //Constructeurs

        //GetSet
        public String get_nomProjet()
        {
            return _nomProjet;
        }
        public int get_dureeSemaine()
        {
            return _dureeSemaine;
        }
        public int get_nbIntervenant()
        {
            return _nbIntervenant;
        }
        public int get_nbRole()
        {
            return _nbRole;
        }
        public int get_nbLivrable()
        {
            return _nbLivrable;
        }
        public int get_nbMatiere()
        {
            return _nbMatiere;
        }

        public void setnomProjet(string newNomProjet)
        {
            _nomProjet = newNomProjet;
        }
    }
}
