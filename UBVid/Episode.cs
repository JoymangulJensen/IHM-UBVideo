using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBVid
{
    public class Episode
    {
        private int numero;
        private int saisonNumero;
        private DateTime dateDiffusion;
        private string synopsis;
        private bool diffuser;
        private string nom;
        private string nomSerie;
        
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="NomSerie">Nom de la serie</param>
        /// <param name="SaisonNumero">Numéro de la saison</param>
        /// <param name="Numero">Numéro de l'épisode</param>
        /// <param name="Nom">Nom de l'épisode</param>
        /// <param name="Diffuser">Diffuser</param>
        /// <param name="Synopsis">Synopsis</param>
        /// <param name="dd">Date de diffusion</param>
        public Episode(string NomSerie,int SaisonNumero,int Numero,string Nom,bool Diffuser,string Synopsis,DateTime dd)
        {
            nomSerie=NomSerie;
            saisonNumero=SaisonNumero;
            numero=Numero;
            nom=Nom;
            diffuser=Diffuser;
            synopsis=Synopsis;
            dateDiffusion = dd;
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public int SaisonNumero
        {
            get { return saisonNumero; }
            set { saisonNumero = value; }
        }
        public DateTime DateDiffusion
        {
            get { return dateDiffusion; }
            set { dateDiffusion = value; }
        }
        public string Synopsis
        {
            get { return synopsis; }
            set { synopsis = value; }
        }
        public bool Diffuser
        {
            get { return diffuser; }
            set { diffuser = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string NomSerie
        {
            get { return nomSerie; }
            set { nomSerie = value; }
        }
    }
}
