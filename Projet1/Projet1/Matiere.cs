using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Projet1
{
    public class Matiere
    {
        //Attributs de la classe
        private string _nomMatiere;
        private int _ref;

        //Accesseurs
        public string NomMatiere { get => _nomMatiere; set => _nomMatiere = value; }
        public int Ref { get => _ref; set => _ref = value; }

        //Constructeurs
        public Matiere (string nomMatiere, int reference)
        {
            this.NomMatiere = nomMatiere;
            this.Ref = reference;
        }
        public Matiere() { }

        //Methodes
        public static List<Matiere> CreationMatiere()
        {
            Menu.Bandeau();
            Console.WriteLine("Combien de matières concerne-t-il ?");
            int nbMatiere = Convert.ToInt32(Console.ReadLine());

            XmlSerializer serializer = new XmlSerializer(typeof(List<Matiere>)); // Initialisation de l'outils de serialisation
            List<Matiere> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("matieres.xml"))
            {
                dezerializedList = (List<Matiere>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Matiere m in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine("Tapez " + m.Ref + " pour " + m.NomMatiere); // On affiche les attributs de la matière
            }
            Console.WriteLine("\nQuelles sont les matières associé au projet ? (Indiquez le chiffre associé à chaque matière, 0 si la matière n'est pas dans la liste);");
            int cpt = 0;
            List<Matiere> listeMatieres = new List<Matiere>();
            while (cpt < nbMatiere)
            {
                cpt++;
                Console.WriteLine("Entrez le chiffre correspondant à la matière n°" +cpt +", si elle n'est pas dans la liste, tapez 0");
                
                int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());
                if (entreeUtilisateur == 0)
                {
                    Console.WriteLine("Veuillez saisir le nom de la matière.");
                    Matiere mat = new Matiere(Console.ReadLine(), dezerializedList.Count + 1); // On créé la nouvelle matière
                    dezerializedList.Add(mat);
                    listeMatieres.Add(mat);
                    XmlSerializer xs1 = new XmlSerializer(typeof(List<Matiere>));
                    using (StreamWriter wr = new StreamWriter("matieres.xml"))
                    {
                        xs1.Serialize(wr, dezerializedList);// On réécrie le fichier de matières en ajoutant la nouvelle 
                    }
                }
                else
                {
                    foreach (Matiere m in dezerializedList)
                    {
                        if (entreeUtilisateur == m.Ref)
                            listeMatieres.Add(m); // Si l'utilisateur entre un nombre, on associe ce nombre à la matière associée en XML et on ajoute cette matière à notre liste
                    } // Il reste à gérer le cas où le nombre n'existe pas en bdd (Avec un while) pour lui demander de rééssayer sa saisie
                }
            } return (listeMatieres);
        }
    }
}
