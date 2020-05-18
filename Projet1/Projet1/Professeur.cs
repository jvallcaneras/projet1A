using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    public class Professeur : Intervenant
    {
        //Attributs
        public string _nom;
        public string _prenom;
    
        //Accesseurs
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }

        //Constructeurs
        public Professeur(string nom, string prenom) : base("Professeur", 2)
        {
            Nom = nom;
            Prenom = prenom;
        }
        public Professeur() { }

        //Méthodes 
        public static Professeur CreerProfesseur()
        {
            Console.WriteLine("Indiquez le nom du professeur");
            string nom = Console.ReadLine();
            Console.WriteLine("Indiquez le prenom du professeur");
            string prenom = Console.ReadLine();

            Professeur prof = new Professeur(nom, prenom);

            return (prof);

        }
    }
}
