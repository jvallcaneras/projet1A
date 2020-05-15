using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    public class Intervenant
    {
        //Attributs de la classe
        private string _type;
        private int _reference; //1-etudiant, 2-prof, 3-intervnenant ext

        //Accesseurs
        public string Type { get => _type; set => _type = value; }
        public int Reference { get => _reference; set => _reference = value; }

        //Constructeur
        public Intervenant(string type, int reference)
        {
            this.Type = type;
            this.Reference = reference;
        }


        //Methodes
        public static List<Intervenant> CreationIntervenant(int nbIntervenant)
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
                cpt++;
                Console.WriteLine("Indiquez la catégorie de l'intervenant n° " + cpt);
                int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());
                switch (entreeUtilisateur)
                {
                    case 1:
                        Eleve ele = Eleve.CreerEtudiant();
                        listeIntervenant.Add(ele);
                        break;
                    case 2:
                        Professeur prof = Professeur.CreerProfesseur();
                        listeIntervenant.Add(prof);
                        break;
                    case 3:
                        Exte exte = Exte.CreerExte();
                        listeIntervenant.Add(exte);
                        break;
                }
            }
            return (listeIntervenant);
        }
    }
}
