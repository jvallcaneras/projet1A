﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet1
{
    class XML
    {



    public static void CreationXML() //Intervenant, Livrables, Matieres, Roles et Projet
        {
            //Creation liste XML matières
            Matiere m1 = new Matiere("Anglais", 1);
            Matiere m2 = new Matiere("Mathématiques", 2);
            Matiere m3 = new Matiere("Programmation", 3);

            List<Matiere> matiere = new List<Matiere>();
            matiere.Add(m1);
            matiere.Add(m2);
            matiere.Add(m3);

            XmlSerializer xb = new XmlSerializer(typeof(List<Matiere>));
            using (StreamWriter wb = new StreamWriter("matieres.xml"))
            {
                xb.Serialize(wb, matiere);
            }

            //Creation liste XML livrables
            Livrable l1 = new Livrable("Rapport", 1, "");
            Livrable l2 = new Livrable("Soutenance", 2, "");
            Livrable l3 = new Livrable("Planning", 3, "");

            List<Livrable> livrable = new List<Livrable>();
            livrable.Add(l1);
            livrable.Add(l2);
            livrable.Add(l3);

            XmlSerializer xa = new XmlSerializer(typeof(List<Livrable>));
            using (StreamWriter wa = new StreamWriter("livrables.xml"))
            {
                xa.Serialize(wa, livrable);
            }

            //Creation liste XML intervenants
            Intervenant i1 = new Intervenant("Eleve", 1);
            Intervenant i2 = new Intervenant("Professeur", 2);
            Intervenant i3 = new Intervenant("Intervenant Exterieur", 3);

            List<Intervenant> intervenant = new List<Intervenant>();
            intervenant.Add(i1);
            intervenant.Add(i2);
            intervenant.Add(i3);

            XmlSerializer xs = new XmlSerializer(typeof(List<Intervenant>));
            using (StreamWriter wr = new StreamWriter("intervenants.xml"))
            {
                xs.Serialize(wr, intervenant);
            }

            //Creation liste XML roles
            Role r1 = new Role("Evaluateur", 1);
            Role r2 = new Role("Evalué", 2);
            Role r3 = new Role("Client", 3);
            Role r4 = new Role("Chef de projet", 4);
            Role r5 = new Role("Fabricant", 5);

            List<Role> role = new List<Role>();
            role.Add(r1);
            role.Add(r2);
            role.Add(r3);
            role.Add(r4);
            role.Add(r5);

            XmlSerializer xy = new XmlSerializer(typeof(List<Role>));
            using (StreamWriter ws = new StreamWriter("roles.xml"))
            {
                xy.Serialize(ws, role);
            }

            //Creation liste XML projets

            Projet p1 = new Projet(1, "Test1", 1, 12, matiere, livrable, intervenant, role);
            Projet p2 = new Projet(2, "Test2", 2, 12, matiere, livrable, intervenant, role);

            List<Projet> projet = new List<Projet>();
            projet.Add(p1);
            projet.Add(p2);

            XmlSerializer xc = new XmlSerializer(typeof(List<Projet>));
            using (StreamWriter wc = new StreamWriter("projets.xml"))
            {
                xc.Serialize(wc, projet);
            }

        }
    }
}