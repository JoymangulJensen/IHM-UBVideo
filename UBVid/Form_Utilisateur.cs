using MetroFramework.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using MetroFramework;
using Oracle.DataAccess.Types;


namespace UBVid
{

    public partial class Form_Utilisateur : MetroForm
    {
        //attribut pour la connection à la BDD
        private OracleConnection con;
        private DbProviderFactory dbpf;
        private DbDataAdapter oDA;
        private DataSet oDS;

        Utilisateur utilisateur;
        Serie serieSelection;
        Episode episodeSelection;

        //liste des composants stockés pour pouvoir les supprimer
        List<Panel> controlStock = new List<Panel>();
        List<Label> controlStockFiche = new List<Label>();

        
        public Form_Utilisateur(OracleConnection c, DbProviderFactory d, string uti)
        {
            InitializeComponent();

            //recupère l'accès à la BDD
            con = c;
            dbpf = d;
            
            //construit l'utilisateur qui utilise l'interface
            utilisateur = getUtilisateur(uti);
            //met à jour les données de l'utilisateur dans l'onglet donnée
            initDoneeUtilisateur();


            //place le panel à la bonne position
            ficheSeriePanel.Location=new System.Drawing.Point(0,0);
            
            //rendre invisible les composants ayant un rapport avec la fiche série et la fiche épisode
            ficheSeriePanel.Visible = false;
            ficheEpisodePanel.Visible = false;
            noteRendreVisible(false);
            suiviButtonVisible(false);

            //initialisation des comboBox
            foreach (var gen in Enum.GetValues(typeof(Genre)))
            {
                genreCombo.Items.Add(gen);
            }
            genreCombo.SelectedItem = "aucun";

            ordreApparitionCombo.Items.Add("par note");
            ordreApparitionCombo.Items.Add("ordre alphabetique");
            ordreApparitionCombo.SelectedItem = "ordre alphabetique";

            //initialise l'affichage de la liste des série qui existe dans la BDD
            InitListeSerie();

            //initialise la dataGrid pour afficher les épisodes des séries suivies par l'utilisateur qui seront diffusés
            initGrille();
        }



        /* 
         * =========================================================================================================
         * gestion de la liste des séries
         * =========================================================================================================
        */
        //méthode qui ajoute dynamiquement des panels cliquable de la liste des séries
        public void InitListeSerie()
        {
            //requete pour récuperer la table des série existante en fonction du genre demandé trié alphabétiquement
            string requete = "select * from IHM_SERIE";
            if (genreCombo.SelectedItem.ToString() != "aucun") requete += " WHERE GENRE='" + genreCombo.SelectedItem.ToString() + "'";
            requete += " ORDER BY NOM ASC";

            //l'opération prend du temps, on modifie le curseur pendant ce temps
            this.Cursor = Cursors.No;

            try
            {
                oDA = dbpf.CreateDataAdapter();
                oDA.SelectCommand = con.CreateCommand();
                oDA.SelectCommand.CommandText = requete;
                oDS = new DataSet();
                oDA.Fill(oDS, "SERIE");
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }

            //on efface les panels sur le panel
            nettoyerListePanel();
            

            //initialisation de la liste de couple série et moyenne note
            List<SerieMoyenne> listeSerieMoyenne = new List<SerieMoyenne>();
            int n = nbSerie(genreCombo.SelectedItem.ToString());
            for (int i = 0; i < n; i++)
            {
                Serie s = new Serie();
                s.Nom = oDS.Tables[0].Rows[i]["NOM"].ToString();
                s.Synopsis = oDS.Tables[0].Rows[i]["SYNOPSIS"].ToString();
                if (oDS.Tables[0].Rows[i]["IMAGE"] != DBNull.Value)
                {
                    byte[] blob = (byte[])oDS.Tables[0].Rows[i]["IMAGE"];
                    FileStream FS = new FileStream("image.jpg", FileMode.Create);
                    FS.Write(blob, 0, blob.Length);
                    Image img = Image.FromStream(FS);
                    FS.Dispose();
                    FS.Close();
                    FS = null;
                    s.Image = img;
                }
                double moyenne;
                if (serieDejaNotee(s.Nom)) moyenne = 1.0*sommeNoteSerie(s.Nom)/sommeNoteUtilisateur(s.Nom);
                else moyenne = -1;//moyenne négative pour les séries qui ne sont pas notée, pour qu'elle se retrouve en bas de la liste
                listeSerieMoyenne.Add(new SerieMoyenne(s,moyenne));
            }

            //si besoin, tri de la liste en fonction des notes par ordre décroissant
            if(ordreApparitionCombo.SelectedItem == "par note") listeSerieMoyenne.Sort();


            //on ajoute les panels en fonction de la liste
            int height = listeSeriePanel.Size.Height;
            int width = listeSeriePanel.Size.Width;
            int j=0;
            foreach (SerieMoyenne sm in listeSerieMoyenne)
            {
                int hp = height / 3; //hauteur du conteneur principal
                int wp = width; //largeur du conteneur principal
                int ht = hp / 5; //hauteur titre
                int hi = hp - ht; //hauteur image
                int wi = hi; //largeur image
                int hs = hp / 2; //hauteur textBox contenant la synopisie
                int ws = wp - wi -20 ;//largeur textBox contenant la synopisie
                int hlm = (hp - ht - hs)/2; //hauteur label moyenne note
                int wlm = (wp - wi) / 3; //largeur label moyenne note
                int hbm = hlm; //hauteur barre moyenne note
                int wbm = 102;  //largeur barre moyenne note

                string nomSerie = sm.Serie.Nom;
                //un conteneur p
                Panel p = new Panel();
                p.Name = nomSerie;
                controlStock.Add(p);
                p.Size = new System.Drawing.Size(wp, hp);
                p.Location = new System.Drawing.Point(0, j * hp + j * 20);
                p.BackColor = Color.FromArgb(10, 10, 10);
                listeSeriePanel.Controls.Add(p);
                //titre de la serie
                Label titre = new Label();
                titre.Name = nomSerie;
                titre.Text = nomSerie;
                titre.Size = new System.Drawing.Size(width, ht);
                titre.ForeColor = Color.Black;
                titre.BackColor = Color.FromArgb(243, 119, 53);
                p.Controls.Add(titre);
                //image de la serie
                PictureBox im = new PictureBox();
                im.Name = nomSerie;
                im.Text = nomSerie;
                im.Location = new System.Drawing.Point(0, ht);
                im.Size = new System.Drawing.Size(wi, hi);
                p.Controls.Add(im);
                if (sm.Serie.Image!=null)
                {
                    im.Image = sm.Serie.Image;
                    im.SizeMode = PictureBoxSizeMode.Zoom;
                }
                //synopsie de la série
                TextBox synopsie = new TextBox();
                synopsie.Name = nomSerie;
                if (sm.Serie.Synopsis.Length > 90) synopsie.Text = sm.Serie.Synopsis.Substring(0, 90) + "......";
                else synopsie.Text = sm.Serie.Synopsis;
                synopsie.Location = new System.Drawing.Point(wi, ht);
                synopsie.Size = new System.Drawing.Size(ws, hs);
                synopsie.Multiline = true;
                synopsie.Enabled = false;
                synopsie.BackColor = Color.FromArgb(10, 10, 10);
                synopsie.ForeColor = Color.White;
                synopsie.BorderStyle = System.Windows.Forms.BorderStyle.None;
                p.Controls.Add(synopsie);
                //label de la moyenne des notes
                Label labelM = new Label();
                labelM.Name = nomSerie;
                if (sm.Moyenne >= 0) labelM.Text = "note : " + sm.Moyenne;
                else labelM.Text = "pas notée";
                labelM.Location = new System.Drawing.Point(wi + wbm + 50, ht + hs);
                labelM.Size = new System.Drawing.Size(wlm, hlm);
                labelM.ForeColor = Color.FromArgb(243, 119, 53);
                labelM.BackColor = Color.FromArgb(10, 10, 10);
                p.Controls.Add(labelM);
                //barre qui represente la note
                if (sm.Moyenne >= 0)
                {
                    int bordure = 1;
                    int hbmT = hbm - 2 * bordure;
                    int wbmT = wbm - 2 * bordure;
                    int wbm1 = Convert.ToInt32( wbmT * sm.Moyenne/5);

                    Panel bm1 = new Panel();
                    bm1.Name = nomSerie;
                    controlStock.Add(p);
                    bm1.Location = new System.Drawing.Point(wi + 50 + bordure, ht + hs + bordure);
                    bm1.Size = new System.Drawing.Size(wbm1, hbmT);
                    bm1.BackColor = Color.FromArgb(243, 119, 53);
                    p.Controls.Add(bm1);

                    Panel bmT = new Panel();
                    bmT.Name = nomSerie;
                    controlStock.Add(p);
                    bmT.Location = new System.Drawing.Point(wi + 50 + bordure, ht + hs + bordure);
                    bmT.Size = new System.Drawing.Size(wbmT, hbmT);
                    bmT.BackColor = Color.FromArgb(17, 17, 17);
                    p.Controls.Add(bmT);

                    Panel bm = new Panel();
                    bm.Name = nomSerie;
                    controlStock.Add(p);
                    bm.Location = new System.Drawing.Point(wi + 50, ht + hs);
                    bm.Size = new System.Drawing.Size(wbm, hbm);
                    bm.BackColor = Color.White;
                    p.Controls.Add(bm);

                    bm.Click += new System.EventHandler(ClickSerieSelection);
                    bm1.Click += new System.EventHandler(ClickSerieSelection);
                    bmT.Click += new System.EventHandler(ClickSerieSelection);
                }

                //evenement click, fait appel à le même fonction pour tout les composants
                p.Click += new System.EventHandler(ClickSerieSelection);
                titre.Click += new System.EventHandler(ClickSerieSelection);
                im.Click += new System.EventHandler(ClickSerieSelection);
                synopsie.Click += new System.EventHandler(ClickSerieSelection);
                labelM.Click += new System.EventHandler(ClickSerieSelection);
                this.Cursor = Cursors.Default;

                //cursor se transforme en main quand la sourie survole le panel
                p.Cursor = Cursors.Hand;

                j++;
            }              
        }


        //fonction appelée avec l'évenement click sur les panels et leurs composants génerés dynamiquement
        public void ClickSerieSelection(object sender, System.EventArgs e)
        {
            //on récupère le nom du composant
            //un panel et ses composants ont tous le nom de la série qu'ils représentent
            String nom = "";
            string senderType = sender.GetType().ToString();
            if (senderType.Equals("System.Windows.Forms.Panel"))
            {
                Panel tmp = sender as Panel;
                nom = tmp.Name;
            }
            if (senderType.Equals("System.Windows.Forms.Label"))
            {
                Label tmp = sender as Label;
                nom = tmp.Name;
            }
            if (senderType.Equals("System.Windows.Forms.PictureBox"))
            {
                PictureBox tmp = sender as PictureBox;
                nom = tmp.Name;
            }
            if (senderType.Equals("System.Windows.Forms.TextBox"))
            {
                TextBox tmp = sender as TextBox;
                nom = tmp.Name;
            }
            //on nettoie le panel fichePanel en suppriment ou en cachant ses composants
            nettoyerFichePanel(true);
            //mise à jour de l'instance serieSelection
            serieSelection = getSerie(nom);
            //mise à jour des information concernant la série selectionnée dans le panel fichePanel
            initFicheSerie();

            //rendre visible le panel fichePanel contenant les info de la série
            ficheSeriePanel.Visible = true;
            //rendre visible les controls pour atribuer une note ou suivre une série
            noteRendreVisible(true);
            suiviButtonVisible(true);
        }

        //atribut au composant du panel ficheSeriePanel la valeur des atributs de l'instance serieSelection
        public void initFicheSerie()
        {
            titre.Text = serieSelection.Nom;
            synopsieSerieTextBox.Text = serieSelection.Synopsis;
            imageSeriePictureBox.Image = serieSelection.Image;
            imageSeriePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (serieSelection.EnProduction) productionSerieLabel.Text = "série en production";
            else productionSerieLabel.Text = "série achevée";
            genreSerieLabel.Text = "genre : " + serieSelection.Genre;
            realisationSerieLabel.Text = "réalisée par : " + serieSelection.CreerPar;
            castingSerieLabel.Text = "casting : " + serieSelection.Casting;
            initArborescenceSerieEpisode(serieSelection.Nom);
        }

        //retourne le nombre de série stocké dans la BDD
        public int nbSerie(string genre)
        {
            string requete;
            if(genre != "aucun") requete = "SELECT COUNT(*) FROM IHM_SERIE WHERE GENRE='" + genre + "'";
            else requete = "SELECT COUNT(*) FROM IHM_SERIE";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            return res;
        }


        //retourne true si une série de nom nomS est déjà notée autrement false
        public bool serieDejaNotee(string nomS)
        {
            bool b = false;
            string requete = "SELECT count(*) FROM IHM_NOTATION WHERE NOMSERIE='" + nomS + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            if (res > 0) b = true;
            return b;
        }

        //retourne le nombre de note attribué pour une série de nom nomS
        public int sommeNoteUtilisateur(string nomS)
        {
            bool b = false;
            string requete = "SELECT count(*) FROM IHM_NOTATION WHERE NOMSERIE='" + nomS + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            return res;
        }

        //retourne la somme cumulée de toutes les notes attribué à une série de nom nomS
        public int sommeNoteSerie(string nomS)
        {
            string requete = "SELECT SUM(NOTE) FROM IHM_NOTATION WHERE NOMSERIE='" + nomS + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            return res;
        }

        //on initialise la liste des séries si l'utilisateur change l'ordre d'affichage
        private void ordreApparitionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nettoyerListePanel();
            InitListeSerie();
        }

        //on initialise la liste des séries si l'utilisateur choisit d'afficher les série d'un seul genre
        private void genreCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nettoyerListePanel();
            InitListeSerie();
        }

        
        /* 
         * =========================================================================================================
         * Initialisation de l'arborescence de la liste saison et episode d'une serie séléctionnée
         * =========================================================================================================
        */
        //génère une arborescence composé de label pour une série sélectionée
        //le 1er niveaux représente la sason et le deuxième les épisodes pour cette saison
        public void initArborescenceSerieEpisode(string nomSerie)
        {
            int h = 400;
            int hp = 30;
            int nSaison = nbSaison(nomSerie);
            for(int i=1;i<=nSaison;i++)
            {
                Label ls=new Label();
                controlStockFiche.Add(ls);
                ls.Text="saison "+ i;
                ls.AutoSize = true;
                ls.ForeColor = Color.Black;
                ls.BackColor = Color.FromArgb(243, 119, 53);
                ls.Location=new System.Drawing.Point(0,h);
                fichePanel.Controls.Add(ls);
                h += hp;

                int nEpisode = nbEpisode(nomSerie, ""+i);
                for(int j=1;j<=nEpisode;j++)
                {
                    Label le = new Label();
                    controlStockFiche.Add(le);
                    le.Text = "episode " + j;
                    if ((j + 1) < 10) le.Name = i + "0" + j;
                    else le.Name = i + "" + j;
                    le.AutoSize = true;
                    le.ForeColor = Color.White;
                    le.BackColor = Color.FromArgb(17, 17, 17);
                    le.Location = new System.Drawing.Point(30, h);
                    fichePanel.Controls.Add(le);
                    le.MouseMove += new System.Windows.Forms.MouseEventHandler(changementCouleurLabel);
                    le.MouseLeave += new System.EventHandler(reChangementCouleurLabel);
                    le.Click += new System.EventHandler(clickSelectionEpisode);
                    h += hp;
                }
            }

        }

        //Méthode pour retourner le nombre total de saison d'une série
        public int nbSaison(string nomSerie)
        {
            string requete = "SELECT COUNT(*) FROM IHM_SAISON WHERE NOMSERIE='" + nomSerie + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            return res;
        }

        // Méthode pour retourner le nombre d'épisode que contient une saison
        public int nbEpisode(string nomSerie, string nbSaison)
        {
            string requete = "SELECT COUNT(*) FROM IHM_EPISODE WHERE NOMSERIE='" + nomSerie + "'" +
                "AND SAISONNUMERO='" + nbSaison + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            return res;
        }

        //l'utilisateur a cliqué sur le label d'un épisode,, affichage de la fiche episode
        public void clickSelectionEpisode(object sender, System.EventArgs e)
        {
            nettoyerFichePanel(false);
            Label tmp = sender as Label;
            int sep = Int32.Parse(tmp.Name);
            int ep = sep % 100;
            int s = sep / 100;
            episodeSelection = getEpisode(serieSelection.Nom, s, ep);
            initFicheEpisode();
        }

        //méthode afficher le panel ficheEpisode contenant les information sur un épisode sélectionné
        public void initFicheEpisode()
        {
            ficheEpisodePanel.Visible = true;
            titreEpisodeLabel.Text = episodeSelection.NomSerie + " saison " + episodeSelection.SaisonNumero + " episode " + episodeSelection.Numero;
            synopsisEpisodeTextBox.Text = episodeSelection.Synopsis;
            nomEpisodeLabel.Text = "tire de l'épisode : " + episodeSelection.Nom;
            if (episodeSelection.Diffuser) diffusionEpisodeLabel.Text = "déjà diffusé";
            else diffusionEpisodeLabel.Text = "pas encore diffusé";
            dateEpisodeLabel.Text = "date de diffusion : " + episodeSelection.DateDiffusion.Day + "/" + episodeSelection.DateDiffusion.Month + "/" + episodeSelection.DateDiffusion.Year;
        }


        //l'utilisateur a cliqué sur le bouton retour, il passe de la fiche épisode à la fiche série
        private void retourButton_Click(object sender, EventArgs e)
        {
            episodeSelection = null;
            ficheEpisodePanel.Visible = false;
            initFicheSerie();
            ficheSeriePanel.Visible = true;
        }

        //quand la sourie passe sur le label d'un episode, le fond du label devient noir
        public void changementCouleurLabel(object sender, System.EventArgs e)
        {
            Label tmp = sender as Label;
            tmp.BackColor = Color.Black;
        }
        //quand la sourie n'est plus sur le label, retour à la couleur d'origine
        public void reChangementCouleurLabel(object sender, System.EventArgs e)
        {
            Label tmp = sender as Label;
            tmp.BackColor = Color.FromArgb(17, 17, 17);
        }


        /* 
         * =========================================================================================================
         * methode pour nettoyer et initialiser les deux panels
         * =========================================================================================================
        */
        public void nettoyerListePanel()
        {
            //on replace le scroll en haut
            listeSeriePanel.VerticalScroll.Value = 0;
            //on supprime la listes des composants stocké
            foreach (Panel p in controlStock)
            {
                p.Dispose();
            }
            //on initialise la liste des composants
            controlStock = new List<Panel>();
        }

        public void nettoyerFichePanel(bool serieSelectionNull)
        {
            //on replace le scroll en haut
            fichePanel.VerticalScroll.Value = 0;
            //on supprime la listes des labels stocké
            foreach(Label l in controlStockFiche)
            {
                l.Dispose();
            }
            //on initialise la liste des composants
            controlStockFiche = new List<Label>();
            //on cache les panels fiche qui serait affiché
            ficheEpisodePanel.Visible = false;
            ficheSeriePanel.Visible = false;
            //on cache les composants pour suivre et noter une série
            noteRendreVisible(false);
            suiviButtonVisible(false);
            //on met à null l'instance de serieSelection en fonction du boolean rentré
            if (serieSelectionNull) serieSelection = null;
            episodeSelection = null;
        }

        //évenement click sur le bouton pour réinitialiser, on lance les deux méthode pour nettoyer
        private void reInit_Click(object sender, EventArgs e)
        {
            InitListeSerie();
            nettoyerFichePanel(true);
        }


        /* 
         * =========================================================================================================
         * Methodes pour construire une serie ou une saison
         * =========================================================================================================
        */
        //retourne une instance Episode en récupérent l'épisode dans la BDD
        public Episode getEpisode(string nomSerie,int nSaison,int nEpisode)
        {
            
            
            string requete =      "SELECT NOM,DATEDIFFUSION,DIFFUSER,SYNOPSIS"
                                + " FROM IHM_EPISODE"
                                + " WHERE NOMSERIE='" + nomSerie + "'"
                                + " AND SAISONNUMERO='" + nSaison + "'"
                                + " AND NUMERO='" + nEpisode + "'";

            OracleCommand command = new OracleCommand(requete, con);
            OracleDataReader reader = command.ExecuteReader();

            DateTime dateDiffusion = DateTime.Parse("01/01/00 00:00:00"); 
            string synopsis="";
            bool diffuser=false;
            string nom="";

             while (reader.Read())
             {
                 nom = reader["NOM"].ToString().Trim();
                 synopsis = reader["SYNOPSIS"].ToString().Trim();
                 string bs = reader["DIFFUSER"].ToString().Trim();
                 int b = Int32.Parse(bs);
                 if (b == 1) diffuser = true;
                 else diffuser = false;
                 string dd = reader["DATEDIFFUSION"].ToString().Trim();
                 dateDiffusion = DateTime.Parse(dd);
             }
            reader.Close();
            command.Dispose();
            Episode e = new Episode(nomSerie, nSaison, nEpisode, nom, diffuser, synopsis, dateDiffusion);
            return e;

        }

        //retourne une instance Serie en récupérent la série dans la BDD
        public Serie getSerie(string nomSerie)
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
                    FS.Dispose();
                    FS.Close();
                    FS = null;
                }
            }
            reader.Close();
            command.Dispose();
            Serie res = new Serie(Nom, Synopsis, Genre, EnProductionINT, Nationalite, Casting, img, CreerPar, nbS);
            return res;
        }



        /* 
         * =========================================================================================================
         * gestion de la notation des series
         * =========================================================================================================
        */

        //méthode pour rentrer une nouvelle ligne dans la table IHM_NOTATION de la BDD
        public void ajoutNoteSerie(int note)
        {
            if (serieSelection != null)
            {
                string requete = "INSERT INTO IHM_NOTATION (NOMSERIE, NOTE, COURRIERUTIL)"
                                + " VALUES ('"+serieSelection.Nom+"', '"+note+"', '"+utilisateur.Courriel+"')";
                try
                {
                    OracleCommand command = new OracleCommand(requete, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
        }

        //méthode pour modifier une ligne dans la table IHM_NOTATION de la BDD
        public void modifierNoteSerie(int note)
        {
            if (serieSelection != null)
            {
                string requete = "UPDATE IHM_NOTATION SET NOTE = '" + note + "'"
                                  + " WHERE NOMSERIE='" + serieSelection.Nom + "' AND COURRIERUTIL='" + utilisateur.Courriel + "'";
                try
                {
                    OracleCommand command = new OracleCommand(requete, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
        }

        //méthode pour vérifier si serieSelection et l'utilisateur se trouve dans la table IHM_NOTATION de la BDD
        public bool serieDejaNoteeUtilisateur()
        {
            bool b = false;
            string requete = "SELECT count(*) FROM IHM_NOTATION WHERE NOMSERIE='" + serieSelection.Nom + "' AND COURRIERUTIL='" + utilisateur.Courriel + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            if (res > 0) b = true;
            return b;
        }

        //méthode pour la note réferencée par serieSelection et l'utilisateur dans la table IHM_NOTATION de la BDD
        public int obtenirNoteSerieUtilisateur()
        {
            string requete = "SELECT NOTE FROM IHM_NOTATION WHERE NOMSERIE='" + serieSelection.Nom + "' AND COURRIERUTIL='" + utilisateur.Courriel + "'";
            OracleCommand command = new OracleCommand(requete, con);
            string resS = command.ExecuteScalar().ToString();
            int res = Int32.Parse(resS);
            return res;
        }

        //méthode qui modifie la visibilité des composants correspondant à l'atrribution d'une note
        private void noteRendreVisible(bool b)
        {
            metroLabelNote.Visible = b;
            noteComboBox.Visible = b;
            if (b)
            {
                //si la série est déjà noté, on propose de modifier la note
                if (serieDejaNoteeUtilisateur())
                {
                    noteComboBox.SelectedIndex = obtenirNoteSerieUtilisateur();
                    metroLabelNote.Text = "modifier note";
                }
                    //autrement on propose de mettre une note
                else
                { 
                    noteComboBox.SelectedIndex = -1;
                    metroLabelNote.Text = "donner note";
                }
            }
        }

        //evenement pour le changement d'une note
        private void noteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroComboBox mcb = sender as MetroComboBox;

            //on récupère le résultat
            string resS = (string)mcb.SelectedItem;
            if (resS == "0" || resS == "1" || resS == "2" || resS == "3" || resS == "4" || resS == "5")
            {
                int note = Int32.Parse((string)mcb.SelectedItem);
                //on modifit ou on ajout la note à la BDD
                if (!serieDejaNoteeUtilisateur())
                {
                    ajoutNoteSerie(note);
                    metroLabelNote.Text = "modifier note";
                }
                else modifierNoteSerie(note);
            }
        }



        /* 
         * =========================================================================================================
         * gestion des série qu'un utilisateur va suivre
         * =========================================================================================================
        */
        //évenement click sur le boutton
        private void suiviButton_Click(object sender, EventArgs e)
        {
            if (verifSerieDansPlanning()) 
            {
                retirerPlanning();
            }
            else
            {
                ajoutPlanning();
            }
        }

        //on ajoute la série et l'utilisateur à la table IHM_PLANNING de la BDD
        public void ajoutPlanning()
        {
            if (serieSelection != null)
            {
                string requete = "INSERT INTO IHM_PLANNING (NOMSERIE,COURRIERUTIL)"
                                + " VALUES ('" + serieSelection.Nom + "', '" + utilisateur.Courriel + "')";
                try
                {
                    OracleCommand command = new OracleCommand(requete, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
                suiviButton.Text = "retirer du planing";
            }
        }

        //on retire la série et l'utilisateur de la table IHM_PLANNING de la BDD
        public void retirerPlanning()
        {
            if (serieSelection != null)
            {
                string requete = "DELETE FROM IHM_PLANNING"
                                + " WHERE NOMSERIE='" + serieSelection.Nom + "' AND COURRIERUTIL='" + utilisateur.Courriel + "'";
                try
                {
                    OracleCommand command = new OracleCommand(requete, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
                suiviButton.Text = "ajouter au planing";
            }
        }

        //vérifier si l'utilisateur et la série se trouve dans la BDD
        public bool verifSerieDansPlanning()
        {
                bool b = false;
                string requete = "SELECT COUNT(*) FROM IHM_PLANNING"
                                + " WHERE NOMSERIE='" + serieSelection.Nom + "' AND COURRIERUTIL='" + utilisateur.Courriel + "'";
                OracleCommand command = new OracleCommand(requete, con);
                string resS = command.ExecuteScalar().ToString();
                int res = Int32.Parse(resS);
                if (res > 0) b = true;
                return b;
        }

        //modifier la visibilité du boutton
        public void suiviButtonVisible(bool b)
        {
            if(b)
            {
                if (verifSerieDansPlanning()) suiviButton.Text = "retirer du planing";
                else suiviButton.Text = "ajouter au planing";
            }
            suiviButton.Visible = b;
        }

        /* 
         * =========================================================================================================
         * gestion donnée utilisateur
         * =========================================================================================================
        */

        //retourne une instance utilisateur
        public Utilisateur getUtilisateur(string mailU)
        {
            string requete = "SELECT COURRIEL, PASSWORD,DATECREATION,NOM,PRENOM,DATEN,IMAGE FROM IHM_UTILISATEUR WHERE COURRIEL='" + mailU + "'";

            OracleCommand command = new OracleCommand(requete, con);
            OracleDataReader reader = command.ExecuteReader();

            string courriel="";
            string password = "";
            DateTime dateCreation = DateTime.Parse("01/01/00 00:00:00"); 
            string nom = "";
            string prenom = "";
            DateTime dateN = DateTime.Parse("01/01/00 00:00:00"); 
            Image img=null;


            //récupération des données de la requête
            while (reader.Read())
            {
                courriel = reader["COURRIEL"].ToString().Trim();
                password = reader["PASSWORD"].ToString().Trim();
                string dc = reader["DATECREATION"].ToString().Trim();
                dateCreation = DateTime.Parse(dc);
                nom = reader["NOM"].ToString().Trim();
                prenom = reader["PRENOM"].ToString().Trim();
                string dn = reader["DATEN"].ToString().Trim();
                dateN = DateTime.Parse(dn);

                if (reader["IMAGE"] != DBNull.Value)
                {
                    byte[] blob = (byte[])reader["IMAGE"];
                    FileStream FS = new FileStream("image.jpg", FileMode.Create);
                    FS.Write(blob, 0, blob.Length);
                    img = Image.FromStream(FS);
                    FS.Dispose();
                    FS.Close();
                    FS = null;
                }
            }
            reader.Close();
            command.Dispose();
            Utilisateur u = new Utilisateur(courriel, password, nom, prenom, dateCreation, dateN, img);
            return u;
        }

        //met à jour les controls dans l'onglet 'mon compte' avec les donées de utilisateur
        public void initDoneeUtilisateur()
        {
            utilisateurMailLabel.Text = utilisateur.Courriel;
            utilisateurLogin.Text = utilisateur.Courriel;
            utilisateurNomTextBox.Text = utilisateur.Nom;
            utilisateurPrenomTextBox.Text = utilisateur.Prenom;
            DateTime auj = DateTime.Now;
            System.TimeSpan dif = auj.Subtract(utilisateur.DateCreation);
            utilisateurMembreDepuisLabel.Text = string.Format("membre depuis : {0:D2} jours", dif.Days);
            utilisateurAncienMDPTextBox.Text = "";
            utilisateurNouveauMDPTextBox.Text = "";
            utilisateurDateNaissanceDateTimePicker.Value = utilisateur.DateN;
            if (utilisateur.Image != null)
            {
                utilisateurImagePictureBox.Image = utilisateur.Image;
                utilisateurImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                utilisateurImageAvatar.Image = utilisateur.Image;
                utilisateurImageAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        //evenement quand on clique sur le boutton pour modifier les données de l'utilisateur
        private void utilisateurAppliquerModificationButton_Click(object sender, EventArgs e)
        {
            string modif = "";
            try
            {
                string requete;
                if(utilisateurAncienMDPTextBox.Text == utilisateur.Password)
                {
                    //on vérifie que l'utilisateur a modifié les données correspondant à son nom et on applique la modif
                    if (utilisateurNomTextBox.Text != utilisateur.Nom)
                    {
                        requete = "UPDATE IHM_UTILISATEUR SET NOM = '" + utilisateurNomTextBox.Text + "'"
                                          + " WHERE COURRIEL='" + utilisateur.Courriel + "'";

                            OracleCommand command = new OracleCommand(requete, con);
                            command.ExecuteNonQuery();
                            modif += "\nnom changé";

                    }
                    //on vérifie que l'utilisateur a modifié les données correspondant à son prénom et on applique la modif
                    if (utilisateurPrenomTextBox.Text != utilisateur.Prenom)
                    {
                        requete = "UPDATE IHM_UTILISATEUR SET PRENOM = '" + utilisateurPrenomTextBox.Text + "'"
                                          + " WHERE COURRIEL='" + utilisateur.Courriel + "'";

                        OracleCommand command = new OracleCommand(requete, con);
                        command.ExecuteNonQuery();
                        modif += "\nprénom changé";
                    }
                    //même chose pour le prénom
                    if (utilisateurDateNaissanceDateTimePicker.Value != utilisateur.DateN)
                    {
                        string d = utilisateurDateNaissanceDateTimePicker.Value.ToString("dd/MM/yyyy");
                        requete = "UPDATE IHM_UTILISATEUR SET DATEN = '" + d + "'"
                                          + " WHERE COURRIEL='" + utilisateur.Courriel + "'";

                        OracleCommand command = new OracleCommand(requete, con);
                        command.ExecuteNonQuery();
                        modif += "\ndate de naissance changé";
                    }
                    //on vérifie si un nouveaux mdp a été rentré et on pplique les modification
                    if (utilisateurNouveauMDPTextBox.Text != "")
                    {
                        requete = "UPDATE IHM_UTILISATEUR SET PASSWORD = '" + utilisateurNouveauMDPTextBox.Text + "'"
                                          + " WHERE COURRIEL='" + utilisateur.Courriel + "'";

                        OracleCommand command = new OracleCommand(requete, con);
                        command.ExecuteNonQuery();
                        modif += "\nmot de passe changé";
                    }
                    //on applique les modif à l'instance utilisateur
                    utilisateur = getUtilisateur(utilisateur.Courriel);
                    
                    MetroMessageBox.Show(this, "modification effectuée" + modif, "REUSSIE :");  
                }
                else MetroMessageBox.Show(this, "mauvais mot de passe", "ERREUR :");  

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
            }
            initDoneeUtilisateur();
        }


        /* 
         * =========================================================================================================
         * gestion planning
         * =========================================================================================================
        */

        //initialisation de la grille des série à suivre
        public void initGrille()
        {
            
            string auj = DateTime.Now.ToString();
            auj = auj.Substring(0, 10);
            //requete qui renvoie les épisode qui passe après aujourd'hui
            string requete = "SELECT SERIE.NOM, EPISODE.SAISONNUMERO, EPISODE.NUMERO, EPISODE.DATEDIFFUSION"
                            + " FROM IHM_SERIE SERIE, IHM_PLANNING PLANNING, IHM_EPISODE EPISODE"
                            + " WHERE SERIE.NOM=PLANNING.NOMSERIE AND SERIE.NOM=EPISODE.NOMSERIE"
                            + " AND EPISODE.NOMSERIE=PLANNING.NOMSERIE AND PLANNING.COURRIERUTIL='" + utilisateur.Courriel + "'"
                            + " AND EPISODE.DATEDIFFUSION>'" + auj + "'"
                            + " ORDER BY EPISODE.DATEDIFFUSION";
            try
            {
                oDA = dbpf.CreateDataAdapter();
                oDA.SelectCommand = con.CreateCommand();
                oDA.SelectCommand.CommandText = requete;
                oDS = new DataSet();
                oDA.Fill(oDS, "PLANNING");
                planingMetroGrid.DataSource = oDS.Tables[0];
                planingMetroGrid.Columns["NOM"].HeaderText = "Série";
                planingMetroGrid.Columns["NOM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                planingMetroGrid.Columns["SAISONNUMERO"].HeaderText = "saison";
                planingMetroGrid.Columns["NUMERO"].HeaderText = "épisode";
                planingMetroGrid.Columns["DATEDIFFUSION"].HeaderText = "diffusion";
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }
        }

        //evenement qui lance la réinilisation de la grille de planning quand on clique sur le boutton
        private void initGridButton_Click(object sender, EventArgs e)
        {
            initGrille();
        }

        //evenement, double clique sur une ligne, nous renvoie à la fiche épisode correspondant
        private void planingMetroGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int lig = e.RowIndex;
            if (this.planingMetroGrid.Rows[lig].Cells[0].Value.ToString() != "")
            {
                string nomS = this.planingMetroGrid.Rows[lig].Cells[0].Value.ToString();
                string saison = this.planingMetroGrid.Rows[lig].Cells[1].Value.ToString();
                string episode = this.planingMetroGrid.Rows[lig].Cells[2].Value.ToString();

                nettoyerFichePanel(true);
                serieSelection = getSerie(nomS);
                episodeSelection = getEpisode(nomS, Int32.Parse(saison), Int32.Parse(episode));
                initFicheEpisode();
                ficheEpisodePanel.Visible = true;

                metroTabControl1.SelectedIndex = 0;
              
            }
        }

    }
}