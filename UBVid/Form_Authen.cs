using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBVid
{
    public partial class Form_Authen : MetroForm
    {
        private OracleConnection con;
        private DbProviderFactory dbpf;
        private Administrateur admin;

        public Form_Authen()
        {
            InitializeComponent();
            InitConnect();
        }

        private void InitConnect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "DATA SOURCE=//ufrsciencestech.u-bourgogne.fr:25559/ense2014;USER ID=username;PASSWORD=admin";
                con.Open();
                dbpf = DbProviderFactories.GetFactory("Oracle.DataAccess.Client");
            }
            catch (Exception ec)
            {
                this.Text = ec.Message;
            }
        }

        private void text_courriel_Enter(object sender, EventArgs e)
        {
            MetroTextBox text = (MetroTextBox)sender;
            text.UseStyleColors = true;
            text.Refresh();
        }

        private void text_courriel_Leave(object sender, EventArgs e)
        {
            MetroTextBox text = (MetroTextBox)sender;
            text.UseStyleColors = false;
            text.Refresh();
        }

        private void but_valider_Click(object sender, EventArgs e)
        {
            Utilisateur util  = this.rechUtil(this.text_courriel.Text, this.text_motDePasse.Text);
            if(util == null)
            {
                admin = this.rechAdmin(this.text_courriel.Text, this.text_motDePasse.Text);
                    if(admin != null)
                    {
                        this.Hide();
                        Form_Admin adminform = new Form_Admin(con, dbpf, admin);
                        adminform.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        if (MetroMessageBox.Show(this, "Aucun client trouvé", "Erreur", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            this.text_courriel.Text = "";
                            this.text_motDePasse.Text = "";
                        }
                        else
                            this.Close();
                    }
            }
            else
            {
                this.Hide();
                Form_Utilisateur utiform = new Form_Utilisateur(con, dbpf, util.Courriel);
                utiform.ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// Méthode qui recherche un utilsateur en passant en parametre son courriel et son mot de passe
        /// </summary>
        /// <param name="courriel">Courriel</param>
        /// <param name="motDePasse">Mot de Passe</param>
        /// <returns>l'utilisateur trouvé ou non </returns>
        private Utilisateur rechUtil(string courriel, string motDePasse)
        {
            try
            {                
                string requete = "SELECT * FROM IHM_UTILISATEUR WHERE COURRIEL='" + courriel + "'"
                    + "AND PASSWORD='" + motDePasse + "'";
                OracleCommand command = new OracleCommand(requete, con);
                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //Variable nécessaire pour construire un utilisateur
                    string courrielS = "";
                    string mdp = "";
                    string nom = "";
                    string prenom = "";
                    string preference = "";
                    DateTime dC = new DateTime(1998, 04, 30); 
                    DateTime dN = new DateTime(1998,04,30);
                    Image img = null;
                    //récupération des données d'utilisateur

                        courrielS = reader["COURRIEL"].ToString().Trim();
                        mdp = reader["PASSWORD"].ToString().Trim();
                        nom = reader["NOM"].ToString().Trim();
                        prenom = reader["PRENOM"].ToString().Trim();
                        preference = reader["PREFERENCE"].ToString().Trim();
                        dC = DateTime.Parse(reader["DATECREATION"].ToString().Trim());
                        dN = DateTime.Parse(reader["DATECREATION"].ToString().Trim());

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
                    
                    reader.Close();
                    Utilisateur res = new Utilisateur(courrielS, mdp, nom, prenom, dC, dN, preference, img);
                    return res;
                }
                else
                {
                    return null;
                } 
            }
            catch (Exception ec)
            {
                MetroMessageBox.Show(this, ec.Message, "ERREUR :'(");
                return null;
            }
        }

        /// <summary>
        /// Méthode pour recherhce un adminis
        /// </summary>
        /// <param name="courriel">Courriel</param>
        /// <param name="motDePasse">Mot de passe</param>
        /// <returns>L'administrater trouvé</returns>
        private Administrateur rechAdmin(string courriel, string motDePasse)
        {
            try
            {
                string requete = "SELECT * FROM IHM_ADMINISTRATEUR WHERE COURRIEL='" + courriel + "'"
                    + "AND PASSWORD='" + motDePasse + "'";
                OracleCommand command = new OracleCommand(requete, con);
                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //Variable nécessaire pour construire un utilisateur
                    string courrielS = "";
                    string mdp = "";
                    string nom = "";
                    string prenom = "";
                    DateTime dN = new DateTime(1998, 04, 30);
                    Image img = null;
                    //récupération des données d'utilisateur

                    courrielS = reader["COURRIEL"].ToString().Trim();
                    mdp = reader["PASSWORD"].ToString().Trim();
                    nom = reader["NOM"].ToString().Trim();
                    prenom = reader["PRENOM"].ToString().Trim();
                    dN = DateTime.Parse(reader["DATEN"].ToString().Trim());

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

                    reader.Close();
                    Administrateur admin = new Administrateur(nom, prenom, courrielS, mdp, dN, img);
                    return admin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ec)
            {
                MetroMessageBox.Show(this, ec.Message, "ERREUR :'(");
                return null;
            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Nouv_Util nouv_Util = new Form_Nouv_Util(con, dbpf);
            nouv_Util.ShowDialog();
            this.Close();
        }

        private void but_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
