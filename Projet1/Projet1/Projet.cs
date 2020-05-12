using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    class Projet
    {
        //Attributs de la classe
        private string _nomProjet;
        private int _typeProjet; // 1 - Transdi / 2 - transpromo / 3 - PFE / 4 - Intro prog / 5 - autre (à étoffer)
        private int _dureeSemaine;
        private int _nbIntervenant;
        private int _nbRole;  // --> Affecter le rôle en fonction du nb d'intervenant ?
        private int _nbLivrable;
        private int _nbMatiere;
        private List<string> _matieres;
        private List<string> _livrables;
        private List<string> _intervenants;

        //Constructeurs
        public Projet(string nomProjet, int typeProjet, int dureeSemaine, int nbIntervenant, int nbLivrables, int nbMatiere, List<string> livrables, List<string> matières, List<string> intervenants)

        {
            this.NomProjet = nomProjet;
            this.TypeProjet = typeProjet;
            this.DureeSemaine = dureeSemaine;
            this.NbIntervenant = nbIntervenant;
            this.NbLivrable = nbLivrables;
            this.NbMatiere = nbMatiere;
            this.Livrables = livrables;
            this.Matieres = Matieres;
            this.Intervenants = intervenants;
        }


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
        public List<string> Intervenants { get => _intervenants; set => _intervenants = value; }


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

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            int cpt = 0;
            string intervenant = "";
            List<string> listeIntervenants = new List<string>();
            while(cpt<nbIntervenant && intervenant != "quitter" && intervenant != "Quitter" && intervenant != "QUITTER")
            {
                cpt++;
                Console.WriteLine("Veuillez indiquer le nom d'un acteur (etudiants et encadrants), si ceux-ci ont tous été renseignés, entrez \"quitter\"");
                intervenant = Console.ReadLine();
                if (intervenant != "quitter" && intervenant != "QUITTER" && intervenant != "Quitter")
                    listeIntervenants.Add(intervenant);
            }

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien de matières concerne-t-il ?");
            int nbMatiere = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            cpt = 0;
            string matiere = "";
            List<string> listeMatieres = new List<string>();
            while (cpt < nbMatiere && matiere != "quitter" && matiere != "Quitter" && matiere != "QUITTER")
            {
                cpt++;
                Console.WriteLine("Veuillez indiquer le nom d'une matière impliquée dans ce projet, si celles-ci ont toutes été renseignées, entrez \"quitter\"");
                matiere = Console.ReadLine();
                if (matiere != "quitter" && matiere != "QUITTER" && matiere != "Quitter")
                    listeMatieres.Add(matiere);
            }

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            Console.WriteLine("Combien de livrables concerne-t-il ?");
            int nbLivrables = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");
            cpt = 0;
            string livrable = "";
            List<string> listeLivrables = new List<string>();
            while (cpt < nbLivrables && livrable != "quitter" && livrable != "Quitter" && livrable != "QUITTER")
            {
                cpt++;
                Console.WriteLine("Veuillez indiquer le nom d'un livrable pour ce projet, si ceux-ci ont tous été renseignés, entrez \"quitter\"");
                livrable = Console.ReadLine();
                if (livrable != "quitter" && livrable != "QUITTER" && livrable != "Quitter")
                    listeLivrables.Add(livrable);
            }

            Projet projet = new Projet(nomProjet, typeProjet, nbSemaines, nbIntervenant, nbLivrables, nbMatiere, listeLivrables, listeMatieres, listeIntervenants);

            // Le stocker en XML

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Projet));
            var subReq = projet;
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                }
            }
        }
    }
}
