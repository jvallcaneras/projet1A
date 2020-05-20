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
        private int _dureeSemaine;
        private Type _typeProjet;
        private List<Matiere> _matieres;
        private List<Livrable> _livrables;
        private List<Intervenant> _intervenants;
        private List<Role> _roles;

        //Propritétés
        public int Reference { get => _reference; set => _reference = value; }
        public Type TypeProjet { get => _typeProjet; set => _typeProjet = value; }
        public string NomProjet { get => _nomProjet; set => _nomProjet = value; }
        public int DureeSemaine { get => _dureeSemaine; set => _dureeSemaine = value; }
        public List<Livrable> Livrables { get => _livrables; set => _livrables = value; }
        public List<Intervenant> Intervenants { get => _intervenants; set => _intervenants = value; }
        public List<Matiere> Matieres { get => _matieres; set => _matieres = value; }
        public List<Role> Roles { get => _roles; set => _roles = value; }

        //Constructeurs 
        public Projet(int reference, string nomProjet, Type typeProjet, int dureeSemaine, List<Matiere> matieres, List<Livrable> livrables, List<Intervenant> intervenants, List<Role> roles)
        {
            this.Reference = reference;
            this.NomProjet = nomProjet;
            this.DureeSemaine = dureeSemaine;
            this.TypeProjet = typeProjet;
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
            Type typeProjet = Type.CreationType();

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

            Console.WriteLine("Le projet a bien été créé. Appuyez sur une touche pour être redirigé vers la liste de projets");
            Console.ReadKey();
            AffichageProjets();

        } //OK

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
                    Console.WriteLine("\nCe projet est un projet de type " + p.TypeProjet.NomType + " et d'une durée de " + p.DureeSemaine + " semaines. Il implique les matières :");
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
        } //OK

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
                            Menu.AfficherMenuFicheProjet(_referenceprojet);
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
                            Type newType = new Type();
                            newType = Type.CreationType();
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

                        case 6:
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
                    Console.WriteLine("\nLes modifications ont été prises en compte. Appuyez sur une touche pour revenir à la fiche projet");
                    Console.ReadKey();
                    Menu.AfficherMenuFicheProjet(_referenceprojet);

                }
            }
        } //OK

        public static void AffichageProjets()
        {
            Menu.Bandeau();
            Console.WriteLine("\nListe des projets existants :\n");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }
            foreach (Projet p in dezerializedList)// Pour chaque matière récupérée dans la liste desérialisée
            {
                Console.WriteLine(p.Reference + " - " + p.NomProjet + " (" + p.TypeProjet.NomType + ")");
            }

            Console.WriteLine("\n");
            Menu.AfficherMenuListeProjet();
        } //OK

        public static void RechercheParEleve()
        {
            Menu.Bandeau();
            Console.WriteLine("\n--Recherche par étudiant--");
            Console.WriteLine("\nEntrez le prénom de l'étudiant.e");
            string prenom = Console.ReadLine();
            prenom = prenom[0].ToString().ToUpper() + prenom.Substring(1).ToLower(); //Pour protéger de la sensibilité à la casse

            Console.WriteLine("Entrez le nom de l'étudiant.e");
            string nom = Console.ReadLine();
            nom = nom[0].ToString().ToUpper() + nom.Substring(1).ToLower();

            Console.WriteLine("\nL'étudiant.e " + prenom + " " + nom + " intervient dans les projets suivants : \n");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }

            int cpt = 0;

            foreach (Projet p in dezerializedList)
            {
                foreach (Eleve e in p.Intervenants.OfType<Eleve>())
                {
                    if (e.Nom == nom && e.Prenom == prenom)
                    {
                        foreach (Role r in p.Roles)
                        {
                            if (p.Intervenants.IndexOf(e) == p.Roles.IndexOf(r))
                            {
                                cpt++;
                                Console.WriteLine(" - " + p.NomProjet + " (" + p.TypeProjet.NomType + ") en tant que " + r.Libelle);
                            }
                        }
                    }
                }
            }

            if (cpt == 0) { Console.WriteLine("Aucune correspondance n'a été trouvée"); }
            Console.WriteLine("\n");
            Menu.AfficherMenuRecherche(1);
        } //OK

        public static void RechercheParPromo()
        {
            Menu.Bandeau();
            Console.WriteLine("\n--Recherche par promotion--");
            Console.WriteLine("\nEntrez l'année corespondant à la promotion");
            int promo = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nDes étudiants de la promo " + promo + " ont travaillé sur les projets suivants :\n");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }

            List<Projet> listeproj = new List<Projet>();

            foreach (Projet p in dezerializedList)
            {

                foreach (Eleve e in p.Intervenants.OfType<Eleve>())
                {
                    if (e.Promo == promo)
                    {
                        if (listeproj.Contains(p) == false)
                        {
                            listeproj.Add(p);
                        }
                    }
                }
            }
            if (listeproj.Count == 0)
            {
                Console.WriteLine("Aucune correspondance trouvée");
            }
            else
            {
                foreach (Projet p in listeproj)
                {
                    Console.WriteLine(" - " + p.NomProjet + " (" + p.TypeProjet.NomType + ")");
                }
            }
            Console.WriteLine("\n");
            Menu.AfficherMenuRecherche(2);
        } //OK

        public static void RechercheParAnnee()
        {
            Menu.Bandeau();
            Console.WriteLine("\n--Recherche par année de scolarité--");
            Console.WriteLine("\nEntrez l'année souhaitée (1, 2 ou 3)");
            string anneetest = Console.ReadLine();
            while (anneetest != "1" && anneetest != "2" && anneetest != "3") //Sécurisation
            {
                Console.WriteLine("\nEntrez une année existante (1, 2 ou 3)");
                anneetest = Console.ReadLine();
            }

            int annee = Int32.Parse(anneetest);

            Console.WriteLine("\nDes étudiants de " + annee + "A ont travaillé sur les projets suivants :\n");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }

            List<Projet> listeproj = new List<Projet>();

            foreach (Projet p in dezerializedList)
            {

                foreach (Eleve e in p.Intervenants.OfType<Eleve>())
                {
                    if (e.Annee == annee)
                    {
                        if (listeproj.Contains(p) == false)
                        {
                            listeproj.Add(p);
                        }
                    }
                }
            }
            if (listeproj.Count == 0)
            {
                Console.WriteLine("Aucune correspondance trouvée");
            }
            else
            {
                foreach (Projet p in listeproj)
                {
                    Console.WriteLine(" - " + p.NomProjet + " (" + p.TypeProjet.NomType + ")");
                }
            }
            Console.WriteLine("\n");
            Menu.AfficherMenuRecherche(3);
        } //OK

        public static void RechercheParMotCle()
        {
            Menu.Bandeau();
            Console.WriteLine("\n--Recherche par mot-clé--");
            Console.WriteLine("\nEntrez le terme à rechercher");
            string motcle = Console.ReadLine();

            Console.WriteLine("\nLe terme " + motcle + " a été recontré dans sur les projets suivants :\n");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); // Initialisation de l'outils de serialisation
            List<Projet> dezerializedList = null; // Pour que la liste soit accessible en dehors du using filestream...
            using (FileStream stream = File.OpenRead("projets.xml"))
            {
                dezerializedList = (List<Projet>)serializer.Deserialize(stream); // On récupère le contenu du fichier que l'on met dans notre liste
            }

            List<Projet> listeproj = new List<Projet>();

            foreach (Projet p in dezerializedList)
            {
                if (p.TypeProjet.NomType.Contains(motcle) == true)
                {
                    if (listeproj.Contains(p) == false)
                    {
                        listeproj.Add(p);
                    }
                }
                else if (p.NomProjet.Contains(motcle) == true)
                {
                    if (listeproj.Contains(p) == false)
                    {
                        listeproj.Add(p);
                    }
                }

                foreach (Livrable l in p.Livrables)
                {
                    if (l.typeLivrable.Contains(motcle) == true)
                    {
                        if (listeproj.Contains(p) == false)
                        {
                            listeproj.Add(p);
                        }
                    }
                }
                foreach (Role r in p.Roles)
                {
                    if (r.Libelle.Contains(motcle) == true)
                    {
                        if (listeproj.Contains(p) == false)
                        {
                            listeproj.Add(p);
                        }
                    }
                }
            }

            if (listeproj.Count == 0)
            {
                Console.WriteLine("Aucune correspondance trouvée. Essayez avec ou sans majuscule.");
            }
            else
            {
                foreach (Projet p in listeproj)
                {
                    Console.WriteLine((listeproj.IndexOf(p) + 1) + " - " + p.NomProjet + " (" + p.TypeProjet.NomType + ")");
                }
            }
            Console.WriteLine("\n");
            Menu.AfficherMenuRecherche(4);
        } //OK



    }
}