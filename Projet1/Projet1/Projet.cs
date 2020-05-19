//CREER UNE LISTE DE TYPES DE PROJETS SUR LE MODELE DES MATIERES ?

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;

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

            int reference = 1; //Nécessite un décalage de 1 car la valeur de référence sera le nombre de projets existants +1.
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
            foreach (Eleve e in listeIntervenants.OfType<Eleve>())
            { listeRoles = Role.CreationRole(listeRoles, e._nom, e._prenom); }
            foreach (Professeur p in listeIntervenants.OfType<Professeur>())
            { listeRoles = Role.CreationRole(listeRoles, p._nom, p._prenom); }
            foreach (Exte ex in listeIntervenants.OfType<Exte>())
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

        public static void MenuFicheProjet(int _referenceprojet)
        {
            AffichageFicheProjet(_referenceprojet);

            Console.WriteLine("\nPour modifier le projet appuyez sur 1");
            Console.WriteLine("Pour revenir à la liste des projets, appuyez sur 2");
            Console.WriteLine("Pour revenir au menu principal appuyez sur 3");
            Console.WriteLine("Pour quitter le gestionnaire appuyez sur 4");
            int entreeUtilisateur = int.Parse(Console.ReadLine());

            switch (entreeUtilisateur)
            {
                case 1:
                    ModifierProjet(_referenceprojet);
                    break;
                case 2:
                    AffichageProjet();
                    break;
                case 3:
                    Menu.AfficherMenuPrincipal();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Entrez une valeur correcte");
                    break;
            }

        }

        public static void AffichageFicheProjet(int _referenceprojet)
        {
            Menu.Bandeau();
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
                    Console.WriteLine("\nCe projet est un projet de type " + p.TypeProjet + " et d'une durée de " + p.DureeSemaine + " semaines. Il implique les matières :");
                    foreach (Matiere m in p.Matieres)
                    {
                        Console.WriteLine("- " + m.NomMatiere);
                    }
                    Console.WriteLine("\nLes intervenants de ce projet sont : ");
                    foreach (Eleve e in p.Intervenants.OfType<Eleve>())
                    {
                        foreach (Role r in p.Roles)
                        {
                            if (p.Intervenants.IndexOf(e) == p.Roles.IndexOf(r))
                            {
                                Console.WriteLine("- " + e.Prenom + " " + e.Nom + " - Etudiant.e en " + e.Annee + "A (Promo " + e.Promo + ") qui est " + r.Libelle);
                            }
                        }
                    }
                    foreach (Professeur prof in p.Intervenants.OfType<Professeur>())
                    {
                        foreach (Role r in p.Roles)
                        {
                            if (p.Intervenants.IndexOf(prof) == p.Roles.IndexOf(r))
                            {
                                Console.WriteLine("" +
                                    "- " + prof.Prenom + " " + prof.Nom + " - Professeur.e à l'ENSC qui est " + r.Libelle);
                            }
                        }
                    }

                    foreach (Exte exte in p.Intervenants.OfType<Exte>())
                    {
                        foreach (Role r in p.Roles)
                        {
                            if (p.Intervenants.IndexOf(exte) == p.Roles.IndexOf(r))
                            {
                                Console.WriteLine("" +
                                    "- " + exte.Prenom + " " + exte.Nom + " - Intervenant exterieur (" + exte.Entreprise + ") qui est " + r.Libelle);
                            }
                        }
                    }
                    Console.WriteLine("\nLes livrables attendus pour ce projet sont de les suivants : ");
                    foreach (Livrable l in p.Livrables)
                    {
                        Console.WriteLine("- " + l.typeLivrable + " (deadline : " + l.dateRendu + ")");
                    }                 
                }
            }
        }

        public static void ModifierProjet(int _referenceprojet)
        {
            Menu.Bandeau();
            AffichageFicheProjet(_referenceprojet);

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
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Modification du projet " + p._nomProjet);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("\nLes paramètres actuels du projet sont donnés ci-dessus");
                    Console.WriteLine("\nPour modifier le nom du projet tapez 1");
                    Console.WriteLine("Pour modifier son type tapez 2");
                    Console.WriteLine("Pour modifier sa durée tapez 3");
                    Console.WriteLine("Pour modifier les matières tapez 4");
                    Console.WriteLine("Pour modifier les intervenants tapez 5");
                    Console.WriteLine("Pour modifier les rôles tapez 6");
                    Console.WriteLine("Pour modifier les livrables tapez 7");
                    Console.WriteLine("Pour retourner à la fiche projet tapez 0");
                    int entreeUtilisateur = Int32.Parse(Console.ReadLine());

                    switch (entreeUtilisateur)
                    {
                        case 0:
                            MenuFicheProjet(_referenceprojet);
                            break;
                        case 1:
                            Console.WriteLine("Entrez le nouveau nom du projet");
                            string newNom = Console.ReadLine();
                            dezerializedList[_referenceprojet - 1].NomProjet = newNom;
                            XmlSerializer xs1 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs1.Serialize(wr, dezerializedList);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Entrez le nouveau type du projet");
                            int newType = Int32.Parse(Console.ReadLine());
                            dezerializedList[_referenceprojet - 1].TypeProjet = newType;
                            XmlSerializer xs2 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs2.Serialize(wr, dezerializedList);
                            }

                            break;
                        case 3:
                            Console.WriteLine("Entrez la nouvelle durée du projet (En nombre de semaines)");
                            int newnbSemaine = Int32.Parse(Console.ReadLine());
                            dezerializedList[_referenceprojet - 1].DureeSemaine = newnbSemaine;
                            XmlSerializer xs3 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs3.Serialize(wr, dezerializedList);
                            }
                            break;

                        case 4:
                            List<Matiere> newMat = new List<Matiere>();
                            newMat = Matiere.CreationMatiere();
                            dezerializedList[_referenceprojet - 1].Matieres = newMat;
                            XmlSerializer xs4 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs4.Serialize(wr, dezerializedList);
                            }
                            break;

                        case 5:
                            List<Intervenant> newInt = new List<Intervenant>();
                            newInt = Intervenant.CreationIntervenant();
                            dezerializedList[_referenceprojet - 1].Intervenants = newInt;
                            XmlSerializer xs5 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs5.Serialize(wr, dezerializedList);
                            }
                            break;

                        case 6 :
                            List<Role> newRole = new List<Role>();
                            foreach (Eleve e in dezerializedList[_referenceprojet - 1].Intervenants.OfType<Eleve>())
                            { newRole = Role.CreationRole(newRole, e._nom, e._prenom); }
                            foreach (Professeur pr in dezerializedList[_referenceprojet - 1].Intervenants.OfType<Professeur>())
                            { newRole = Role.CreationRole(newRole, pr._nom, pr._prenom); }
                            foreach (Exte ex in dezerializedList[_referenceprojet - 1].Intervenants.OfType<Exte>())
                            { newRole = Role.CreationRole(newRole, ex._nom, ex._prenom); }

                            dezerializedList[_referenceprojet - 1].Roles = newRole;
                            XmlSerializer xs6 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs6.Serialize(wr, dezerializedList);
                            }
                            break;

                        case 7:
                            List<Livrable> newLiv = new List<Livrable>();
                            newLiv = Livrable.CreationLivrable();
                            dezerializedList[_referenceprojet - 1].Livrables = newLiv;
                            XmlSerializer xs7 = new XmlSerializer(typeof(List<Projet>));
                            using (StreamWriter wr = new StreamWriter("projets.xml"))
                            {
                                xs7.Serialize(wr, dezerializedList);
                            }

                            break;

                        default:
                            Console.WriteLine("Veuillez entrer une valeur entre correcte");
                            entreeUtilisateur = Int32.Parse(Console.ReadLine());
                            break;
                    }

                    AffichageFicheProjet(_referenceprojet);

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