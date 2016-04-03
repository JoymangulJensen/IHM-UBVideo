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
    public partial class Form_Nouv_Util : MetroForm
    {
        private OracleConnection con;
        private DbProviderFactory dbpf;

        private Image img;
        public Form_Nouv_Util(OracleConnection c, DbProviderFactory d)
        {
            InitializeComponent();
            con = c;
            dbpf = d;
            this.date_naissance.MaxDate = DateTime.Now.AddYears(-14);
        }


        /// <summary>
        /// Méthode qui convertie une image en tableau de bytes
        /// </summary>
        /// <param name="imageIn">Une image</param>
        /// <returns>Tableau de byte</returns>
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Images (*.bmp, *.jpg, *.png) | *.bmp;*.jpg;*.png";
            DialogResult result = diag.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.img = Image.FromFile(diag.FileName.ToString());
                this.pictureBox1.Image = img;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void text_nom_Enter(object sender, EventArgs e)
        {
            MetroTextBox tb = (MetroTextBox)sender;
            tb.UseStyleColors = true;
            tb.Refresh();
        }

        private void text_nom_Leave(object sender, EventArgs e)
        {
            MetroTextBox tb = (MetroTextBox)sender;
            tb.UseStyleColors = false;
            tb.Refresh();
        }



        /// <summary>
        /// Action quand on click sur le button valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_valider_Click(object sender, EventArgs e)
        {
            if (this.text_nom.Text == "")
                this.metroToolTip1.Show("Entrez votre nom", this.text_nom, 1500);
            else if (this.text_courriel.Text == "")
                this.metroToolTip1.Show("Entrez votre courriel", this.text_courriel, 1500);
            else if (this.text_motDePasse2.Text == "")
                this.metroToolTip1.Show("Entrez votre mot de passe", this.text_motDePasse, 1500);
            else if (this.img == null)
                this.metroToolTip1.Show("Choissiez une image", this.pictureBox1, 1500);
            else if (this.text_motDePasse.Text != this.text_motDePasse2.Text)
            {
                this.text_motDePasse.Focus();
                this.metroToolTip1.Show("Erreur veuillez vérifier vôtre mot de passe", this.text_motDePasse, 1500);
            }
            else
            {
                try
                {
                    //la requete sql pour ajouter l'utilisateur dans la base de donnée
                    string requete;
                    requete = "insert into IHM_UTILISATEUR(NOM,PRENOM,COURRIEL,PASSWORD,DATECREATION,DATEN,PREFERENCE,IMAGE)";
                    requete += "values('" + this.text_nom.Text + "'," +
                        "'" + this.text_prenom.Text + "'," +
                        "'" + this.text_courriel.Text + "'," +
                        "'" + this.text_motDePasse2.Text + "'," +
                        "'" + DateTime.Now.ToString("dd/MM/yyyy") + "'," +
                        "'" + this.date_naissance.Value.ToString("dd/MM/yyyy") + "'," +
                        "'" + this.text_preference.Text + "'," +
                        " :BlobParameter )";

                    //code pour mettre l'image dans la base de donnée
                    //le code est inspiré du code http://www.codeproject.com/Articles/13365/Insert-retrieve-an-image-into-from-a-blob-field-in
                    //mettre l'image dans un tableau de bits
                    byte[] blob = this.imageToByteArray(this.img);


                    //insert the byte as oracle parameter of type blob 
                    OracleParameter blobParameter = new OracleParameter();
                    blobParameter.OracleDbType = OracleDbType.Blob;
                    blobParameter.ParameterName = "BlobParameter";
                    blobParameter.Value = blob;


                    OracleCommand cmnd = con.CreateCommand();
                    cmnd = new OracleCommand(requete, con);
                    cmnd.Parameters.Add(blobParameter);
                    cmnd.ExecuteNonQuery();
                    MetroMessageBox.Show(this, "Vous avez été enregistrée", "Réussit :D", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //Fermeture de la fenêtre et ouverture de la fenêtre d'authentification
                    this.Hide();
                    Form_Authen authentification = new Form_Authen();
                    authentification.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "ERREUR :'(");
                }
            }
        }

        private void text_motDePasse2_TextChanged(object sender, EventArgs e)
        {
            if (this.text_motDePasse.Text == this.text_motDePasse2.Text)
            {
                this.pictureBox2.Visible = true;
            }
            else
                this.pictureBox2.Visible = false;
        }

        private void text_motDePasse_TextChanged(object sender, EventArgs e)
        {
            this.text_motDePasse2.Text = "";
            this.pictureBox2.Visible = false;
        }

        private void but_annuler_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Authen authentification = new Form_Authen();
            authentification.ShowDialog();
            this.Close();
        }
    }
}
