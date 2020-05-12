using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Projet
    {
        //Attributs de la classe
        private string _nomProjet;
        private int _typeProjet; // 1 - Transdi / 2 - transpromo / 3 - PFE / 4 - Intro prog / 5 - autre (à étoffer)
        private int _dureeSemaine;
        private int _nbIntervenant;
        // private int _nbRole;  // --> Affecter le rôle en fonction du nb d'intervenant ?
        private int _nbLivrable;
        private int _nbMatiere;
        private List<string> _matieres;
        private List<string> _livrables;

       

<<<<<<< HEAD
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
=======
        //Constructeurs
        public Projet(string nomProjet, int typeProjet, int dureeSemaine, int nbIntervenant, int nbLivrables, int nbMatiere, List<string> livrables, List<string> matières)
>>>>>>> 32d945d010b12f5e6363fefbacc0f760e469fbf6
        {
            this.NomProjet = nomProjet;
            this.TypeProjet = typeProjet;
            this.DureeSemaine = dureeSemaine;
            this.NbIntervenant = nbIntervenant;
            this.NbLivrable = nbLivrables;
            this.NbMatiere = nbMatiere;
            this.Livrables = livrables;
            this.Matieres = Matieres;
        }

<<<<<<< HEAD
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
=======
        //Propritétés

        public int TypeProjet { get => _typeProjet; set => _typeProjet = value; }
        public string NomProjet { get => _nomProjet; set => _nomProjet = value; }
        public int DureeSemaine { get => _dureeSemaine; set => _dureeSemaine = value; }
        public int NbIntervenant { get => _nbIntervenant; set => _nbIntervenant = value; }
        public int NbRole { get => _nbRole; set => _nbRole = value; }
        public int NbLivrable { get => _nbLivrable; set => _nbLivrable = value; }
        public int NbMatiere { get => _nbMatiere; set => _nbMatiere = value; }
        public List<string> Matieres { get => _matieres; set => _matieres = value; }
        public List<string> Livrables { get => _livrables; set => _livrables = value; }


>>>>>>> 32d945d010b12f5e6363fefbacc0f760e469fbf6

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
