﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Projet1
{
    [Serializable]
    public class Eleve : Intervenant
    {
        //Attributs
        public string _nom;
        public string _prenom;
        private int _promo;
        private int _annee;

        //Acsesseurs
        public int Promo { get => _promo; set => _promo = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public int Annee{ get => _annee; set => _annee = value; }

        //Contructeur
        public Eleve(string nom, string prenom, int promo, int annee) : base("Eleve", 1)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Promo = promo;
            this.Annee = annee;
        }
 
        public Eleve() { }
        //Methodes
        public static Eleve CreerEtudiant()
        {
            Console.WriteLine("Indiquez le nom de l'élève");
            string nom = Console.ReadLine();
            nom = nom[0].ToString().ToUpper() + nom.Substring(1).ToLower();
            
            Console.WriteLine("Indiquez le prenom de l'élève");
            string prenom = Console.ReadLine();
            prenom = prenom[0].ToString().ToUpper() + prenom.Substring(1).ToLower();

            Console.WriteLine("Indiquez la promotion de l'élève");
            int promo = int.Parse(Console.ReadLine());
            Console.WriteLine("Indiquez l'annee de l'élève (1, 2 ou 3 en fonction de son année)");
            int annee = int.Parse(Console.ReadLine());

            Eleve ele = new Eleve(nom, prenom, promo, annee);

            return (ele);

        }

    }

}