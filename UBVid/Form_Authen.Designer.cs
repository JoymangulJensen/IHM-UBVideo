namespace UBVid
{
    partial class Form_Authen
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
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.text_courriel = new MetroFramework.Controls.MetroTextBox();
            this.text_motDePasse = new MetroFramework.Controls.MetroTextBox();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.but_valider = new MetroFramework.Controls.MetroButton();
            this.but_Annuler = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleExtender1
            // 
            this.metroStyleExtender1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(24, 117);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Courriel :";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(24, 160);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(129, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Mot de passe :";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(124, 75);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(202, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Entrez vos identifiants";
            this.metroLabel3.UseStyleColors = true;
            // 
            // text_courriel
            // 
            this.text_courriel.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.text_courriel.Lines = new string[0];
            this.text_courriel.Location = new System.Drawing.Point(163, 117);
            this.text_courriel.MaxLength = 32767;
            this.text_courriel.Name = "text_courriel";
            this.text_courriel.PasswordChar = '\0';
            this.text_courriel.PromptText = "Courriel";
            this.text_courriel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_courriel.SelectedText = "";
            this.text_courriel.Size = new System.Drawing.Size(253, 30);
            this.text_courriel.TabIndex = 3;
            this.text_courriel.UseSelectable = true;
            this.text_courriel.Enter += new System.EventHandler(this.text_courriel_Enter);
            this.text_courriel.Leave += new System.EventHandler(this.text_courriel_Leave);
            // 
            // text_motDePasse
            // 
            this.text_motDePasse.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.text_motDePasse.Lines = new string[0];
            this.text_motDePasse.Location = new System.Drawing.Point(163, 155);
            this.text_motDePasse.MaxLength = 32767;
            this.text_motDePasse.Name = "text_motDePasse";
            this.text_motDePasse.PasswordChar = '*';
            this.text_motDePasse.PromptText = "Mot De Passe";
            this.text_motDePasse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_motDePasse.SelectedText = "";
            this.text_motDePasse.Size = new System.Drawing.Size(253, 30);
            this.text_motDePasse.TabIndex = 4;
            this.text_motDePasse.UseSelectable = true;
            this.text_motDePasse.Enter += new System.EventHandler(this.text_courriel_Enter);
            this.text_motDePasse.Leave += new System.EventHandler(this.text_courriel_Leave);
            // 
            // metroLink1
            // 
            this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink1.Location = new System.Drawing.Point(291, 196);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(120, 22);
            this.metroLink1.TabIndex = 5;
            this.metroLink1.Text = "Nouvel Utilisateur?";
            this.metroLink1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLink1.UseSelectable = true;
            this.metroLink1.UseStyleColors = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // but_valider
            // 
            this.but_valider.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.but_valider.Location = new System.Drawing.Point(228, 228);
            this.but_valider.Name = "but_valider";
            this.but_valider.Size = new System.Drawing.Size(188, 38);
            this.but_valider.TabIndex = 6;
            this.but_valider.Text = "Valider";
            this.but_valider.UseSelectable = true;
            this.but_valider.UseStyleColors = true;
            this.but_valider.Click += new System.EventHandler(this.but_valider_Click);
            // 
            // but_Annuler
            // 
            this.but_Annuler.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.but_Annuler.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.but_Annuler.Location = new System.Drawing.Point(24, 228);
            this.but_Annuler.Name = "but_Annuler";
            this.but_Annuler.Size = new System.Drawing.Size(188, 38);
            this.but_Annuler.TabIndex = 7;
            this.but_Annuler.Text = "Annuler";
            this.but_Annuler.UseSelectable = true;
            this.but_Annuler.Click += new System.EventHandler(this.but_Annuler_Click);
            // 
            // Form_Authen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 282);
            this.Controls.Add(this.but_Annuler);
            this.Controls.Add(this.but_valider);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.text_motDePasse);
            this.Controls.Add(this.text_courriel);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Form_Authen";
            this.Opacity = 0.8D;
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "UBVid";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton but_Annuler;
        private MetroFramework.Controls.MetroButton but_valider;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroTextBox text_motDePasse;
        private MetroFramework.Controls.MetroTextBox text_courriel;
    }
}