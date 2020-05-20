using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    public class Menu
    {

        public static void Bandeau()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
            Console.WriteLine("------------------------------------------------------------------------");

        }

        public static void AfficherMenuRecherche(int fonctionàappeler)
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Créer un projet"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {

                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Relancer une recherche");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au catalogue");
                    Console.WriteLine("Retour au menu principal");
                    Console.WriteLine("Quitter le gestionnaire");

                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("Relancer une recherche");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au catalogue");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.WriteLine("Quitter le gestionnaire");
                }

                else if (positionCurseur == 3)
                {
                    Console.WriteLine("Relancer une recherche");
                    Console.WriteLine("Retour au catalogue");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Quitter le gestionnaire");
                }

                else if (positionCurseur == 4)
                {
                    Console.WriteLine("Relancer une recherche");
                    Console.WriteLine("Retour au catalogue");
                    Console.WriteLine("Retour au menu principal");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Quitter le gestionnaire");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                keyPressed = Console.ReadKey(); // récupération de la touche pressée

                if (keyPressed.Key == ConsoleKey.UpArrow) // selon la touche pressée on déplace le curseur
                {
                    if (positionCurseur == 1)
                        positionCurseur = 4;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;
                    else if (positionCurseur == 3)
                        positionCurseur = 2;
                    else if (positionCurseur == 4)
                        positionCurseur = 3;
                }

                else if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (positionCurseur == 1)
                        positionCurseur = 2;
                    else if (positionCurseur == 2)
                        positionCurseur = 3;
                    else if (positionCurseur == 3)
                        positionCurseur = 4;
                    else if (positionCurseur == 4)
                        positionCurseur = 1;
                }

                //Pour réinitialiser l'affichage sans écraser le reste de la console
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
            while (keyPressed.Key != ConsoleKey.Enter); // On sort de la boucle si la touche pressée est entrée et on renvoie le choix de l'utilisateur

            switch (positionCurseur)
            {
                case 1:
                    if (fonctionàappeler == 1)
                    { Projet.RechercheParEleve(); }
                    if (fonctionàappeler == 2)
                    { Projet.RechercheParPromo(); }
                    if (fonctionàappeler == 3)
                    { Projet.RechercheParPromo(); }
                    if (fonctionàappeler == 4)
                    { Projet.RechercheParMotCle(); }
                    break;

                case 2:
                    Projet.AffichageProjets();
                    break;
                case 3:
                    AfficherMenuPrincipal();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void AfficherMenuListeProjet()
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Créer un projet"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {

                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Afficher la fiche d'un projet");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Effectuer une recherche avec filtre");
                    Console.WriteLine("Retour au menu principal");
                    Console.WriteLine("Quitter le gestionnaire");

                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("Afficher la fiche d'un projet");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Effectuer une recherche avec filtre");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.WriteLine("Quitter le gestionnaire");
                }

                else if (positionCurseur == 3)
                {
                    Console.WriteLine("Afficher la fiche d'un projet");
                    Console.WriteLine("Effectuer une recherche avec filtre");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Quitter le gestionnaire");
                }

                else if (positionCurseur == 4)
                {
                    Console.WriteLine("Afficher la fiche d'un projet");
                    Console.WriteLine("Effectuer une recherche avec filtre");
                    Console.WriteLine("Retour au menu principal");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Quitter le gestionnaire");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                keyPressed = Console.ReadKey(); // récupération de la touche pressée

                if (keyPressed.Key == ConsoleKey.UpArrow) // selon la touche pressée on déplace le curseur
                {
                    if (positionCurseur == 1)
                        positionCurseur = 4;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;
                    else if (positionCurseur == 3)
                        positionCurseur = 2;
                    else if (positionCurseur == 4)
                        positionCurseur = 3;
                }

                else if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (positionCurseur == 1)
                        positionCurseur = 2;
                    else if (positionCurseur == 2)
                        positionCurseur = 3;
                    else if (positionCurseur == 3)
                        positionCurseur = 4;
                    else if (positionCurseur == 4)
                        positionCurseur = 1;
                }

                //Pour réinitialiser l'affichage sans écraser le reste de la console
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
            while (keyPressed.Key != ConsoleKey.Enter); // On sort de la boucle si la touche pressée est entrée et on renvoie le choix de l'utilisateur

            switch (positionCurseur)
            {
                case 1:
                    Console.WriteLine("Entrez le chiffre correspondant au projet");
                    int numprojet = Int32.Parse(Console.ReadLine());
                    AfficherMenuFicheProjet(numprojet);
                    break;

                case 2:
                    AfficherMenuProjets();
                    break;
                case 3:
                    AfficherMenuPrincipal();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }


        }

        public static void AfficherMenuFicheProjet(int _referenceprojet)
        {
            Projet.AffichageFicheProjet(_referenceprojet);
            Console.WriteLine("");

            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Créer un projet"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {

                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Modifier le projet");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour à la liste de projets");
                    Console.WriteLine("Retour au menu principal");
                    Console.WriteLine("Quitter le gestionnaire");

                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("Modifier le projet");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour à la liste de projets");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.WriteLine("Quitter le gestionnaire");
                }

                else if (positionCurseur == 3)
                {
                    Console.WriteLine("Modifier le projets");
                    Console.WriteLine("Retour à la liste de projets");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Quitter le gestionnaire");
                }

                else if (positionCurseur == 4)
                {
                    Console.WriteLine("Modifier le projet");
                    Console.WriteLine("Retour à la liste de projets");
                    Console.WriteLine("Retour au menu principal");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Quitter le gestionnaire");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                keyPressed = Console.ReadKey(); // récupération de la touche pressée

                if (keyPressed.Key == ConsoleKey.UpArrow) // selon la touche pressée on déplace le curseur
                {
                    if (positionCurseur == 1)
                        positionCurseur = 4;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;
                    else if (positionCurseur == 3)
                        positionCurseur = 2;
                    else if (positionCurseur == 4)
                        positionCurseur = 3;
                }

                else if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (positionCurseur == 1)
                        positionCurseur = 2;
                    else if (positionCurseur == 2)
                        positionCurseur = 3;
                    else if (positionCurseur == 3)
                        positionCurseur = 4;
                    else if (positionCurseur == 4)
                        positionCurseur = 1;
                }

                //Pour réinitialiser l'affichage sans écraser le reste de la console
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
            while (keyPressed.Key != ConsoleKey.Enter); // On sort de la boucle si la touche pressée est entrée et on renvoie le choix de l'utilisateur

            switch (positionCurseur)
            {
                case 1:
                    Projet.ModifierProjet(_referenceprojet);
                    AfficherMenuFicheProjet(_referenceprojet);
                    break;
                case 2:
                    Projet.AffichageProjets();
                    break;
                case 3:
                    Menu.AfficherMenuPrincipal();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }


        }

        public static void AfficherMenuProjets()
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Visualiser l'ensemble des projets"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {
                Menu.Bandeau();

                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.WriteLine("Filtrer par mots clés");
                    Console.WriteLine("Retour au menu principal");

                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.WriteLine("Filtrer par mots clés");
                    Console.WriteLine("Retour au menu principal");
                }
                else if (positionCurseur == 3)
                {
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.WriteLine("Filtrer par mots clés");
                    Console.WriteLine("Retour au menu principal");
                }
                else if (positionCurseur == 4)
                {
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer par mots clés");
                    Console.WriteLine("Retour au menu principal");


                }
                else if (positionCurseur == 5)
                {
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer par mots clés");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                }
                else
                {
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.WriteLine("Filtrer par mots clés");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Retour au menu principal");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                keyPressed = Console.ReadKey(); // récupération de la touche pressée

                if (keyPressed.Key == ConsoleKey.UpArrow) // selon la touche pressée on déplace le curseur
                {

                    if (positionCurseur == 1)
                        positionCurseur = 6;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;
                    else if (positionCurseur == 3)
                        positionCurseur = 2;
                    else if (positionCurseur == 4)
                        positionCurseur = 3;
                    else if (positionCurseur == 5)
                        positionCurseur = 4;
                    else if (positionCurseur == 6)
                        positionCurseur = 5;
                }

                else if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (positionCurseur == 1)
                        positionCurseur = 2;
                    else if (positionCurseur == 2)
                        positionCurseur = 3;
                    else if (positionCurseur == 3)
                        positionCurseur = 4;
                    else if (positionCurseur == 4)
                        positionCurseur = 5;
                    else if (positionCurseur == 5)
                        positionCurseur = 6;
                    else if (positionCurseur == 6)
                        positionCurseur = 1;
                }
                Console.Clear();
            }
            while (keyPressed.Key != ConsoleKey.Enter); // On sort de la boucle si la touche pressée est entrée et on renvoie le choix de l'utilisateur

            switch (positionCurseur)
            {
                case 1:
                    Projet.AffichageProjets();
                    break;
                case 2:
                    Projet.RechercheParEleve();
                    break;
                case 3:
                    Projet.RechercheParPromo();
                    break;
                case 4:
                    Projet.RechercheParAnnee();
                    break;
                case 5:
                    Projet.RechercheParMotCle();
                    break;
                case 6:
                    Menu.AfficherMenuPrincipal();
                    break;
            }
        }

        public static void AfficherMenuPrincipal()
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Créer un projet"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {
                Bandeau();

                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Créer un projet");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Visualiser les projets");

                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("Créer un projet");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Visualiser les projets");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                keyPressed = Console.ReadKey(); // récupération de la touche pressée

                if (keyPressed.Key == ConsoleKey.UpArrow) // selon la touche pressée on déplace le curseur
                {
                    if (positionCurseur == 1)
                        positionCurseur = 2;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;
                }

                else if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (positionCurseur == 1)
                        positionCurseur = 2;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;

                }
                Console.Clear();
            }
            while (keyPressed.Key != ConsoleKey.Enter); // On sort de la boucle si la touche pressée est entrée et on renvoie le choix de l'utilisateur
                                                        // On retourne la position du curseur au moment où on appuie sur la touche entrée
                                                        // Celle-ci sera récupérée par le main pour savoir quel choix nous avons fait et effectuer les enchainements de fonctions.
            switch (positionCurseur)
            {
                case 1:
                    Projet.CreationProjet();
                    break;
                case 2:
                    Projet.AffichageProjets();
                    break;
            }

        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }
}

