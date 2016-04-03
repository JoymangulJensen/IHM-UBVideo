using MetroFramework;
using MetroFramework.Controls;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBVid
{
    class moteurAdmin
    {
        public moteurAdmin() { }

        /*
         * Methode pou générer un mot de passe aléatoire
         * La méthode prend en paramètre la taile de passe
         */
        public string CreeePassword(int taille)
        {
            string res = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[taille];
            for (int i = 0; i < taille; i++)
            {
                chars[i] = res[(int)((res.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }



        /*
         * Methode pour retourner le numéro d'une saison
         * c'est à dire le nombre de saison que comporte une saison 
         * la méthode prend en parametre OracleConnection pour faire des requete sur la base de donnée
         * et elle prend aussi le nom de la série 
         */
        public int numSaison(OracleConnection con, string nomSerie)
        {
                string requete = "SELECT COUNT(*) FROM IHM_SAISON WHERE NOMSERIE='" + nomSerie + "'";
                OracleCommand command = new OracleCommand(requete, con);
                string resS = command.ExecuteScalar().ToString();
                int res = Int32.Parse(resS);
                return res;
        }

        /*
         * Méthode pour retourner le nombre d'épisode que contient une saison
         * par exemple si une saison a " épisode alors la méthode va retourner 4
         * la méthode prend en paramètre OracleConnection pour faire des requete sur la base de donnéee
         */
        public int numEpisode(OracleConnection con, string nomSerie, string nbSaison)
        {
            string requete = "SELECT COUNT(*) FROM IHM_EPISODE WHERE NOMSERIE='" + nomSerie + "'"+
                "AND SAISONNUMERO='"+nbSaison+"'" ;
            OracleCommand command = new OracleCommand(requete, con);
            object o = command.ExecuteScalar();
            string resS = o.ToString();
            int res = Int32.Parse(resS);
            res++;
            return res;
            
        }

        /*
         * Methode pour construire une serie en passant le nom de la serie en parametre
         */
        public Serie getSerie(OracleConnection con, string nomSerie)
        {
            string requete = "SELECT req.*, IHM_SERIE.IMAGE " +
                            "FROM ( " +
                            "SELECT IHM_SERIE.NOM, IHM_SERIE.SYNOPSIS, IHM_SERIE.ENPRODUCTION, IHM_SERIE.NATIONALITE, IHM_SERIE.GENRE, IHM_SERIE.CASTING, IHM_SERIE.CREER_PAR, COUNT(IHM_SAISON.NUMERO) AS NBSAISON " +
                            "FROM IHM_SERIE LEFT JOIN IHM_SAISON ON IHM_SERIE.NOM = IHM_SAISON.NOMSERIE " +
                            "WHERE IHM_SERIE.NOM = '" + nomSerie + "' " +
                            "GROUP BY IHM_SERIE.NOM, IHM_SERIE.SYNOPSIS, IHM_SERIE.GENRE, IHM_SERIE.ENPRODUCTION, IHM_SERIE.NATIONALITE, IHM_SERIE.CASTING, IHM_SERIE.CREER_PAR " +
                            ") req " +
                            "INNER JOIN IHM_SERIE ON IHM_SERIE.NOM = req.NOM";

            OracleCommand command = new OracleCommand(requete, con);
            OracleDataReader reader = command.ExecuteReader();

            string Nom = "";
            string Synopsis = "";
            string Genre = "";
            string EnProductionINT = "";
            string Nationalite = "";
            string Casting = "";
            Image img = null;
            string CreerPar = "";
            string nbS = "";
            

            //récupération des données de la requête
            while (reader.Read())
            {
                Nom = reader["NOM"].ToString().Trim();
                Synopsis = reader["SYNOPSIS"].ToString().Trim();
                Genre = reader["GENRE"].ToString().Trim();
                EnProductionINT = reader["ENPRODUCTION"].ToString().Trim();
                Nationalite = reader["NATIONALITE"].ToString().Trim();
                Casting = reader["CASTING"].ToString().Trim();
                CreerPar = reader["CREER_PAR"].ToString().Trim();
                nbS = reader["NBSAISON"].ToString().Trim();

                img = null;

                if (reader["IMAGE"] != DBNull.Value)
                {
                    byte[] blob = (byte[])reader["IMAGE"];
                    FileStream FS = new FileStream("image.jpg", FileMode.Create);
                    FS.Write(blob, 0, blob.Length);
                    img = Image.FromStream(FS);
                    img.Save("output", ImageFormat.Png);
                    FS.Close();
                    
                }
            }
            reader.Close();

            command.Dispose();
            Serie res = new Serie(Nom, Synopsis, Genre, EnProductionINT, Nationalite, Casting, img, CreerPar, nbS);
            return res;
        }


        /// <summary>
        /// Méthode pour recherhcer un épisode
        /// </summary>
        /// <param name="con">COnnection pour la base de données</param>
        /// <param name="nS">Nom de la série</param>
        /// <param name="nSaison">Numéro de la saison</param>
        /// <param name="num">NUméro de l'épisode</param>
        /// <returns>L'épisode trouvé</returns>
        public Episode getEpisode(OracleConnection con, string nS, string nSaison, string num)
        {
            string requete = "SELECT * FROM IHM_EPISODE " +
               "WHERE NOMSERIE='" + nS + "' AND SAISONNUMERO='" + nSaison + "' AND" +
               " NUMERO='" + num + "'";

            OracleCommand command = new OracleCommand(requete, con);
            OracleDataReader reader = command.ExecuteReader();

            int numero=0;
            int saisonNumero=0;
            DateTime dateDiffusion = new DateTime(12/12/12);
            string synopsis="";
            bool diffuser=false;
            string nom="";
            string nomSerie="";


            //récupération des données de la requête
            while (reader.Read())
            {
                numero = int.Parse(reader["NUMERO"].ToString().Trim());
                saisonNumero = int.Parse(reader["SAISONNUMERO"].ToString().Trim());
                synopsis = reader["SYNOPSIS"].ToString().Trim();
                nom = reader["NOM"].ToString().Trim();
                nomSerie = reader["NOMSERIE"].ToString().Trim();
                dateDiffusion = Convert.ToDateTime(reader["DATEDIFFUSION"].ToString().Trim());
                string diff = reader["DIFFUSER"].ToString().Trim();
                if (diff == "0")
                    diffuser = false;
                else
                    diffuser = true;

            }
            reader.Close();

            command.Dispose();
            Episode res = new Episode(nomSerie, saisonNumero, numero, nom, diffuser, synopsis, dateDiffusion);
            return res;
        }
        
        /*
         * Methode qui genère la requete pour ajouter une saison à la base de donnée
         */
        public string ajouterSaison(string nomSerie, string numero, string enproduction)
        {
            string requete;
            requete = "insert into IHM_SAISON(NOMSERIE,NUMERO,ENPRODUCTION)"+
            "values('" + nomSerie + "'," +
                "'" + numero + "'," +
                "'" + enproduction + "')";
            return requete;
        }

        //Méthode pour generer une requete pour ajouter un episode
        public string ajouterEpisode(string  nomSerie, string dateD, string numeroE, string syn, string nomEp, string diffuser, string numSaison)
        {
            string requete;
            requete = "insert into IHM_EPISODE(NUMERO,DATEDIFFUSION,SYNOPSIS,DIFFUSER,NOM,NOMSERIE,SAISONNUMERO)" +
            "values('" + numeroE + "'," +
                "'" + dateD + "'," +
                "'" + syn + "'," +
                "'" + diffuser + "'," +
                "'" + nomEp + "'," +
                "'" + nomSerie + "'," +
                "'" + numSaison + "')";
            return requete;
        }

        //Méthode pour générer une requete pour ajouter un administrateur
        public string ajouterAdmin(string nom, string prenom, string dateN, string courriel, string motDPass)
        {
            string requete;
            requete = "insert into IHM_ADMINISTRATEUR(NOM,PRENOM,DATEN,COURRIEL,PASSWORD,IMAGE)";
            requete += "values('" + nom + "'," +
                        "'" + prenom + "'," +
                        "'" + dateN + "'," +
                        "'" + courriel + "'," +
                        "'" + motDPass + "'," +
                        " :BlobParameter )";
            return requete;
        }

        /// <summary>
        /// Méthode qui reoturne une requete pour modifier une série
        /// </summary>
        /// <param name="nomserie">Nom de la série</param>
        /// <param name="synopsis">Synopsis</param>
        /// <param name="genre">Genre</param>
        /// <param name="prod">Prodction</param>
        /// <param name="pays">Pays</param>
        /// <param name="casting">Casting</param>
        /// <param name="creer"Créée par></param>
        /// <returns></returns>
        public string modifSerie(string nomserie, string synopsis, string genre, string prod, string pays, string casting, string creer)
        {
            string requete;
                        requete = "UPDATE IHM_SERIE ";
                        requete += "SET SYNOPSIS ='"+synopsis +"',"+
                            "GENRE ='" + genre +"',"+
                            "ENPRODUCTION ='" + prod +"',"+
                            "NATIONALITE ='" +pays +"',"+
                            "CASTING ='" + casting +"',"+
                            "CREER_PAR ='" +creer +"', "+
                            "IMAGE = :BlobParameter  "+
                            "WHERE NOM ='"+nomserie +"'";
                        return requete;
        }

        /// <summary>
        /// Méthode qui retourne la requête pour modifier un épisode
        /// </summary>
        /// <param name="nomserie">Nom de la série</param>
        /// <param name="numSaison">Numéro de la saison</param>
        /// <param name="numero">Numéro de l'épisode</param>
        /// <param name="nom">nom de l'épisode</param>
        /// <param name="dateD">date de diffusion</param>
        /// <param name="diffuser">si l'épisode a été diffuser</param>
        /// <param name="synopsis">synopsis</param>
        /// <returns></returns>
        public string modifEpisode(string nomserie, string numSaison, string numero, string nom, string dateD, string diffuser, string synopsis)
        {
            string requete;
            requete = "UPDATE IHM_EPISODE ";
            requete += "SET DATEDIFFUSION ='" + dateD + "'," +
                "SYNOPSIS ='" + synopsis + "'," +
                "DIFFUSER ='" + diffuser + "'," +
                "NOM ='" + nom + "' " +
                "WHERE NOMSERIE ='" + nomserie + "' AND "+
                "SAISONNUMERO ='" + numSaison + "' AND "+
                "NUMERO =" +numero ;
            return requete;
        }
    }
}
