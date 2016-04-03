using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBVid
{
    public class Utilisateur
    {
        private string courriel;
        private string password;
        private DateTime dateCreation;
        private string nom;
        private string prenom;
        private string preference;
        private DateTime dateN;
        private Image image;

        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; }
        }

        public DateTime DateN
        {
            get { return dateN; }
            set { dateN = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Preference
        {
            get { return preference; }
            set { preference = value; }
        }

        /// <summary>
        /// Constructeur par défaut pour un utilisateur
        /// </summary>
        /// <param name="c">courriel</param>
        /// <param name="mdp">Mot de passe</param>
        /// <param name="nom">Nom</param>
        /// <param name="prenom">Prénom</param>
        /// <param name="dC">Date de création</param>
        /// <param name="dN">Date de Naissance</param>
        /// <param name="p">Préférence</param>
        /// <param name="img">Image</param>
        public Utilisateur(string c, string p, string n, string pr, DateTime dc, DateTime dn, Image i)
        {
            courriel = c;
            password = p;
            nom = n;
            prenom = pr;
            dateCreation = dc;
            dateN = dn;
            image = i;
        }

        public Utilisateur(string c, string p, string n, string pr, DateTime dc, DateTime dn, string preference, Image i)
        {
            courriel = c;
            password = p;
            nom = n;
            prenom = pr;
            dateCreation = dc;
            dateN = dn;
            image = i;
        }



    }
}
