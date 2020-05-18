﻿//CREER UNE LISTE DE TYPES DE PROJETS SUR LE MODELE DES MATIERES ?

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    public class Projet
    {
        //Attributs de la classe
        private int _reference;
        private string _nomProjet;
        private int _typeProjet; // 1 - Transdi / 2 - transpromo / 3 - PFE / 4 - Intro prog / 5 - autre (à étoffer)
        private int _dureeSemaine;

        private List<Matiere> _matieres;
        private List<Livrable> _livrables;
        private List<Intervenant> _intervenants;
        private List<Role> _roles;

        //Propritétés
        public int Reference { get => _reference; set => _reference = value; }
        public int TypeProjet { get => _typeProjet; set => _typeProjet = value; }
        public string NomProjet { get => _nomProjet; set => _nomProjet = value; }
        public int DureeSemaine { get => _dureeSemaine; set => _dureeSemaine = value; }
        public List<Livrable> Livrables { get => _livrables; set => _livrables = value; }
        public List<Intervenant> Intervenants { get => _intervenants; set => _intervenants = value; }
        public List<Matiere> Matieres { get => _matieres; set => _matieres = value; }
        public List<Role> Roles { get => _roles; set => _roles = value; }

        //Constructeurs 
        public Projet(int reference, string nomProjet, int typeProjet, int dureeSemaine, List<Matiere> matieres, List<Livrable> livrables, List<Intervenant> intervenants, List<Role> roles)
        {
            this.Reference = reference;
            this.NomProjet = nomProjet;
            this.TypeProjet = typeProjet;
            this.DureeSemaine = dureeSemaine;
            this.Matieres = matieres;
            this.Livrables = livrables;
            this.Intervenants = intervenants;
            this.Roles = roles;
        }

        public Projet() { }


        //Methodes

        public static void CreationProjet()
        {

            //Referencage du projet

            int reference = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Projet p in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                reference++;
            }

            //Création des caractéristiques du projet  
            Menu.Bandeau();
            Console.WriteLine("Quel est le nom du projet que vous souhaitez créer ?");
            string nomProjet = Console.ReadLine();

            Menu.Bandeau();
            Console.WriteLine("Quel type de projet souhaitez-vous créer ? \n 1 pour projet transdisciplinaire \n 2 pour projet transpromotion" +
                "\n 3 pour projet de fin d'études \n 4 pour projet d'introduction à la programmation \n 5 pour autre");
            int typeProjet = Convert.ToInt32(Console.ReadLine());

            Menu.Bandeau();
            Console.WriteLine("Quelle est la durée du projet ? (en semaines)");
            int nbSemaines = Convert.ToInt32(Console.ReadLine());

            List<Intervenant> listeIntervenants = new List<Intervenant>();
            listeIntervenants = Intervenant.CreationIntervenant();

            List<Role> listeRoles = new List<Role>();
            foreach (Eleve e in listeIntervenants)
            { listeRoles = Role.CreationRole(listeRoles, e._nom, e._prenom); }
            foreach (Professeur p in listeIntervenants)
            { listeRoles = Role.CreationRole(listeRoles, p._nom, p._prenom); }
            foreach (Exte ex in listeIntervenants)
            { listeRoles = Role.CreationRole(listeRoles, ex._nom, ex._prenom); }

            List<Matiere> listeMatieres = new List<Matiere>();
            listeMatieres = Matiere.CreationMatiere();

            List<Livrable> listeLivrables = new List<Livrable>();
            listeLivrables = Livrable.CreationLivrable();

            Projet projet = new Projet(reference, nomProjet, typeProjet, nbSemaines, listeMatieres, listeLivrables, listeIntervenants, listeRoles);

            //Stockage en XML

            XmlSerializer serie = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> newList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                newList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            newList.Add(projet);
            XmlSerializer xs1 = new XmlSerializer(typeof(List<Projet>));
            using (StreamWriter wr = new StreamWriter("projets.xml"))
            {
                xs1.Serialize(wr, newList);// On réécrie le fichier de matières en ajoutant la nouvelle 
            }

        }


        public static void AffichageFicheProjet(int _referenceprojet)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }

            foreach (Projet p in dezerializedList)
            {
                if (_referenceprojet == p.Reference)
                {
                    Console.WriteLine("Bienvenue sur la fiche du projet " + p._nomProjet);
                    Console.WriteLine("Ce projet est un projet de type " + p.TypeProjet + " impliquant les matières ");
                    foreach(Matiere m in p.Matieres) 
                    {
                        Console.WriteLine("- " + m.NomMatiere);
                    }
                    Console.WriteLine("Les intervenants de ce projet sont : ");


                }
            }
        }

        public static void AffichageProjet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Projet p in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine(p.Reference + " - " + p.NomProjet + "(" + p.TypeProjet + ")");
            }

            Console.WriteLine("Entrez le numéro du projet sur lequel vous souhaitez obtenir des informations");
            int entreeUtilisateur = Convert.ToInt32(Console.ReadLine());

            foreach (Projet p in dezerializedList)
            {
                if (entreeUtilisateur == p.Reference)
                {
                    Console.WriteLine(p.NomProjet + " est un projet de type " + p.TypeProjet + "concernant les matières : " + p.Matieres);
                    Console.WriteLine("Il implique les intervenants suivants : " + p.Intervenants + " qui occupent les rôles suivants : " + p.Roles);
                    Console.WriteLine("Les livrables attendus sont les suivants : " + p.Livrables);
                }

            }
        }

        public static void AffichageParIntervenant()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Projet p in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine("Entrez le nom de l'intervenant");
                string Nom = Console.ReadLine();
                Console.WriteLine("Entrez le prenom de l'intervenant");
                string Prenom = Console.ReadLine();

                foreach (Eleve e in p.Intervenants)
                {
                    if (e.Nom == Nom && e.Prenom == Prenom)
                    {
                        foreach (Role r in p.Roles)
                            if (p.Intervenants.IndexOf(e) == p.Roles.IndexOf(r))
                            {
                                Console.WriteLine("Cet.te etduiant. a rempli le rôle de " + r.Libelle + " dans le projet " + p.NomProjet + " lors de sa " + e.Annee + "A");
                            }
                    }
                }

                foreach (Professeur prof in p.Intervenants)
                {
                    if (prof.Nom == Nom && prof.Prenom == Prenom)
                    {
                        foreach (Role r in p.Roles)
                            if (p.Intervenants.IndexOf(prof) == p.Roles.IndexOf(r))
                            {
                                Console.WriteLine("Ce professeur a rempli le rôle de " + r.Libelle + "dans le projet" + p.NomProjet);
                            }
                    }
                }

                foreach (Exte ext in p.Intervenants)
                {
                    if (ext.Nom == Nom && ext.Prenom == Prenom)
                    {
                        foreach (Role r in p.Roles)
                            if (p.Intervenants.IndexOf(ext) == p.Roles.IndexOf(r))
                            {
                                Console.WriteLine("Cet.te intervenant.e a rempli le rôle de " + r.Libelle + "dans le projet" + p.NomProjet);
                            }
                    }
                }
            }
        }


        public static void AffichageParMatiere()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Projet p in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine("Entrez le nom de la matière");
                string mat = Console.ReadLine();

                foreach (Matiere m in p.Matieres)
                {
                    if (m.NomMatiere == mat)
                    {
                        Console.WriteLine(p.NomProjet);
                    }
                }

            }
        }
    }
}
