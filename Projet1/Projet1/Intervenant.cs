using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    [XmlInclude(typeof(Eleve))]
    [XmlInclude(typeof(Professeur))]
    [XmlInclude(typeof(Exte))]
    public class Intervenant
    {
        //Attributs de la classe
        private string _type;
        private int _reference; //1-etudiant, 2-prof, 3-intervnenant ext

        //Accesseurs
        public string Type { get => _type; set => _type = value; }
        public int Reference { get => _reference; set => _reference = value; }

        //Constructeurs
        public Intervenant(string type, int reference)
        {
            this.Type = type;
            this.Reference = reference;
        }

        public Intervenant() { }


        //Methodes
        public static List<Intervenant> CreationIntervenant()
        {
            Menu.Bandeau();
            Console.WriteLine("Combien y a-t-il d'acteurs ? (etudiants et encadrants)");
            int nbIntervenant = Convert.ToInt32(Console.ReadLine());

            XmlSerializer serializer = new XmlSerializer(typeof(List<Intervenant>)); // Initialisation de l'outils de serialisation
            List<Intervenant> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("intervenants.xml"))
            {
                dezerializedList = (List<Intervenant>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
           
            Console.WriteLine("Tapez 1 pour Etudiant");
            Console.WriteLine("Tapez 2 pour Professeur");
            Console.WriteLine("Tapez 3 pour Intervenant extérieur");

            int cpt = 0;
            List<Intervenant> listeIntervenant = new List<Intervenant>();

            while (cpt < nbIntervenant)
            {
                cpt++;
                Console.WriteLine("\nIndiquez le chiffre correspondant à la catégorie de l'intervenant n° " + cpt);
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
