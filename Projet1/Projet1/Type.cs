using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    public class Type
    {
        //Attributs de la classe
        private string _nomType;
        private int _ref;


        //Accesseurs
        public string NomType { get => _nomType; set => _nomType = value; }
        public int Ref { get => _ref; set => _ref = value; }


        //Constructeurs
        public Type(string nomType, int reference)
        {
            this.NomType = nomType;
            this.Ref = reference;
        }
        public Type() { }


        //Methodes
        public static Type CreationType()
        {
            Menu.Bandeau();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Type>)); // Initialisation de l'outils de serialisation
            List<Type> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("types.xml"))
            {
                dezerializedList = (List<Type>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }

            Console.WriteLine("Choisissez le type du projet (si le type de projet souhaité n'est pas dans la liste, tapez 0");
            foreach (Type t in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine("Tapez " + t.Ref + " pour " + t.NomType); // On affiche les attributs de la matière
            }

            int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());
            if (entreeUtilisateur == 0)
            {
                Console.WriteLine("Saisissez le nom du type");
                Type ty = new Type(Console.ReadLine(), dezerializedList.Count + 1); // On créé la nouvelle matière
                dezerializedList.Add(ty);

                XmlSerializer xs1 = new XmlSerializer(typeof(List<Type>));
                using (StreamWriter wr = new StreamWriter("types.xml"))
                {
                    xs1.Serialize(wr, dezerializedList);// On réécrie le fichier de matières en ajoutant la nouvelle 
                }

                return (ty);
            }
            else
            {
                string nomty = dezerializedList[entreeUtilisateur - 1].NomType;
                int refty = dezerializedList[entreeUtilisateur - 1].Ref;

                Type ty = new Type(nomty, refty);
                return (ty);
            }
        }
    }
}
