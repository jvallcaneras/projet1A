using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection.Metadata.Ecma335;

namespace Projet1
{
    public class Livrable
    {
        //Attributs de la classe
        private int reference;
        private string _typeLivrable;
        private string _dateRendu;

        public string dateRendu { get => _dateRendu; set => _dateRendu = value; }
        public int Ref { get => reference; set => reference = value; }
        public string typeLivrable { get => _typeLivrable; set => _typeLivrable = value; }

        //Constructeur
        public Livrable(string date, int reference)
        {
            this.dateRendu = date;
            this.Ref = reference;
        }

        //Méthodes
        public static List<Livrable> CreationLivrable(int nbLivrable)
        {

            Menu.Bandeau();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Livrable>)); // Initialisation de l'outils de serialisation
            List<Livrable> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("livrables.xml"))
            {
                dezerializedList = (List<Livrable>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Livrable l in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine(l.Ref + "pour" + l.typeLivrable); // On affiche les attributs de la matière
            }
            Console.WriteLine("Indiquez les livrables attendus (Choisissez le chiffre associé au type de livrable. Tapez 0 si le livrable n'est pas dans la liste");
            int cpt = 0;
            List<Livrable> listeLivrables = new List<Livrable>();
            while (cpt < nbLivrable)
            {
                cpt++;
                int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());
                if (entreeUtilisateur == 0)
                {
                    Console.WriteLine("Veuillez saisir le nom de la matière.");
                    Livrable liv = new Livrable(Console.ReadLine(), dezerializedList.Count + 1); // On créé le nouveau livrable
                    dezerializedList.Add(liv);
                    Console.WriteLine("Veuillez saisir la date de rendu.");
                    liv.dateRendu = Console.ReadLine();
                    listeLivrables.Add(liv);
                    XmlSerializer xs1 = new XmlSerializer(typeof(List<Livrable>));
                    using (StreamWriter wr = new StreamWriter("livrables.xml"))
                    {
                        xs1.Serialize(wr, dezerializedList);// On réécrie le fichier de livrables en ajoutant la nouvelle 
                    }
                }
                else
                {
                    foreach (Livrable l in dezerializedList)
                    {
                        if (entreeUtilisateur == l.Ref)
                            Console.WriteLine("Veuillez saisir la date de rendu.");
                        l.dateRendu = Console.ReadLine();
                        listeLivrables.Add(l); // Si l'utilisateur entre un nombre, on associe ce nombre à la matière associée en XML et on ajoute cette matière à notre liste
                    } // Il reste à gérer le cas où le nombre n'existe pas en bdd (Avec un while) pour lui demander de rééssayer sa saisie
                }
            }
            return (listeLivrables);
        }
    }
}
