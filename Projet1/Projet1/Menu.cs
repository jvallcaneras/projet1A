using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    public class Menu
    {   

        public static int AfficherMenuPrincipal()
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Créer un projet"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {
                Console.WriteLine("\n\t \t \t \t\t \t \t \t Gestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
                Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");


                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {
                    Console.Write("\t \t \t \t \t \t \t \t \t \t \t     ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Créer un projet");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t    Visualiser les projets");
                    
                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("\t \t \t \t \t \t \t \t \t \t \t     Créer un projet");

                    Console.Write(" \t \t \t \t \t \t \t \t \t \t \t    ");
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

        public static int AfficherMenuProjets()
        {
            ConsoleKeyInfo keyPressed; // Nous permettra de récupérer l'entrée du clavier afin de bouger dans le menu
            int positionCurseur = 1; // On initialise le curseur à 1 : Position sur "Visualiser l'ensemble des projets"
            do // On met à jour l'affichage en fonction des touches pressées (haut/bas/entrée)
            {
                Console.WriteLine("\n\t \t \t \t\t \t \t \t \tGestionnaire de projets de l'Ecole Nationale Supérieure de Cognitique");
                Console.WriteLine("\n \n \n \n \n \n \n \n \n \n");


                if (positionCurseur == 1) // le curseur est déplacé en fonction de la valeur de positionCurseur qui est mis à jour plus bas en fonction
                                          // des touches pressées
                {
                    Console.Write("\t \t \t \t \t \t \t \t \t \t \t");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Visualiser l'ensemble des projets");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par élève");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \tFiltrer les projets par promotion");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t   Filtrer les projets par année de scolarité");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t    Filtrer par mots clés");
                    Console.WriteLine("\n \n \n \n \n \n \n \n \t \t \t \t \t \t \t \t \t\t \t \t \t \t \t\t \t \t \t \t \t Retour");
                }
                else if (positionCurseur == 2)
                {
                    Console.WriteLine("\t \t \t \t \t \t \t \t \t \t \tVisualiser l'ensemble des projets");
                    Console.Write(" \t \t \t \t \t \t \t \t \t \t \t ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par élève");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par promotion");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t   Filtrer les projets par année de scolarité");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t    Filtrer par mots clés");
                    Console.WriteLine("\n \n \n \n \n \n \n \n \t \t \t \t \t \t \t \t \t\t \t \t \t \t \t\t \t \t \t \t \t Retour");
                }
                else if (positionCurseur == 3)
                {
                    Console.WriteLine("\t \t \t \t \t \t \t \t \t \t \tVisualiser l'ensemble des projets");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par élève");
                    Console.Write(" \t \t \t \t \t \t \t \t \t \t \t ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par promotion");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t   Filtrer les projets par année de scolarité");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t    Filtrer par mots clés");
                    Console.WriteLine("\n \n \n \n \n \n \n \n \t \t \t \t \t \t \t \t \t\t \t \t \t \t \t\t \t \t \t \t \t Retour");
                }
                else if (positionCurseur == 4)
                {
                    Console.WriteLine("\t \t \t \t \t \t \t \t \t \t \tVisualiser l'ensemble des projets");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par élève");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par promotion");
                    Console.Write(" \t \t \t \t \t \t \t \t \t \t   ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Filtrer les projets par année de scolarité");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t    Filtrer par mots clés");
                    Console.WriteLine("\n \n \n \n \n \n \n \n \t \t \t \t \t \t \t \t \t\t \t \t \t \t \t\t \t \t \t \t \t Retour");

                }
                else
                {
                    Console.WriteLine("\t \t \t \t \t \t \t \t \t \t \tVisualiser l'ensemble des projets");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par élève");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t \t Filtrer les projets par promotion");
                    Console.WriteLine(" \t \t \t \t \t \t \t \t \t \t   Filtrer les projets par année de scolarité");
                    Console.Write(" \t \t \t \t \t \t \t \t \t \t \t    ");
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
            return positionCurseur; // On retourne la position du curseur au moment où on appuie sur la touche entrée
            // Celle-ci sera récupérée par le main pour savoir quel choix nous avons fait et effectuer les enchainements de fonctions.
        }


    }
}
