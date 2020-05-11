using System;
using System.Collections.Generic;
using System.Text;


namespace Projet1
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix = Menu.AfficherMenuPrincipal(); // L'entier choix représentera la section du menu sélectionnée par l'utilisateur
            // Si 1 - Création d'un projet
            // Si 2 - Visualisation des projets
            if (choix == 1)
            {

                Projet.CreationProjet();
                // Gérer la création d'un projet avec des questions et des entrées utilisateur
                // Ne pas oublier de contrôler les entrées utilisateur (ex : Ne pas mettre une lettre sur le nombre de collaborateurs etc...)
            }

            else
            {
                // L'utilisateur souhaite accéder à la liste des projets, pour cela, on lance un nouveau menu permettant de choisir sur quels
                // critères on souhaite les filtrer
                int filtre = Menu.AfficherMenuProjets(); // L'entier renvoyé sera le type de filtre utilisé pour l'affichage des projets
                //Gérer cela avec des if
            }
        }

    }
}
