using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    class Intervenant
    {
        //Attributs de la classe
        private string _nom;
        private string _prenom;
        private string _type;
        private int _reference; //1-etudiant, 2-prof, 3-intervnenant exte

        //
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Type { get => _type; set => _type = value; }
        public int Reference { get => _reference; set => _reference = value; }

        //Constructeur
        public Intervenant(string nom, string prenom, string type, int reference)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Type = type;
            this.Reference = reference;
        }

        //Methodes
        public static void CreationIntervenant(int nbIntervenant)
        {

            Console.Clear();
            Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Intervenant>)); // Initialisation de l'outils de serialisation
            List<Intervenant> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("intervenants.xml"))
            {
                dezerializedList = (List<Intervenant>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Intervenant i in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine(i.Reference + "pour" + i.Type); // On affiche les attributs de la matière
            }

            int cpt = 0;
            List<Intervenant> listeIntervenant = new List<Intervenant>();

            while (cpt < nbIntervenant)
            {
                Console.WriteLine("Indiquez le nom de l'intervenant");
                string nom = Console.ReadLine();
                Console.WriteLine("Indiquez le prenom de l'intervenant");
                string prenom = Console.ReadLine();
                Console.WriteLine("Indiquez la catégorie de l'intervenant");
                cpt++;
                int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());
                switch (entreeUtilisateur)
                {
                    case 1:
                        //Appeler fonction création étu;
                        break;
                    case 2:
                        //Appeler fonction création prof;
                        break;
                    case 3:
                        //Appeler fonction création exte;
                        break;
                }

            }
        }
    }
}
