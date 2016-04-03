using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBVid
{
    public class Administrateur
    {
        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private string prenom;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private string courriel;

        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }

        private string motDePasse;

        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }

        private DateTime dateN;

        public DateTime DateN
        {
            get { return dateN; }
            set { dateN = value; }
        }

        private Image img;

        public Image Img
        {
            get { return img; }
            set { img = value; }
        }

        /// <summary>
        /// COnstructeur par défaut
        /// </summary>
        /// <param name="n">Nom</param>
        /// <param name="p"¨Prénom</param>
        /// <param name="c">Courriel</param>
        /// <param name="mdp">Mot De passe</param>
        /// <param name="dN">Date de naissance</param>
        /// <param name="im">Image</param>
        public Administrateur(string n, string p, string c, string mdp, DateTime dN, Image im)
        {
            this.Nom = n;
            this.Prenom = p;
            this.Courriel = c;
            this.MotDePasse = mdp;
            this.DateN = dN;
            this.Img = im;
        }
    }
}
