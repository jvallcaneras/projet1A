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
        public static void CreationLivrable(int nbLivrable) 
        {
          for(int i=0; i <= nbLivrable; i++ )
          Console.WriteLine("Choisissez un type pour le livrable numero " + i );
            int caseSwitch = int.Parse(Console.ReadLine());
            switch (caseSwitch)
            {
                case 1:
                   string _type = "Rapport";
                    break;
                case 2:
                    string _type = "Soutenance";
                    break;
                
                case 3:
                    string _type = Console.ReadLine();



            }


    }
}
