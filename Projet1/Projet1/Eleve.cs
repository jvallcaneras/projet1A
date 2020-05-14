using System;
using System.Collections.Generic;
using System.Text;

namespace Projet1
{
    class Eleve : Intervenant
    {
        //Attributs
        private string _nom;
        private string _prenom;
        private int _promo;
        private int _annee;

        //Acsesseurs
        public int Promo { get => _promo; set => _promo = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public int Annee{ get => _prenom; set => _prenom = value; }

        //Contructeur
        public Eleve(string nom, string prenom, int promo, int annee) : base("Eleve", 1)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Promo = promo;
            this.Annee = annee;
        }

        //Methodes
        public static Eleve CreerEtudiant()
        {
            Console.WriteLine("Indiquez le nom de l'élève");
            string nom = Console.ReadLine();
            Console.WriteLine("Indiquez le prenom de l'élève");
            string prenom = Console.ReadLine();
            Console.WriteLine("Indiquez la promotion de l'élève");
            int promo = int.Parse(Console.ReadLine());
            Console.WriteLine("Indiquez l'annee de l'élève (1, 2 ou 3 en fonction de son année)");
            int annee = int.Parse(Console.ReadLine());

            Eleve ele = new Eleve(nom, prenom, promo, annee);

            return (ele);

        }

    }

}