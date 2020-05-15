using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Exte : Intervenant
    {
        //Attributs
        public string _nom;
        public string _prenom;
        private string _entreprise;

        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Entreprise { get => _entreprise; set => _entreprise = value; }

        public Exte(string nom, string prenom, string entreprise) : base("Intervenant exterieur", 3)
        {
            Nom = nom;
            Prenom = prenom;
            Entreprise = entreprise;
        }

        public static Exte CreerExte()
        {
            Console.WriteLine("Indiquez le nom de l'intervenant exterieur");
            string nom = Console.ReadLine();
            Console.WriteLine("Indiquez le prenom de l'intervenant exterieur");
            string prenom = Console.ReadLine();
            Console.WriteLine("Indiquez l'entreprise, le lieu de travail ou le poste de l'intervenant");
            string entreprise = (Console.ReadLine());

            Exte exte = new Exte(nom, prenom, entreprise);

            return (exte);

        }

    }
}
