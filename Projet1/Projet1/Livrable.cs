using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Livrable
    {
        //Attributs de la classe
        private string _type;
        private String _dateRendu;

        //Constructeur 
        public Livrable(string type, string dateRendu)
        {
            _type = type;
            _dateRendu = dateRendu;

        }

        //Méthodes
        public void CreationLivrable(int nbLivrable)
        {
            for (int i = 0; i <= nbLivrable; i++)
                Console.WriteLine("Choisissez un type pour le livrable numero " + i);
            int caseSwitch = int.Parse(Console.ReadLine());
            switch (caseSwitch)
            {
                case 1:
                    _type = "Rapport";
                    break;
                case 2:
                    _type = "Soutenance";
                    break;

                case 3:
                    _type = Console.ReadLine();
                    break;



            }


        }
    }
}
