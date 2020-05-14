using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{

    //Est-elle nécessaire ?
    class Promotion
    {
        //Attributs de la classe
        private int _annee;

        //Accesseurs
        public int Annee { get => _annee; set => _annee = value; }

        //Constructeur
        public Promotion(int annee)
        {
            _annee = annee;
        }

        public static void CreationPromo()
        {

        }
}
