using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    public class Role
    {
        //Attributs de la classe
        private string _libelle;
        private int _reference;

        //Accesseurs     
        public string Libelle { get => _libelle; set => _libelle = value; }
        public int Reference { get => _reference; set => _reference = value; }

        //Constructeurs
        public Role(string libelle, int reference)
        {
            this.Libelle = libelle;
            this.Reference = reference;
        }

        public Role() { }

        //Methodes
        public static List<Role> CreationRole(List<Role> listeRole, string nomIntervenant, string prenomIntervenant)
        {
            Menu.Bandeau();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Role>)); // Initialisation de l'outils de serialisation
            List<Role> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("roles.xml"))
            {
                dezerializedList = (List<Role>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Role r in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine(r.Reference + "pour" + r.Libelle); // On affiche les attributs de la matière
            }
            Console.WriteLine("Quel est le rôle de " + nomIntervenant + " " + prenomIntervenant + " ? Tapez 0 si le rôle n'est pas dans la liste.");

            int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());
            if (entreeUtilisateur == 0)
            {
                Console.WriteLine("Veuillez saisir le rôle.");
                Role rl = new Role(Console.ReadLine(), dezerializedList.Count + 1); // On créé la nouvelle matière
                dezerializedList.Add(rl);
                listeRole.Add(rl);
                XmlSerializer xs1 = new XmlSerializer(typeof(List<Role>));
                using (StreamWriter wr = new StreamWriter("roles.xml"))
                {
                    xs1.Serialize(wr, dezerializedList);// On réécrie le fichier de matières en ajoutant la nouvelle 
                }
            }
            else
            {
                foreach (Role r in dezerializedList)
                {
                    if (entreeUtilisateur == r.Reference)
                        listeRole.Add(r); // Si l'utilisateur entre un nombre, on associe ce nombre à la matière associée en XML et on ajoute cette matière à notre liste
                }

            }
            return (listeRole);
        }

    }
}