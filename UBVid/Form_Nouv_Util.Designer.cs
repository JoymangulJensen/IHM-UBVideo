namespace UBVid
{
    partial class Form_Nouv_Util
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.text_nom = new MetroFramework.Controls.MetroTextBox();
            this.text_prenom = new MetroFramework.Controls.MetroTextBox();
            this.text_courriel = new MetroFramework.Controls.MetroTextBox();
            this.text_motDePasse = new MetroFramework.Controls.MetroTextBox();
            this.text_motDePasse2 = new MetroFramework.Controls.MetroTextBox();
            this.text_preference = new MetroFramework.Controls.MetroTextBox();
            this.date_naissance = new MetroFramework.Controls.MetroDateTime();
            this.but_valider = new MetroFramework.Controls.MetroButton();
            this.but_annuler = new MetroFramework.Controls.MetroButton();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroStyleExtender1
            // 
            this.metroStyleExtender1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBox1
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.pictureBox1, true);
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::UBVid.Properties.Resources.up;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ErrorImage = global::UBVid.Properties.Resources.up;
            this.pictureBox1.Location = new System.Drawing.Point(424, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 331);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 82);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(129, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nom :";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(23, 185);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(129, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Courriel :";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(23, 133);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(129, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Prénom :";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel4
            // 
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(23, 237);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(129, 25);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Mot de passe :";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel5
            // 
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(23, 332);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(129, 25);
            this.metroLabel5.TabIndex = 4;
            this.metroLabel5.Text = "Date de naissance :";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel7
            // 
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(23, 388);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(129, 25);
            this.metroLabel7.TabIndex = 6;
            this.metroLabel7.Text = "Préférence :";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_nom
            // 
            this.text_nom.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.text_nom.Lines = new string[0];
            this.text_nom.Location = new System.Drawing.Point(188, 82);
            this.text_nom.MaxLength = 32767;
            this.text_nom.Name = "text_nom";
            this.text_nom.PasswordChar = '\0';
            this.text_nom.PromptText = "Nom";
            this.text_nom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_nom.SelectedText = "";
            this.text_nom.Size = new System.Drawing.Size(223, 25);
            this.text_nom.TabIndex = 7;
            this.text_nom.UseSelectable = true;
            this.text_nom.Enter += new System.EventHandler(this.text_nom_Enter);
            this.text_nom.Leave += new System.EventHandler(this.text_nom_Leave);
            // 
            // text_prenom
            // 
            this.text_prenom.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.text_prenom.Lines = new string[0];
            this.text_prenom.Location = new System.Drawing.Point(188, 133);
            this.text_prenom.MaxLength = 32767;
            this.text_prenom.Name = "text_prenom";
            this.text_prenom.PasswordChar = '\0';
            this.text_prenom.PromptText = "Prénom";
            this.text_prenom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_prenom.SelectedText = "";
            this.text_prenom.Size = new System.Drawing.Size(223, 25);
            this.text_prenom.TabIndex = 8;
            this.text_prenom.UseSelectable = true;
            this.text_prenom.Enter += new System.EventHandler(this.text_nom_Enter);
            this.text_prenom.Leave += new System.EventHandler(this.text_nom_Leave);
            // 
            // text_courriel
            // 
            this.text_courriel.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.text_courriel.Lines = new string[0];
            this.text_courriel.Location = new System.Drawing.Point(188, 185);
            this.text_courriel.MaxLength = 32767;
            this.text_courriel.Name = "text_courriel";
            this.text_courriel.PasswordChar = '\0';
            this.text_courriel.PromptText = "Courriel";
            this.text_courriel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_courriel.SelectedText = "";
            this.text_courriel.Size = new System.Drawing.Size(223, 25);
            this.text_courriel.TabIndex = 9;
            this.text_courriel.UseSelectable = true;
            this.text_courriel.Enter += new System.EventHandler(this.text_nom_Enter);
            this.text_courriel.Leave += new System.EventHandler(this.text_nom_Leave);
            // 
            // text_motDePasse
            // 
            this.text_motDePasse.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.text_motDePasse.Lines = new string[0];
            this.text_motDePasse.Location = new System.Drawing.Point(188, 237);
            this.text_motDePasse.MaxLength = 32767;
            this.text_motDePasse.Name = "text_motDePasse";
            this.text_motDePasse.PasswordChar = '*';
            this.text_motDePasse.PromptText = "Mot de passe";
            this.text_motDePasse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_motDePasse.SelectedText = "";
            this.text_motDePasse.Size = new System.Drawing.Size(223, 25);
            this.text_motDePasse.TabIndex = 10;
            this.text_motDePasse.UseSelectable = true;
            this.text_motDePasse.TextChanged += new System.EventHandler(this.text_motDePasse_TextChanged);
            this.text_motDePasse.Enter += new System.EventHandler(this.text_nom_Enter);
            this.text_motDePasse.Leave += new System.EventHandler(this.text_nom_Leave);
            // 
            // text_motDePasse2
            // 
            this.text_motDePasse2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.text_motDePasse2.Lines = new string[0];
            this.text_motDePasse2.Location = new System.Drawing.Point(188, 278);
            this.text_motDePasse2.MaxLength = 32767;
            this.text_motDePasse2.Name = "text_motDePasse2";
            this.text_motDePasse2.PasswordChar = '*';
            this.text_motDePasse2.PromptText = "Verifier mot de passe";
            this.text_motDePasse2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_motDePasse2.SelectedText = "";
            this.text_motDePasse2.Size = new System.Drawing.Size(223, 25);
            this.text_motDePasse2.TabIndex = 11;
            this.text_motDePasse2.UseSelectable = true;
            this.text_motDePasse2.TextChanged += new System.EventHandler(this.text_motDePasse2_TextChanged);
            this.text_motDePasse2.Enter += new System.EventHandler(this.text_nom_Enter);
            this.text_motDePasse2.Leave += new System.EventHandler(this.text_nom_Leave);
            // 
            // text_preference
            // 
            this.text_preference.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.text_preference.Lines = new string[0];
            this.text_preference.Location = new System.Drawing.Point(188, 388);
            this.text_preference.MaxLength = 32767;
            this.text_preference.Name = "text_preference";
            this.text_preference.PasswordChar = '\0';
            this.text_preference.PromptText = "Préférence";
            this.text_preference.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_preference.SelectedText = "";
            this.text_preference.Size = new System.Drawing.Size(223, 25);
            this.text_preference.TabIndex = 13;
            this.text_preference.UseSelectable = true;
            this.text_preference.Enter += new System.EventHandler(this.text_nom_Enter);
            this.text_preference.Leave += new System.EventHandler(this.text_nom_Leave);
            // 
            // date_naissance
            // 
            this.date_naissance.Location = new System.Drawing.Point(188, 332);
            this.date_naissance.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_naissance.Name = "date_naissance";
            this.date_naissance.Size = new System.Drawing.Size(223, 29);
            this.date_naissance.TabIndex = 14;
            // 
            // but_valider
            // 
            this.but_valider.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.but_valider.Highlight = true;
            this.but_valider.Location = new System.Drawing.Point(409, 437);
            this.but_valider.Name = "but_valider";
            this.but_valider.Size = new System.Drawing.Size(192, 36);
            this.but_valider.TabIndex = 16;
            this.but_valider.Text = "Valider";
            this.but_valider.UseSelectable = true;
            this.but_valider.UseStyleColors = true;
            this.but_valider.Click += new System.EventHandler(this.but_valider_Click);
            // 
            // but_annuler
            // 
            this.but_annuler.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.but_annuler.Location = new System.Drawing.Point(156, 437);
            this.but_annuler.Name = "but_annuler";
            this.but_annuler.Size = new System.Drawing.Size(192, 36);
            this.but_annuler.TabIndex = 17;
            this.but_annuler.Text = "Annuler";
            this.but_annuler.UseSelectable = true;
            this.but_annuler.Click += new System.EventHandler(this.but_annuler_Click);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::UBVid.Properties.Resources.check_mark_orange_hi;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(144, 278);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 25);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Form_Nouv_Util
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 496);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.but_annuler);
            this.Controls.Add(this.but_valider);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.date_naissance);
            this.Controls.Add(this.text_preference);
            this.Controls.Add(this.text_motDePasse2);
            this.Controls.Add(this.text_motDePasse);
            this.Controls.Add(this.text_courriel);
            this.Controls.Add(this.text_prenom);
            this.Controls.Add(this.text_nom);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Form_Nouv_Util";
            this.Opacity = 0.98D;
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Nouvel Inscription";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Controls.MetroTextBox text_nom;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroDateTime date_naissance;
        private MetroFramework.Controls.MetroTextBox text_preference;
        private MetroFramework.Controls.MetroTextBox text_motDePasse2;
        private MetroFramework.Controls.MetroTextBox text_motDePasse;
        private MetroFramework.Controls.MetroTextBox text_courriel;
        private MetroFramework.Controls.MetroTextBox text_prenom;
        private MetroFramework.Controls.MetroButton but_valider;
        private MetroFramework.Controls.MetroButton but_annuler;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}