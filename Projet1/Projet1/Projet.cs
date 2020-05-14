using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    public class Projet
    {
        //Attributs de la classe
        private string _nomProjet;
        private int _typeProjet; // 1 - Transdi / 2 - transpromo / 3 - PFE / 4 - Intro prog / 5 - autre (à étoffer)
        private int _dureeSemaine;
        private int _nbIntervenant;
        private int _nbRole;  // --> Affecter le rôle en fonction du nb d'intervenant ?
        private int _nbLivrable;
        private int _nbMatiere;
        private List<Matiere> _matieres;        
        private List<string> _livrables;
        private List<string> _intervenants;

        //Constructeurs
        public Projet(string nomProjet, int typeProjet, int dureeSemaine, int nbIntervenant, int nbLivrables, int nbMatiere, List<string> livrables, List<Matiere> ListeMatières, List<string> intervenants)

        {
            this.NomProjet = nomProjet;
            this.TypeProjet = typeProjet;
            this.DureeSemaine = dureeSemaine;
            this.NbIntervenant = nbIntervenant;
            this.NbLivrable = nbLivrables;
            this.NbMatiere = nbMatiere;
            this.Livrables = livrables;
            this.Matieres = ListeMatières;
            this.Intervenants = intervenants;
        }

        public Projet() { }


        //Propritétés

        public int TypeProjet { get => _typeProjet; set => _typeProjet = value; }
        public string NomProjet { get => _nomProjet; set => _nomProjet = value; }
        public int DureeSemaine { get => _dureeSemaine; set => _dureeSemaine = value; }
        public int NbIntervenant { get => _nbIntervenant; set => _nbIntervenant = value; }
        public int NbRole { get => _nbRole; set => _nbRole = value; }
        public int NbLivrable { get => _nbLivrable; set => _nbLivrable = value; }
        public int NbMatiere { get => _nbMatiere; set => _nbMatiere = value; }
        public List<string> Livrables { get => _livrables; set => _livrables = value; }
        public List<string> Intervenants { get => _intervenants; set => _intervenants = value; }
        public List<Matiere> Matieres { get => _matieres; set => _matieres = value; }


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
            Console.WriteLine("Quelle est la durée du projet ? (en semaines)");
            int nbSemaines = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien y a-t-il d'acteurs ? (etudiants et encadrants)");
            int nbIntervenant = Convert.ToInt32(Console.ReadLine());
            List<Matiere> listeMatieres = new List<Matiere>();


            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien de matières concerne-t-il ?");
            int nbMatiere = Convert.ToInt32(Console.ReadLine());
            Matiere.CreationMatiere(nbMatiere);

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien de livrables sont attendus ?");
            int nbLivrables = Convert.ToInt32(Console.ReadLine());
            Livrable.CreationLivrable(nbLivrables);



           //Projet projet = new Projet(nomProjet, typeProjet, nbSemaines, nbIntervenant, nbLivrables, nbMatiere, listeLivrables, listeMatieres, listeIntervenants);

            // Le stocker en XML

            /*XmlSerializer xs = new XmlSerializer(typeof(Projet));
            using (StreamWriter wr = new StreamWriter("projet.xml"))
            {
                xs.Serialize(wr, projet);
            }
            // Gérer les dossiers et comment on stock le tout*/
        }

    }
}
