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


        public static int AfficherMenuPrincipal()
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
            return positionCurseur; // On retourne la position du curseur au moment où on appuie sur la touche entrée
            // Celle-ci sera récupérée par le main pour savoir quel choix nous avons fait et effectuer les enchainements de fonctions.
        }

        public static void AfficherMenuProjets()
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Visualiser l'ensemble des projets"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
                Console.WriteLine("------------------------------------------------------------------------");



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


                }
                else
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
                }

                keyPressed = Console.ReadKey(); // récupération de la touche pressée

                if (keyPressed.Key == ConsoleKey.UpArrow) // selon la touche pressée on déplace le curseur
                {

                    if (positionCurseur == 1)
                        positionCurseur = 5;
                    else if (positionCurseur == 2)
                        positionCurseur = 1;
                    else if (positionCurseur == 3)
                        positionCurseur = 2;
                    else if (positionCurseur == 4)
                        positionCurseur = 3;
                    else if (positionCurseur == 5)
                        positionCurseur = 4;
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
            }
        }


    }
}
