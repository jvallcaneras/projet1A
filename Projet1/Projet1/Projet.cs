using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Projet
    {
        //Attributs de la classe
        private String _nomProjet;
        private int _typeProjet; // 1 - Transdi / 2 - transpromo / 3 - PFE / 4 - Intro prog / 5 - autre (à étoffer)
        private int _dureeSemaine;
        private int _nbIntervenant;
        // private int _nbRole;  // --> Affecter le rôle en fonction du nb d'intervenant ?
        private int _nbLivrable;
        private int _nbMatiere;

        //Constructeurs

        //Propritétés
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
        /*public int get_nbRole()
        {
            return _nbRole;
        }*/
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
        public void setdureeSemaine(int newDureeSemaine)
        {
            _dureeSemaine = newDureeSemaine;
        }
        public void setnbIntervenant(int newNbIntervenant)
        {
            _nbIntervenant = newNbIntervenant;
        }
        /*public void setnbRole(int newNbRole)
        {
            _nbRole = newNbRole;
        }*/
        public void setnbLivrable(int newNbLivrable)
        {
            _nbLivrable = newNbLivrable;
        }
        public void setnbMatiere(int newNbMatiere)
        {
            _nbMatiere = newNbMatiere;
        }

        //Methodes

        public static void CreationProjet()
        {
            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Quel est le nom du projet que vous souhaitez créer ?");
            string nomProjet = Console.ReadLine();
            
            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Quel type de projet souhaitez-vous créer ? \n 1 pour projet transdisciplinaire \n 2 pour projet transpromotion" +
                "\n 3 pour projet de fin d'études \n 4 pour projet d'introduction à la programmation \n 5 pour autre");
            int typeProjet = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien de matières concerne-t-il ?");
            int nbMatiere = Convert.ToInt32(Console.ReadLine());


            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Quelle est la durée du projet ? (en semaines)");
            int nbSemaines = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien y a-t-il d'acteurs ? (etudiants et encadrants)");
            int nbIntervenant = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien de livrables sont attendus ?");
            int nbLivrable = Convert.ToInt32(Console.ReadLine());
            // Continuer les questions en stockant les réponses
            // Créer l'objet projet 
            // Le stocker en XML
        }
    }
}
