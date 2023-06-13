using System;

namespace MyApp.Models
{
    public class Article
    {
        // Attributs privés
        private int reference;

        private string nom;
        private double prix;
        private int qt;

        // Propriétés publiques

        public int Reference
        {
            get { return reference; }
            set { reference = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }



        public int Qt
        {
            get { return qt; }
            set { qt = value; }
        }

        // Constructeur d'initialisation
        public Article(int reference, string nom, double prix, int qt)
        {
            this.reference = reference;
            this.nom = nom;
            this.prix = prix;
            this.qt = qt;
        }

        public Article()
        {
        }

        // Méthode ToString pour afficher les informations de l'article
        public override string ToString()
        {
            return $"reference: {reference}\nNom: {nom}\nPrix: {prix}\nQuantité : {qt}";
        }
    }



}
