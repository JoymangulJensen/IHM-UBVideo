using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBVid
{
    public class Serie
    {
        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private string synopsis;

        public string Synopsis
        {
            get { return synopsis; }
            set { synopsis = value; }
        }
        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        private bool enProduction;

        public bool EnProduction
        {
            get { return enProduction; }
            set { enProduction = value; }
        }

        public string EnProductionINT
        {
            get
            {
                if (this.enProduction)
                    return "1";
                else
                    return "0";
            }
            set
            {
                if (value == "1")
                    EnProduction = true;
                else
                    EnProduction = false;
            }
        }

        private string nationalite;

        public string Nationalite
        {
            get { return nationalite; }
            set { nationalite = value; }
        }
        private string casting;

        public string Casting
        {
            get { return casting; }
            set { casting = value; }
        }
        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        private string creerPar;

        public string CreerPar
        {
            get { return creerPar; }
            set { creerPar = value; }
        }

        private string nbSaison;

        public string NbSaison
        {
            get { return nbSaison; }
            set { nbSaison = value; }
        }

        public Serie(String n, string syn, string g, string prod, string nat, string c, Image i, string cP, string nbS)
        {
            this.Nom = n;
            this.Synopsis = syn;
            this.Genre = g;
            this.EnProductionINT = prod;
            this.Nationalite = nat;
            this.Casting = c;
            this.Image = i;
            this.CreerPar = cP;
            this.NbSaison = nbS;
        }

        public Serie()
        {
            this.Nom = "";
            this.Synopsis = "";
            this.Genre = "";
            this.EnProductionINT = "";
            this.Nationalite = "";
            this.Casting = "";
            this.Image = null;
            this.CreerPar = "";
            this.NbSaison = "";
        }
    }
}
