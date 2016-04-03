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
using MetroFramework.Components;

namespace UBVid
{
    enum Genre { Policier, Comédie, Drame, Action, Anime};
    public partial class Form_Admin : MetroForm
    {
        private OracleConnection con;
        private DbProviderFactory dbpf;
        private DbDataAdapter oDA;
        private DataSet oDS;
        private Administrateur admin;
        private moteurAdmin moteur = new moteurAdmin();

        //variable pour tout les images
        Image imgAjouterSerie;  //image pour l'ajoute d'une série
        Image imgAjouterAdmin;
        Image imgModifSerie;

        //Variable pour stocker la série courant
        Serie serie;

        //Variable por stocker l'épisode courant
        Episode episode;


        public Form_Admin(OracleConnection c, DbProviderFactory d, Administrateur ad)
        {
            InitializeComponent();
            con = c;
            dbpf = d;
            admin = ad;
            InitGrille();
            initAjouteSerie();
            initInfoAdmin();
            ((Control)this.tab_Modif_Episode).Enabled = false;
            ((Control)this.tab_Modif_Serie).Enabled = false;
        }

        
        /*
         * Methode pour se connecter à la base de donnée
         */
        private void InitConnect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "DATA SOURCE=//ufrsciencestech.u-bourgogne.fr:25559/ense2014;USER ID=user;PASSWORD=admin";
                con.Open();
                dbpf = DbProviderFactories.GetFactory("Oracle.DataAccess.Client");
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }
        }

        /// <summary>
        /// Méthode pour afficher le nom et l'iamge de administrateur connecté
        /// </summary>
        private void initInfoAdmin()
        {
            if (admin.Img != null)
                this.pictureBox6.Image = admin.Img;
            this.metroLabel26.Text = admin.Prenom + " " + admin.Nom;
            this.pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Méthode qui deconnect l'administrateur et retourne à la page d'authentification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroLink1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Authen authentification = new Form_Authen();
            authentification.ShowDialog();
            this.Close();
        }

       

        /// <summary>
        /// Méthode qui convertie une image en tableau de bytes
        /// </summary>
        /// <param name="imageIn">Une image</param>
        /// <returns>Tableau de byte</returns>
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            Image res = imageIn;
            res.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }




        /*-------------------------------------------------------------------------------------------
         * ------------------------------------------------------------------------------------------
         * Les méthodes et actions pour l'onglet ajouter une série
         * ------------------------------------------------------------------------------------------
         * ------------------------------------------------------------------------------------------
         */

        /*
        * Initialtion du panel pour ajouter une série
        */
        private void initAjouteSerie()
        {
            foreach (var gen in Enum.GetValues(typeof(Genre)))
            {
                this.combo_genre.Items.Add(gen);
            }
        }

        /*
         * Méthode pour reinitialiser tout les textbook et l'image
         */
        private void reinitAjouterSerie()
        {
            this.text_nomserie.Text = "";
            this.text_creeePar.Text = "";
            this.text_casting.Text = "";
            this.combo_genre.SelectedIndex = -1;
            this.text_paysOrigine.Text = "";
            this.text_synopsis.Text = "";
            this.imgAjouterSerie = null;
            this.pictureBox4.Image = null;
        }

        /*
         * Methode pour mettre une bordure autour du textbox
         * Effacer tout les caractères déjà présent dans le textbox
         */
        private void text_nomserie_Enter(object sender, EventArgs e)
        {
            MetroTextBox tb = (MetroTextBox)sender;
            tb.UseStyleColors = true;
            tb.Refresh();
        }

        /*
         * Methode pour enlever la bordure autour du textbox
         */
        private void text_nomserie_Leave(object sender, EventArgs e)
        {
            MetroTextBox tb = (MetroTextBox)sender;
            tb.UseStyleColors = false;
            tb.Refresh();
        }


        //Action quand on choisit une image
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Images (*.bmp, *.jpg, *.png) | *.bmp;*.jpg;*.png";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.imgAjouterSerie = Image.FromFile(diag.FileName.ToString());
                this.pictureBox4.Image = imgAjouterSerie;
                this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        /*
         * Action quand on click sur ke button valider
         * Cette méthode aussi fait ma vérification des données(Si elles sont bien entrées)
         */
        private void but_ValiderSerie_Click(object sender, EventArgs e)
        {
            if (this.text_nomserie.Text == "")
                this.metroToolTip1.Show("Entrez le nom de la série", this.text_nomserie, 1500);
            else if (this.text_paysOrigine.Text == "")
                this.metroToolTip1.Show("Entrez le pays d'origine", this.text_paysOrigine, 1500);
            else if (this.combo_genre.SelectedIndex == -1)
                this.metroToolTip1.Show("Choissiez un genre", this.combo_genre, 1500);
            else if (this.imgAjouterSerie == null)
                this.metroToolTip1.Show("Choissiez une image", this.pictureBox4, 1500);
            else
            {
                try
                {
                    if (this.imgAjouterSerie != null)    //SI une image est choisit
                    {
                        string enproduction;
                        if (this.tog_Prodiction_Serie.Checked)
                            enproduction = "1";
                        else
                            enproduction = "0";

                        //la requete sql pour ajouter la serie dans la base de donnée
                        string requete;
                        requete = "insert into IHM_SERIE(NOM,Synopsis,GENRE,ENPRODUCTION,NATIONALITE,CASTING,CREER_PAR,IMAGE)";
                        requete += "values('" + this.text_nomserie.Text + "'," +
                            "'" + this.text_synopsis.Text + "'," +
                            "'" + this.combo_genre.SelectedItem.ToString() + "'," +
                            enproduction + "," +
                            "'" + this.text_paysOrigine.Text + "'," +
                            "'" + this.text_casting.Text + "'," +
                            "'" + this.text_creeePar.Text + "'," +
                            " :BlobParameter )";

                        //code pour mettre l'image dans la base de donnée
                        //le code est inspiré du code http://www.codeproject.com/Articles/13365/Insert-retrieve-an-image-into-from-a-blob-field-in
                        //mettre l'image dans un tableau de bits
                        byte[] blob = this.imageToByteArray(this.imgAjouterSerie);


                        //insert the byte as oracle parameter of type blob 
                        OracleParameter blobParameter = new OracleParameter();
                        blobParameter.OracleDbType = OracleDbType.Blob;
                        blobParameter.ParameterName = "BlobParameter";
                        blobParameter.Value = blob;


                        OracleCommand cmnd = con.CreateCommand();
                        cmnd = new OracleCommand(requete, con);
                        cmnd.Parameters.Add(blobParameter);
                        cmnd.ExecuteNonQuery();
                        MetroMessageBox.Show(this, "La série a été enregistrée", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.InitGrille();
                        this.reinitAjouterSerie();
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
           
        }

        private void but_annulerSerie_Click(object sender, EventArgs e)
        {
            this.reinitAjouterSerie();
        }

        /*--------------------------------------------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------------------------------------------
         * Methode et action pour l'onglet ajouter une saison
         * -------------------------------------------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------------------------------------------
         */

        //Méthode qui reéinitialise tout les champs et le datagriview
        //La méthode prend en parametre un boolean qui elle est vrais alors on reinitialise aussi le datagridview
        public void reinitajouterSaison(Boolean del)
        {
            this.text_recherche.Text = "";
            this.text_nomSerie_Saison.Text = "";
            this.text_GenreSerie_Saison.Text = "";
            if(del)
            {
                if (oDS.Tables["RECH_SERIE"] != null)
                    oDS.Tables["RECH_SERIE"].Clear();
                this.grille_rechSaison.DataSource = null;
                this.grille_rechSaison.Refresh();
            }
            this.text_nbSaison_saison.Text = "";
            this.pictureBox1.Image = null;
        }
        private void but_recherche_Click(object sender, EventArgs e)
        {

            try
            {
                if (oDS.Tables["RECH_SERIE"] != null)
                    oDS.Tables["RECH_SERIE"].Clear();
                string requete = "SELECT NOM FROM IHM_SERIE WHERE NOM LIKE " +
                "'%" + this.text_recherche.Text + "%'";
                oDA.SelectCommand.CommandText = requete;
                oDA.Fill(oDS, "RECH_SERIE"); //directionReg : nom choisi pour le DataTable
                this.grille_rechSaison.DataSource = oDS.Tables["RECH_SERIE"];
                this.grille_rechSaison.Refresh();
                this.reinitajouterSaison(false);
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }
        }

        //Action quand on appuit sur la touche entré pour recherhce une série
        private void text_recherche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.but_recherche_Click(sender, e);
        }

        /*
         * Pour récuperer le nom de la serie et aussi calculer le numéro de la saison
         */
        private void grille_rechSaison_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lig = e.RowIndex;
            string nomSerie = this.grille_rechSaison.Rows[lig].Cells["NOM"].Value.ToString();
            int numSaison = moteur.numSaison(con, nomSerie);   //Récupération du neméro la saison que l'on veut ajouter
            
            serie = moteur.getSerie(con, nomSerie); //récupération de la serie choisit
            
            //mettre les information de la séries dans les textboxes
            this.text_GenreSerie_Saison.Text = serie.Genre;
            this.text_nomSerie_Saison.Text = serie.Nom;
            this.text_nbSaison_saison.Text = numSaison.ToString();
            
            //met a jour les toggle button en fonction de la produciton de la série
            if (serie.EnProduction)
            {
                this.tog_serieProdction_Saison.Checked = true;
                this.tog_production_Saison.Checked = true;
                this.tog_production_Saison.Enabled = true;
            }
            else
            {
                this.tog_serieProdction_Saison.Checked = false;
                this.tog_production_Saison.Checked = false;
                this.tog_production_Saison.Enabled = false;
            }
               
            //Afficher l'image de la série
            this.pictureBox1.Image = serie.Image;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        }


        /*
         * Action quand on click sur le button valider
         * grâce à cette méthode on ajoute une saison dans la base de donnée
         */
        private void but_Valider_Saison_Click(object sender, EventArgs e)
        {
            int nbsaison = Int32.Parse(this.text_nbSaison_saison.Text) + 1;
            string production;
            if (this.tog_production_Saison.Checked)
                production = "1";
            else
                production = "0";
            string requete = moteur.ajouterSaison(this.text_nomSerie_Saison.Text, nbsaison.ToString(), production);

            try
            {
                OracleCommand command = new OracleCommand(requete, con);
                MetroMessageBox.Show(this, "La saison a été enregistrée", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Question);
                command.ExecuteNonQuery();
                this.reinitajouterSaison(true);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
            }

        }

        /*
         * Action quand on click sur le button annuler
         */
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.reinitajouterSaison(true);
        }


        /*---------------------------------------------------------------------------------------------------
         * --------------------------------------------------------------------------------------------------
         * --------------------------------------------------------------------------------------------------
         * Methode et action relié à l'onglet ajouter un épisode
         * --------------------------------------------------------------------------------------------------
         * --------------------------------------------------------------------------------------------------
         * --------------------------------------------------------------------------------------------------
         */
        /// <summary>
        ///Méthode qui reéinitialise tout les champs et le datagriview
        ///La méthode prend en parametre un boolean qui elle est vrais alors on reinitialise aussi le datagridview
        /// </summary>
        /// <param name="del">Booléen pour reinitialiser le datagridview</param>
        private void reinitajouterEpisode(Boolean del)
        {
            this.text_rechSerie_episode.Text = "";
            this.text_nomSerie_Episode.Text = "";
            this.text_nbEpisode_Episode.Text = "";
            this.text_nbSaison_Episode.Text = "";
            this.text_nomEpisode_Episode.Text = "";
            this.text_synopsis_episode.Text = "";
            this.combo_nbSaison.Items.Clear();
            this.pictureBox2.Image = null;
            if (del)
            {
                if (oDS.Tables["RECH_SERIE"] != null)
                    oDS.Tables["RECH_SERIE"].Clear();
                this.grille_Serie_Episode.DataSource = null;
                this.grille_Serie_Episode.Refresh();
            }  
        }

        private void but_rechercheSerie_episode_Click(object sender, EventArgs e)
        {
            try
            {
                if (oDS.Tables["RECH_SERIE"] != null)
                    oDS.Tables["RECH_SERIE"].Clear();
                string requete = "SELECT NOM FROM IHM_SERIE WHERE NOM LIKE " +
                "'%" + this.text_rechSerie_episode.Text + "%'";
                oDA.SelectCommand.CommandText = requete;
                oDA.Fill(oDS, "RECH_SERIE"); //directionReg : nom choisi pour le DataTable
                this.grille_Serie_Episode.DataSource = oDS.Tables["RECH_SERIE"];
                this.grille_Serie_Episode.Refresh();
                this.reinitajouterEpisode(false);
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }
        }

        private void text_rechSerie_episode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.but_rechercheSerie_episode_Click(sender, e);
        }

        private void initComboBox(int nbSaison)
        {
            this.combo_nbSaison.Items.Clear();
            for(int i=1;i<=nbSaison;i++)
            {
                this.combo_nbSaison.Items.Add("Saison " + i);
            }
        }

        private void grille_Serie_Episode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lig = e.RowIndex;
            string nomSerie = this.grille_Serie_Episode.Rows[lig].Cells["NOM"].Value.ToString();
            int numSaison = moteur.numSaison(con, nomSerie);   //Récupération du neméro la saison que l'on veut ajouter

            serie = moteur.getSerie(con, nomSerie); //récupération de la serie choisit

            //mettre les information de la séries dans les textboxes
            this.text_nomSerie_Episode.Text = serie.Nom;
            this.text_nbSaison_Episode.Text = numSaison.ToString();

            //met a jour les toggle button en fonction de la produciton de la série
            if (serie.EnProduction)
            {
                this.tog_Serie_Enproduction_Episode.Checked = true;
            }
            else
            {
                this.tog_Serie_Enproduction_Episode.Checked = false;
            }

            //Afficher l'image de la série
            this.pictureBox2.Image = serie.Image;
            this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            //initialiser avec les noms des saisons
            initComboBox(numSaison);

            //si la saison n'est plus en produtction on met la date maximal que l'administrateur peut choisr à la date actuel
            if (!this.tog_Serie_Enproduction_Episode.Checked)
            {
                this.date_Date_Diffusion_Episode.MaxDate = DateTime.Now;
                this.tog_diffuser_episode.Checked = false;
            }
            else
            {
                this.date_Date_Diffusion_Episode.MaxDate = new DateTime(3500, 6, 20);
                this.tog_diffuser_episode.Checked = true;
            }
               
        }

        private void combo_nbSaison_SelectedValueChanged(object sender, EventArgs e)
        {
            MetroComboBox combo = (MetroComboBox)sender;
            int nbsaison = combo.SelectedIndex + 1;
            string nomSerie = this.text_nomSerie_Episode.Text;
            int nbEpisode = moteur.numEpisode(con, nomSerie, nbsaison.ToString());
            this.text_nbEpisode_Episode.Text = nbEpisode.ToString();
        }

        //Action quand on change la date de diffusion
        //si la la date de diffusion est antérieur à la date du systeme alors on et la diffusion est à vrai
        //Sinon la diffusion est a faux
        private void date_Date_Diffusion_Episode_ValueChanged(object sender, EventArgs e)
        {
            if(DateTime.Compare(this.date_Date_Diffusion_Episode.Value, DateTime.Now) <0)
                this.tog_diffuser_episode.Checked = true;
            else
                this.tog_diffuser_episode.Checked = false;
        }

        /// <summary>
        /// Action quand on click sur le button valider de l'onglet episode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_valider_Episode_Click(object sender, EventArgs e)
        {
            if (this.text_nomEpisode_Episode.Text == "")
                this.metroToolTip1.Show("Veuillez entrer le nom de l'épisode", this.text_nomEpisode_Episode, 1500);
            else
            {
                string numeroEP = this.text_nbEpisode_Episode.Text;
                string date = this.date_Date_Diffusion_Episode.Value.ToString("dd/MM/yyyy");

                string synopsis = this.text_synopsis_episode.Text;
                string diffuser;
                if (this.tog_diffuser_episode.Checked)
                    diffuser = "1";
                else
                    diffuser = "0";

                string nomEP = this.text_nomEpisode_Episode.Text;
                string nomSerie = this.text_nomSerie_Episode.Text;
                string numSaison = (this.combo_nbSaison.SelectedIndex + 1).ToString();
                string requete = moteur.ajouterEpisode(nomSerie, date, numeroEP, synopsis, nomEP, diffuser, numSaison);

                this.text_synopsis_episode.Text = requete;
                try
                {
                    OracleCommand command = new OracleCommand(requete, con);
                    command.ExecuteNonQuery();
                    MetroMessageBox.Show(this, "L'épisode a été enregistrée", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.reinitajouterEpisode(true);
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
         
        }

        private void but_annuler_Episode_Click(object sender, EventArgs e)
        {
            this.reinitajouterEpisode(true);
        }



        /*---------------------------------------------------------------------------------------------------
        * --------------------------------------------------------------------------------------------------
        * --------------------------------------------------------------------------------------------------
        * Methode et action relié à l'onglet ajouter un administrateur
        * --------------------------------------------------------------------------------------------------
        * --------------------------------------------------------------------------------------------------
        * --------------------------------------------------------------------------------------------------
        */
        private void reinitajouterAdmin()
        {
            this.text_nom_admin.Text = "";
            this.text_prenom_admin.Text = "";
            this.text_courriel_admin.Text = "";
            this.text_courriel2_admin.Text = "";
            this.imgAjouterAdmin = null;
            this.pictureBox3.Image = null;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Images (*.bmp, *.jpg, *.png) | *.bmp;*.jpg;*.png";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.imgAjouterAdmin = Image.FromFile(diag.FileName.ToString());
                this.pictureBox3.Image = imgAjouterAdmin;
                this.pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void but_valider_admin_Click(object sender, EventArgs e)
        {
            if (this.text_courriel2_admin.Text != this.text_courriel_admin.Text)
            {
                this.text_courriel_admin.Focus();
                this.metroToolTip1.Show("Erreur veuilez vérifier vôtre courriel", this.text_courriel_admin, 1500);
            }
            else if (this.text_nom_admin.Text == "")
                this.metroToolTip1.Show("Veuillez entrez un nom", this.text_nom_admin, 1500);
            else if (this.text_courriel2_admin.Text == "")
                this.metroToolTip1.Show("Veuillez entrez un courriel", this.text_courriel_admin, 1500);
            else if (this.imgAjouterAdmin == null)
                this.metroToolTip1.Show("Veuillez choisir une image", this.pictureBox3, 1500);
            else
            {
                try
                {
                    string password = "";
                    password = moteur.CreeePassword(8);
                    //recuperer la date de naissance
                    string date = this.date_dateN_admin.Value.ToString("dd/MM/yyyy");
                    //la requete sql pour ajouter la serie dans la base de donnée
                    string requete = moteur.ajouterAdmin(this.text_nom_admin.Text,
                        this.text_prenom_admin.Text,
                        date,
                        this.text_courriel_admin.Text, password);


                    //code pour mettre l'image dans la base de donnée
                    //le code est inspiré du code http://www.codeproject.com/Articles/13365/Insert-retrieve-an-image-into-from-a-blob-field-in
                    //mettre l'image dans un tableau de bits
                    byte[] blob = this.imageToByteArray(this.imgAjouterAdmin);


                    //insert the byte as oracle parameter of type blob 
                    OracleParameter blobParameter = new OracleParameter();
                    blobParameter.OracleDbType = OracleDbType.Blob;
                    blobParameter.ParameterName = "BlobParameter";
                    blobParameter.Value = blob;


                    OracleCommand cmnd = con.CreateCommand();
                    cmnd = new OracleCommand(requete, con);
                    cmnd.Parameters.Add(blobParameter);
                    cmnd.ExecuteNonQuery();
                    MetroMessageBox.Show(this, "Votre Mot de passe est : " + password, password, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MetroMessageBox.Show(this, "La série a été enregistrée", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    reinitajouterAdmin();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
        }

        private void text_courriel2_admin_TextChanged(object sender, EventArgs e)
        {
            if (this.text_courriel_admin.Text == this.text_courriel2_admin.Text)
            {
                this.pictureBox5.Visible = true;
            }
            else
                this.pictureBox5.Visible = false;
        }

        private void but_annuler_admin_Click(object sender, EventArgs e)
        {
            reinitajouterAdmin();
        }

        private void text_courriel_admin_TextChanged(object sender, EventArgs e)
        {
            this.text_courriel2_admin.Text = "";
            this.pictureBox5.Visible = false;
        }

        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //-------------------Methode relié à la liste de toutes les série ------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        /*
        * Initiation de la grille des séries
        */
        private void InitGrille()
        {
            try
            {
                oDA = dbpf.CreateDataAdapter();
                oDA.SelectCommand = con.CreateCommand();
                oDA.SelectCommand.CommandText = "select NOM,GENRE, ENPRODUCTION, NATIONALITE, CASTING, CREER_PAR, SYNOPSIS  from IHM_SERIE";
                oDS = new DataSet();
                oDA.Fill(oDS, "SERIE");
                
                this.grilleSerie.DataSource = oDS.Tables[0];
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }
        }

        /*
         * Quand on choisit une serie dans la grille, grâce à cette méthode
         * on peut afficher toute les saison de la serie choisit
         */
        private void grilleSerie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)(this.grilleSerie.DataSource);
            string information = dt.TableName.ToString();
            if(information == "SERIE")
            {
                if (oDS.Tables["SAISON"] != null)
                    oDS.Tables["SAISON"].Clear();
                int lig = e.RowIndex;
                if (this.grilleSerie.Rows[lig].Cells[0].Value.ToString() != "")
                {
                    string nomS = this.grilleSerie.Rows[lig].Cells[0].Value.ToString();
                    string requete = "select * from IHM_SAISON WHERE IHM_SAISON.NOMSERIE='" + nomS + "'";
                    oDA.SelectCommand.CommandText = requete;
                    oDA.Fill(oDS, "SAISON"); //directionReg : nom choisi pour le DataTable
                    this.grilleSerie.DataSource = oDS.Tables["SAISON"];
                }
            } else if(information == "SAISON")
            {
                if (oDS.Tables["EPISODE"] != null)
                    oDS.Tables["EPISODE"].Clear();
                int lig = e.RowIndex;
                if (this.grilleSerie.Rows[lig].Cells[0].Value.ToString() != "")
                {
                    string nomS = this.grilleSerie.Rows[lig].Cells[0].Value.ToString();
                    string numSai = this.grilleSerie.Rows[lig].Cells[1].Value.ToString();

                    string requete = "select * from IHM_EPISODE WHERE NOMSERIE='" + nomS + "' AND  SAISONNUMERO ='"+ numSai +"'";
                    oDA.SelectCommand.CommandText = requete;
                    oDA.Fill(oDS, "EPISODE"); //directionReg : nom choisi pour le DataTable
                    this.grilleSerie.DataSource = oDS.Tables["EPISODE"];
                }
            }
            
        }

        private void but_retour_liste_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)(this.grilleSerie.DataSource);
            string information = dt.TableName.ToString();
            if(information == "EPISODE")
                this.grilleSerie.DataSource = oDS.Tables["SAISON"];
            else if(information == "SAISON")
                this.grilleSerie.DataSource = oDS.Tables["SERIE"];
        }

        private void but_supprimmer_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)(this.grilleSerie.DataSource);
            string information = dt.TableName.ToString();
            int lig = this.grilleSerie.SelectedRows[0].Index;
            if (information == "SERIE")
            {
                string nomS = this.grilleSerie.Rows[lig].Cells["NOM"].Value.ToString();
                string requete = "DELETE FROM IHM_SERIE WHERE NOM ='" + nomS + "'";
                try
                {
                    OracleCommand command = new OracleCommand(requete, con);
                    MetroMessageBox.Show(this, "La saison a été enregistrée", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    command.ExecuteNonQuery();
                    this.InitGrille();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
         }

        /// <summary>
        /// Action quand on click sur le bouton modifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_modifier_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)(this.grilleSerie.DataSource);
            string information = dt.TableName.ToString();
            if(this.grilleSerie.SelectedRows.Count==1)
            {
                int lig = this.grilleSerie.SelectedRows[0].Index;
                if (information == "SERIE")
                {
                    metroTabControl1.SelectedTab = this.tab_Modif_Serie;
                    string nomS = this.grilleSerie.Rows[lig].Cells["NOM"].Value.ToString();
                    this.serie = moteur.getSerie(con, nomS);
                    this.text_nomSerie_modifS.Text = serie.Nom;
                    foreach (var gen in Enum.GetValues(typeof(Genre)))
                    {
                        this.combo_genre_modifS.Items.Add(gen);
                    }
                    this.combo_genre_modifS.SelectedIndex = combo_genre_modifS.FindStringExact(serie.Genre);
                    this.text_pays_modifS.Text = serie.Nationalite;
                    this.text_casting_modfiS.Text = serie.Casting;
                    this.text_creer_modifS.Text = serie.CreerPar;
                    this.text_synopsis_modifS.Text = serie.Synopsis;
                    this.imgModifSerie = Image.FromFile("output");
                    this.picturebox_modifS.Image = imgModifSerie;
                    this.picturebox_modifS.SizeMode = PictureBoxSizeMode.Zoom;
                    this.tog_prod_modifS.Checked = serie.EnProduction;
                    ((Control)this.tab_Modif_Serie).Enabled = true;
                }
                else if (information == "EPISODE")
                {
                    metroTabControl1.SelectedTab = this.tab_Modif_Episode;
                    string numero = this.grilleSerie.Rows[lig].Cells["NUMERO"].Value.ToString();
                    string nomS = this.grilleSerie.Rows[lig].Cells["NOMSERIE"].Value.ToString();
                    string numSaison = this.grilleSerie.Rows[lig].Cells["SAISONNUMERO"].Value.ToString();

                    episode = moteur.getEpisode(con, nomS, numSaison, numero);

                    text_nom_serie_modifE.Text = episode.NomSerie;
                    text_num_saison_modifE.Text = episode.SaisonNumero.ToString();
                    text_num_ep_modifE.Text = episode.Numero.ToString();
                    text_nom_Ep_modifE.Text = episode.Nom;
                    text_synopsis_ModifE.Text = episode.Synopsis;
                    date_DateD_ModifE.Value = episode.DateDiffusion;
                    tog_diffuer_modifE.Checked = episode.Diffuser;
                    ((Control)this.tab_Modif_Episode).Enabled = true;
                }
            }
       
        }



        private void grilleSerie_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)(this.grilleSerie.DataSource);
            string information = dt.TableName.ToString();
            if (information == "SERIE")
            {
                this.but_supprimmer.Visible = true;
                this.but_modifier.Visible = true;
                this.but_retour_liste.Visible = false;
            }
            else if (information =="SAISON")
            {
                this.but_supprimmer.Visible = false;
                this.but_modifier.Visible = false;
                this.but_retour_liste.Visible = true;
            }
            else if (information == "EPISODE")
            {
                this.but_supprimmer.Visible = false;
                this.but_modifier.Visible = true;
                this.but_retour_liste.Visible = true;
            }
        }



        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        //-------------------------Méthode relié à l'onglet modifier une série-------------------------------
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
       /// <summary>
       /// Méthode pour reinitialiser l'onglet modifier une série
       /// </summary>
        private void reinitmodifSerie()
        {
            text_nomSerie_modifS.Text ="";
            text_pays_modifS.Text ="";
            text_casting_modfiS.Text ="";
            text_creer_modifS.Text ="";
            text_synopsis_modifS.Text ="";

            picturebox_modifS.Image = null;
            imgModifSerie = null;
            
            ((Control)this.tab_Modif_Serie).Enabled = false;
            GC.Collect();   //rammase miette pour eviter les problemes d'accès a aux fichier images
        }
        
        
        private void but_vallider_modifS_Click(object sender, EventArgs e)
        {
            try
                {
                    if (imgModifSerie != null)    //SI une image est choisit
                    {
                        string prod;
                        if (tog_prod_modifS.Checked)
                            prod = "1";
                        else
                            prod = "0";
                        string requete = moteur.modifSerie(text_nomSerie_modifS.Text, text_synopsis_modifS.Text
                            , combo_genre_modifS.SelectedItem.ToString(), prod, text_pays_modifS.Text,
                            text_casting_modfiS.Text, text_creer_modifS.Text);


                        //code pour mettre l'image dans la base de donnée
                        //le code est inspiré du code http://www.codeproject.com/Articles/13365/Insert-retrieve-an-image-into-from-a-blob-field-in
                        //mettre l'image dans un tableau de bits
                        byte[] blob = this.imageToByteArray(imgModifSerie);

                        //insert the byte as oracle parameter of type blob 
                        OracleParameter blobParameter = new OracleParameter();
                        blobParameter.OracleDbType = OracleDbType.Blob;
                        blobParameter.ParameterName = "BlobParameter";
                        blobParameter.Value = blob;


                        OracleCommand cmnd = con.CreateCommand();
                        cmnd = new OracleCommand(requete, con);
                        cmnd.Parameters.Add(blobParameter);
                        cmnd.ExecuteNonQuery();
                        MetroMessageBox.Show(this, "La série a été modifié", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reinitmodifSerie();
                        InitGrille();
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }

        }

        private void picturebox_modifS_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Images (*.bmp, *.jpg, *.png) | *.bmp;*.jpg;*.png";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.imgModifSerie = Image.FromFile(diag.FileName.ToString());
                this.picturebox_modifS.Image = imgModifSerie;
                this.picturebox_modifS.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void tab_Modif_Serie_Leave(object sender, EventArgs e)
        {
            reinitmodifSerie();
        }

        private void but_annuler_modifS_Click(object sender, EventArgs e)
        {
            reinitmodifSerie();
        }


        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        //-------------------------Méthode relié à 'onglet modifier un épisode-------------------------------
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        /// <summary>
        /// Méthode pour reiitialiser l'onglet pour modifier un épisode
        /// </summary>
        public void reinitmodifEp()
        {
            text_nom_serie_modifE.Text ="";
            text_num_saison_modifE.Text ="";
            text_num_ep_modifE.Text ="";
            text_nom_Ep_modifE.Text ="";
            text_synopsis_ModifE.Text = "";
            ((Control)this.tab_Modif_Episode).Enabled = false;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           
            try
            {
                string diffuser;
                if (tog_diffuer_modifE.Checked)
                    diffuser = "1";
                else
                    diffuser = "0";
                string requete = moteur.modifEpisode(text_nom_serie_modifE.Text,
                    text_num_saison_modifE.Text,
                    text_num_ep_modifE.Text,
                    text_nom_Ep_modifE.Text,
                    this.date_DateD_ModifE.Value.ToShortDateString(),
                    diffuser,
                    text_synopsis_ModifE.Text);

                OracleCommand cmnd = con.CreateCommand();
                cmnd = new OracleCommand(requete, con);
                cmnd.ExecuteNonQuery();
                MetroMessageBox.Show(this, "La série a été modifié", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reinitmodifEp();
                InitGrille();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            reinitmodifEp();
        }

        private void tab_Modif_Episode_Leave(object sender, EventArgs e)
        {
            reinitmodifEp();
        }

        private void date_DateD_ModifE_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.date_DateD_ModifE.Value, DateTime.Now) < 0)
                this.tog_diffuer_modifE.Checked = true;
            else
                this.tog_diffuer_modifE.Checked = false;
        }



    }
}

 