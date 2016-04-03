namespace UBVid
{
    partial class Form_Utilisateur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage tab_Donnee;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.utilisateurImagePictureBox = new System.Windows.Forms.PictureBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.utilisateurDateNaissanceDateTimePicker = new MetroFramework.Controls.MetroDateTime();
            this.utilisateurAppliquerModificationButton = new MetroFramework.Controls.MetroButton();
            this.utilisateurPrenomTextBox = new System.Windows.Forms.TextBox();
            this.utilisateurNomTextBox = new System.Windows.Forms.TextBox();
            this.utilisateurMembreDepuisLabel = new MetroFramework.Controls.MetroLabel();
            this.utilisateurNouveauMDPTextBox = new MetroFramework.Controls.MetroLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.utilisateurAncienMDPTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.utilisateurMailLabel = new System.Windows.Forms.Label();
            this.utilisateurPrenomLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tab_Serie = new MetroFramework.Controls.MetroTabPage();
            this.ordreApparitionCombo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.genreCombo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabelNote = new MetroFramework.Controls.MetroLabel();
            this.suiviButton = new MetroFramework.Controls.MetroButton();
            this.noteComboBox = new MetroFramework.Controls.MetroComboBox();
            this.reInit = new MetroFramework.Controls.MetroButton();
            this.fichePanel = new MetroFramework.Controls.MetroPanel();
            this.ficheSeriePanel = new MetroFramework.Controls.MetroPanel();
            this.castingSerieLabel = new System.Windows.Forms.Label();
            this.realisationSerieLabel = new System.Windows.Forms.Label();
            this.genreSerieLabel = new System.Windows.Forms.Label();
            this.productionSerieLabel = new System.Windows.Forms.Label();
            this.imageSeriePictureBox = new System.Windows.Forms.PictureBox();
            this.synopsieSerieTextBox = new System.Windows.Forms.TextBox();
            this.titre = new System.Windows.Forms.Label();
            this.ficheEpisodePanel = new MetroFramework.Controls.MetroPanel();
            this.retourButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.synopsisEpisodeTextBox = new System.Windows.Forms.TextBox();
            this.dateEpisodeLabel = new MetroFramework.Controls.MetroLabel();
            this.diffusionEpisodeLabel = new MetroFramework.Controls.MetroLabel();
            this.titreEpisodeLabel = new System.Windows.Forms.Label();
            this.nomEpisodeLabel = new MetroFramework.Controls.MetroLabel();
            this.listeSeriePanel = new MetroFramework.Controls.MetroPanel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tab_Planning = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.initGridButton = new MetroFramework.Controls.MetroButton();
            this.planingMetroGrid = new MetroFramework.Controls.MetroGrid();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.htmlToolTip2 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.utilisateurLogin = new MetroFramework.Controls.MetroLabel();
            this.utilisateurImageAvatar = new System.Windows.Forms.PictureBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            tab_Donnee = new System.Windows.Forms.TabPage();
            tab_Donnee.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilisateurImagePictureBox)).BeginInit();
            this.tab_Serie.SuspendLayout();
            this.fichePanel.SuspendLayout();
            this.ficheSeriePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSeriePictureBox)).BeginInit();
            this.ficheEpisodePanel.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.tab_Planning.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planingMetroGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilisateurImageAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_Donnee
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(tab_Donnee, true);
            tab_Donnee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            tab_Donnee.Controls.Add(this.metroPanel1);
            tab_Donnee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            tab_Donnee.Location = new System.Drawing.Point(4, 38);
            tab_Donnee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tab_Donnee.Name = "tab_Donnee";
            tab_Donnee.Size = new System.Drawing.Size(1535, 844);
            tab_Donnee.TabIndex = 5;
            tab_Donnee.Text = "Mon compte";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.utilisateurImagePictureBox);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.utilisateurDateNaissanceDateTimePicker);
            this.metroPanel1.Controls.Add(this.utilisateurAppliquerModificationButton);
            this.metroPanel1.Controls.Add(this.utilisateurPrenomTextBox);
            this.metroPanel1.Controls.Add(this.utilisateurNomTextBox);
            this.metroPanel1.Controls.Add(this.utilisateurMembreDepuisLabel);
            this.metroPanel1.Controls.Add(this.utilisateurNouveauMDPTextBox);
            this.metroPanel1.Controls.Add(this.textBox2);
            this.metroPanel1.Controls.Add(this.utilisateurAncienMDPTextBox);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.utilisateurMailLabel);
            this.metroPanel1.Controls.Add(this.utilisateurPrenomLabel);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(4, 4);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1525, 762);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // utilisateurImagePictureBox
            // 
            this.utilisateurImagePictureBox.Location = new System.Drawing.Point(593, 106);
            this.utilisateurImagePictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurImagePictureBox.Name = "utilisateurImagePictureBox";
            this.utilisateurImagePictureBox.Size = new System.Drawing.Size(360, 332);
            this.utilisateurImagePictureBox.TabIndex = 18;
            this.utilisateurImagePictureBox.TabStop = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(33, 188);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(127, 20);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel3.TabIndex = 17;
            this.metroLabel3.Text = "date de naissance :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // utilisateurDateNaissanceDateTimePicker
            // 
            this.utilisateurDateNaissanceDateTimePicker.Location = new System.Drawing.Point(200, 188);
            this.utilisateurDateNaissanceDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurDateNaissanceDateTimePicker.MinimumSize = new System.Drawing.Size(0, 30);
            this.utilisateurDateNaissanceDateTimePicker.Name = "utilisateurDateNaissanceDateTimePicker";
            this.utilisateurDateNaissanceDateTimePicker.Size = new System.Drawing.Size(272, 30);
            this.utilisateurDateNaissanceDateTimePicker.TabIndex = 16;
            // 
            // utilisateurAppliquerModificationButton
            // 
            this.utilisateurAppliquerModificationButton.Location = new System.Drawing.Point(108, 474);
            this.utilisateurAppliquerModificationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurAppliquerModificationButton.Name = "utilisateurAppliquerModificationButton";
            this.utilisateurAppliquerModificationButton.Size = new System.Drawing.Size(365, 60);
            this.utilisateurAppliquerModificationButton.Style = MetroFramework.MetroColorStyle.Orange;
            this.utilisateurAppliquerModificationButton.TabIndex = 15;
            this.utilisateurAppliquerModificationButton.Text = "appliquer modification";
            this.utilisateurAppliquerModificationButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.utilisateurAppliquerModificationButton.UseSelectable = true;
            this.utilisateurAppliquerModificationButton.Click += new System.EventHandler(this.utilisateurAppliquerModificationButton_Click);
            // 
            // utilisateurPrenomTextBox
            // 
            this.utilisateurPrenomTextBox.Location = new System.Drawing.Point(200, 106);
            this.utilisateurPrenomTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurPrenomTextBox.Name = "utilisateurPrenomTextBox";
            this.utilisateurPrenomTextBox.Size = new System.Drawing.Size(272, 22);
            this.utilisateurPrenomTextBox.TabIndex = 14;
            // 
            // utilisateurNomTextBox
            // 
            this.utilisateurNomTextBox.Location = new System.Drawing.Point(200, 145);
            this.utilisateurNomTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurNomTextBox.Name = "utilisateurNomTextBox";
            this.utilisateurNomTextBox.Size = new System.Drawing.Size(272, 22);
            this.utilisateurNomTextBox.TabIndex = 13;
            // 
            // utilisateurMembreDepuisLabel
            // 
            this.utilisateurMembreDepuisLabel.AutoSize = true;
            this.utilisateurMembreDepuisLabel.Location = new System.Drawing.Point(1107, 107);
            this.utilisateurMembreDepuisLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.utilisateurMembreDepuisLabel.Name = "utilisateurMembreDepuisLabel";
            this.utilisateurMembreDepuisLabel.Size = new System.Drawing.Size(107, 20);
            this.utilisateurMembreDepuisLabel.Style = MetroFramework.MetroColorStyle.Orange;
            this.utilisateurMembreDepuisLabel.TabIndex = 12;
            this.utilisateurMembreDepuisLabel.Text = "membre depuis";
            this.utilisateurMembreDepuisLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // utilisateurNouveauMDPTextBox
            // 
            this.utilisateurNouveauMDPTextBox.AutoSize = true;
            this.utilisateurNouveauMDPTextBox.Location = new System.Drawing.Point(135, 145);
            this.utilisateurNouveauMDPTextBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.utilisateurNouveauMDPTextBox.Name = "utilisateurNouveauMDPTextBox";
            this.utilisateurNouveauMDPTextBox.Size = new System.Drawing.Size(44, 20);
            this.utilisateurNouveauMDPTextBox.Style = MetroFramework.MetroColorStyle.Orange;
            this.utilisateurNouveauMDPTextBox.TabIndex = 11;
            this.utilisateurNouveauMDPTextBox.Text = "nom :";
            this.utilisateurNouveauMDPTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(159, 398);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 22);
            this.textBox2.TabIndex = 10;
            // 
            // utilisateurAncienMDPTextBox
            // 
            this.utilisateurAncienMDPTextBox.Location = new System.Drawing.Point(244, 555);
            this.utilisateurAncienMDPTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurAncienMDPTextBox.Name = "utilisateurAncienMDPTextBox";
            this.utilisateurAncienMDPTextBox.Size = new System.Drawing.Size(228, 22);
            this.utilisateurAncienMDPTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(153, 364);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "modifier mot de passe";
            // 
            // utilisateurMailLabel
            // 
            this.utilisateurMailLabel.AutoSize = true;
            this.utilisateurMailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.utilisateurMailLabel.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilisateurMailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.utilisateurMailLabel.Location = new System.Drawing.Point(55, 38);
            this.utilisateurMailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.utilisateurMailLabel.Name = "utilisateurMailLabel";
            this.utilisateurMailLabel.Size = new System.Drawing.Size(101, 54);
            this.utilisateurMailLabel.TabIndex = 7;
            this.utilisateurMailLabel.Text = "mail";
            // 
            // utilisateurPrenomLabel
            // 
            this.utilisateurPrenomLabel.AutoSize = true;
            this.utilisateurPrenomLabel.Location = new System.Drawing.Point(108, 107);
            this.utilisateurPrenomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.utilisateurPrenomLabel.Name = "utilisateurPrenomLabel";
            this.utilisateurPrenomLabel.Size = new System.Drawing.Size(65, 20);
            this.utilisateurPrenomLabel.Style = MetroFramework.MetroColorStyle.Orange;
            this.utilisateurPrenomLabel.TabIndex = 6;
            this.utilisateurPrenomLabel.Text = "prenom :";
            this.utilisateurPrenomLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(109, 555);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(99, 20);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel5.TabIndex = 4;
            this.metroLabel5.Text = "mot de passe :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tab_Serie
            // 
            this.tab_Serie.Controls.Add(this.ordreApparitionCombo);
            this.tab_Serie.Controls.Add(this.metroLabel1);
            this.tab_Serie.Controls.Add(this.genreCombo);
            this.tab_Serie.Controls.Add(this.metroLabelNote);
            this.tab_Serie.Controls.Add(this.suiviButton);
            this.tab_Serie.Controls.Add(this.noteComboBox);
            this.tab_Serie.Controls.Add(this.reInit);
            this.tab_Serie.Controls.Add(this.fichePanel);
            this.tab_Serie.Controls.Add(this.listeSeriePanel);
            this.tab_Serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Serie.HorizontalScrollbar = true;
            this.tab_Serie.HorizontalScrollbarBarColor = true;
            this.tab_Serie.HorizontalScrollbarHighlightOnWheel = false;
            this.tab_Serie.HorizontalScrollbarSize = 12;
            this.tab_Serie.Location = new System.Drawing.Point(4, 38);
            this.tab_Serie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_Serie.Name = "tab_Serie";
            this.tab_Serie.Padding = new System.Windows.Forms.Padding(33, 31, 33, 31);
            this.tab_Serie.Size = new System.Drawing.Size(1535, 844);
            this.tab_Serie.TabIndex = 3;
            this.tab_Serie.Text = "Série";
            this.tab_Serie.VerticalScrollbar = true;
            this.tab_Serie.VerticalScrollbarBarColor = true;
            this.tab_Serie.VerticalScrollbarHighlightOnWheel = false;
            this.tab_Serie.VerticalScrollbarSize = 13;
            this.tab_Serie.Visible = false;
            // 
            // ordreApparitionCombo
            // 
            this.ordreApparitionCombo.FormattingEnabled = true;
            this.ordreApparitionCombo.ItemHeight = 23;
            this.ordreApparitionCombo.Location = new System.Drawing.Point(491, 795);
            this.ordreApparitionCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordreApparitionCombo.Name = "ordreApparitionCombo";
            this.ordreApparitionCombo.Size = new System.Drawing.Size(240, 29);
            this.ordreApparitionCombo.TabIndex = 10;
            this.ordreApparitionCombo.UseSelectable = true;
            this.ordreApparitionCombo.SelectedIndexChanged += new System.EventHandler(this.ordreApparitionCombo_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(185, 800);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(55, 20);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Genre :";
            // 
            // genreCombo
            // 
            this.genreCombo.FormattingEnabled = true;
            this.genreCombo.ItemHeight = 23;
            this.genreCombo.Items.AddRange(new object[] {
            "aucun"});
            this.genreCombo.Location = new System.Drawing.Point(261, 795);
            this.genreCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.genreCombo.Name = "genreCombo";
            this.genreCombo.Size = new System.Drawing.Size(160, 29);
            this.genreCombo.TabIndex = 8;
            this.genreCombo.UseSelectable = true;
            this.genreCombo.SelectedIndexChanged += new System.EventHandler(this.genreCombo_SelectedIndexChanged);
            // 
            // metroLabelNote
            // 
            this.metroLabelNote.AutoSize = true;
            this.metroLabelNote.Location = new System.Drawing.Point(1131, 800);
            this.metroLabelNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabelNote.Name = "metroLabelNote";
            this.metroLabelNote.Size = new System.Drawing.Size(77, 20);
            this.metroLabelNote.TabIndex = 7;
            this.metroLabelNote.Text = "metroNote";
            // 
            // suiviButton
            // 
            this.suiviButton.Location = new System.Drawing.Point(789, 795);
            this.suiviButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.suiviButton.Name = "suiviButton";
            this.suiviButton.Size = new System.Drawing.Size(197, 28);
            this.suiviButton.TabIndex = 6;
            this.suiviButton.Text = "suiviButton";
            this.suiviButton.UseSelectable = true;
            this.suiviButton.Click += new System.EventHandler(this.suiviButton_Click);
            // 
            // noteComboBox
            // 
            this.noteComboBox.FormattingEnabled = true;
            this.noteComboBox.ItemHeight = 23;
            this.noteComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.noteComboBox.Location = new System.Drawing.Point(1257, 795);
            this.noteComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.noteComboBox.Name = "noteComboBox";
            this.noteComboBox.Size = new System.Drawing.Size(219, 29);
            this.noteComboBox.TabIndex = 5;
            this.noteComboBox.UseSelectable = true;
            this.noteComboBox.SelectedIndexChanged += new System.EventHandler(this.noteComboBox_SelectedIndexChanged);
            // 
            // reInit
            // 
            this.reInit.Location = new System.Drawing.Point(8, 795);
            this.reInit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reInit.Name = "reInit";
            this.reInit.Size = new System.Drawing.Size(100, 28);
            this.reInit.TabIndex = 4;
            this.reInit.Text = "reinitialiser";
            this.reInit.UseSelectable = true;
            this.reInit.Click += new System.EventHandler(this.reInit_Click);
            // 
            // fichePanel
            // 
            this.fichePanel.AutoScroll = true;
            this.fichePanel.Controls.Add(this.ficheSeriePanel);
            this.fichePanel.Controls.Add(this.ficheEpisodePanel);
            this.fichePanel.HorizontalScrollbar = true;
            this.fichePanel.HorizontalScrollbarBarColor = true;
            this.fichePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.fichePanel.HorizontalScrollbarSize = 12;
            this.fichePanel.Location = new System.Drawing.Point(740, 7);
            this.fichePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fichePanel.Name = "fichePanel";
            this.fichePanel.Size = new System.Drawing.Size(752, 780);
            this.fichePanel.TabIndex = 3;
            this.fichePanel.VerticalScrollbar = true;
            this.fichePanel.VerticalScrollbarBarColor = true;
            this.fichePanel.VerticalScrollbarHighlightOnWheel = false;
            this.fichePanel.VerticalScrollbarSize = 13;
            // 
            // ficheSeriePanel
            // 
            this.ficheSeriePanel.Controls.Add(this.castingSerieLabel);
            this.ficheSeriePanel.Controls.Add(this.realisationSerieLabel);
            this.ficheSeriePanel.Controls.Add(this.genreSerieLabel);
            this.ficheSeriePanel.Controls.Add(this.productionSerieLabel);
            this.ficheSeriePanel.Controls.Add(this.imageSeriePictureBox);
            this.ficheSeriePanel.Controls.Add(this.synopsieSerieTextBox);
            this.ficheSeriePanel.Controls.Add(this.titre);
            this.ficheSeriePanel.HorizontalScrollbarBarColor = true;
            this.ficheSeriePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ficheSeriePanel.HorizontalScrollbarSize = 12;
            this.ficheSeriePanel.Location = new System.Drawing.Point(4, 374);
            this.ficheSeriePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ficheSeriePanel.Name = "ficheSeriePanel";
            this.ficheSeriePanel.Size = new System.Drawing.Size(733, 369);
            this.ficheSeriePanel.Style = MetroFramework.MetroColorStyle.Orange;
            this.ficheSeriePanel.TabIndex = 3;
            this.ficheSeriePanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ficheSeriePanel.VerticalScrollbarBarColor = true;
            this.ficheSeriePanel.VerticalScrollbarHighlightOnWheel = false;
            this.ficheSeriePanel.VerticalScrollbarSize = 13;
            // 
            // castingSerieLabel
            // 
            this.castingSerieLabel.AutoSize = true;
            this.castingSerieLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.castingSerieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.castingSerieLabel.ForeColor = System.Drawing.Color.White;
            this.castingSerieLabel.Location = new System.Drawing.Point(23, 350);
            this.castingSerieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.castingSerieLabel.Name = "castingSerieLabel";
            this.castingSerieLabel.Size = new System.Drawing.Size(104, 20);
            this.castingSerieLabel.TabIndex = 15;
            this.castingSerieLabel.Text = "castingLabel";
            // 
            // realisationSerieLabel
            // 
            this.realisationSerieLabel.AutoSize = true;
            this.realisationSerieLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.realisationSerieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realisationSerieLabel.ForeColor = System.Drawing.Color.White;
            this.realisationSerieLabel.Location = new System.Drawing.Point(23, 319);
            this.realisationSerieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.realisationSerieLabel.Name = "realisationSerieLabel";
            this.realisationSerieLabel.Size = new System.Drawing.Size(127, 20);
            this.realisationSerieLabel.TabIndex = 14;
            this.realisationSerieLabel.Text = "realisationLabel";
            // 
            // genreSerieLabel
            // 
            this.genreSerieLabel.AutoSize = true;
            this.genreSerieLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.genreSerieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreSerieLabel.ForeColor = System.Drawing.Color.White;
            this.genreSerieLabel.Location = new System.Drawing.Point(23, 284);
            this.genreSerieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.genreSerieLabel.Name = "genreSerieLabel";
            this.genreSerieLabel.Size = new System.Drawing.Size(92, 20);
            this.genreSerieLabel.TabIndex = 13;
            this.genreSerieLabel.Text = "genreLabel";
            // 
            // productionSerieLabel
            // 
            this.productionSerieLabel.AutoSize = true;
            this.productionSerieLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.productionSerieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productionSerieLabel.ForeColor = System.Drawing.Color.White;
            this.productionSerieLabel.Location = new System.Drawing.Point(23, 252);
            this.productionSerieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.productionSerieLabel.Name = "productionSerieLabel";
            this.productionSerieLabel.Size = new System.Drawing.Size(119, 20);
            this.productionSerieLabel.TabIndex = 12;
            this.productionSerieLabel.Text = "productioLabel";
            // 
            // imageSeriePictureBox
            // 
            this.imageSeriePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.imageSeriePictureBox.Location = new System.Drawing.Point(17, 76);
            this.imageSeriePictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imageSeriePictureBox.Name = "imageSeriePictureBox";
            this.imageSeriePictureBox.Size = new System.Drawing.Size(187, 172);
            this.imageSeriePictureBox.TabIndex = 11;
            this.imageSeriePictureBox.TabStop = false;
            // 
            // synopsieSerieTextBox
            // 
            this.synopsieSerieTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.synopsieSerieTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.synopsieSerieTextBox.Enabled = false;
            this.synopsieSerieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.synopsieSerieTextBox.Location = new System.Drawing.Point(227, 76);
            this.synopsieSerieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.synopsieSerieTextBox.Multiline = true;
            this.synopsieSerieTextBox.Name = "synopsieSerieTextBox";
            this.synopsieSerieTextBox.Size = new System.Drawing.Size(491, 172);
            this.synopsieSerieTextBox.TabIndex = 10;
            // 
            // titre
            // 
            this.titre.AutoSize = true;
            this.titre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.titre.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.titre.Location = new System.Drawing.Point(20, 27);
            this.titre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(84, 36);
            this.titre.TabIndex = 2;
            this.titre.Text = "label1";
            // 
            // ficheEpisodePanel
            // 
            this.ficheEpisodePanel.Controls.Add(this.retourButton);
            this.ficheEpisodePanel.Controls.Add(this.metroLabel2);
            this.ficheEpisodePanel.Controls.Add(this.synopsisEpisodeTextBox);
            this.ficheEpisodePanel.Controls.Add(this.dateEpisodeLabel);
            this.ficheEpisodePanel.Controls.Add(this.diffusionEpisodeLabel);
            this.ficheEpisodePanel.Controls.Add(this.titreEpisodeLabel);
            this.ficheEpisodePanel.Controls.Add(this.nomEpisodeLabel);
            this.ficheEpisodePanel.HorizontalScrollbarBarColor = true;
            this.ficheEpisodePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ficheEpisodePanel.HorizontalScrollbarSize = 12;
            this.ficheEpisodePanel.Location = new System.Drawing.Point(4, 4);
            this.ficheEpisodePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ficheEpisodePanel.Name = "ficheEpisodePanel";
            this.ficheEpisodePanel.Size = new System.Drawing.Size(733, 369);
            this.ficheEpisodePanel.Style = MetroFramework.MetroColorStyle.Orange;
            this.ficheEpisodePanel.TabIndex = 2;
            this.ficheEpisodePanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ficheEpisodePanel.VerticalScrollbarBarColor = true;
            this.ficheEpisodePanel.VerticalScrollbarHighlightOnWheel = false;
            this.ficheEpisodePanel.VerticalScrollbarSize = 13;
            // 
            // retourButton
            // 
            this.retourButton.Location = new System.Drawing.Point(617, 324);
            this.retourButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.retourButton.Name = "retourButton";
            this.retourButton.Size = new System.Drawing.Size(100, 28);
            this.retourButton.TabIndex = 13;
            this.retourButton.Text = "retour";
            this.retourButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.retourButton.UseSelectable = true;
            this.retourButton.Click += new System.EventHandler(this.retourButton_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(25, 159);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(69, 20);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Synopsis :";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // synopsisEpisodeTextBox
            // 
            this.synopsisEpisodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.synopsisEpisodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.synopsisEpisodeTextBox.Enabled = false;
            this.synopsisEpisodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.synopsisEpisodeTextBox.Location = new System.Drawing.Point(128, 159);
            this.synopsisEpisodeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.synopsisEpisodeTextBox.Multiline = true;
            this.synopsisEpisodeTextBox.Name = "synopsisEpisodeTextBox";
            this.synopsisEpisodeTextBox.Size = new System.Drawing.Size(517, 146);
            this.synopsisEpisodeTextBox.TabIndex = 11;
            // 
            // dateEpisodeLabel
            // 
            this.dateEpisodeLabel.AutoSize = true;
            this.dateEpisodeLabel.Location = new System.Drawing.Point(27, 124);
            this.dateEpisodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateEpisodeLabel.Name = "dateEpisodeLabel";
            this.dateEpisodeLabel.Size = new System.Drawing.Size(36, 20);
            this.dateEpisodeLabel.TabIndex = 5;
            this.dateEpisodeLabel.Text = "date";
            this.dateEpisodeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // diffusionEpisodeLabel
            // 
            this.diffusionEpisodeLabel.AutoSize = true;
            this.diffusionEpisodeLabel.Location = new System.Drawing.Point(27, 89);
            this.diffusionEpisodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diffusionEpisodeLabel.Name = "diffusionEpisodeLabel";
            this.diffusionEpisodeLabel.Size = new System.Drawing.Size(61, 20);
            this.diffusionEpisodeLabel.TabIndex = 4;
            this.diffusionEpisodeLabel.Text = "diffusion";
            this.diffusionEpisodeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // titreEpisodeLabel
            // 
            this.titreEpisodeLabel.AutoSize = true;
            this.titreEpisodeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.titreEpisodeLabel.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreEpisodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.titreEpisodeLabel.Location = new System.Drawing.Point(20, 20);
            this.titreEpisodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titreEpisodeLabel.Name = "titreEpisodeLabel";
            this.titreEpisodeLabel.Size = new System.Drawing.Size(84, 36);
            this.titreEpisodeLabel.TabIndex = 3;
            this.titreEpisodeLabel.Text = "label1";
            // 
            // nomEpisodeLabel
            // 
            this.nomEpisodeLabel.AutoSize = true;
            this.nomEpisodeLabel.Location = new System.Drawing.Point(25, 54);
            this.nomEpisodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomEpisodeLabel.Name = "nomEpisodeLabel";
            this.nomEpisodeLabel.Size = new System.Drawing.Size(37, 20);
            this.nomEpisodeLabel.TabIndex = 2;
            this.nomEpisodeLabel.Text = "nom";
            this.nomEpisodeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // listeSeriePanel
            // 
            this.listeSeriePanel.AutoScroll = true;
            this.listeSeriePanel.HorizontalScrollbar = true;
            this.listeSeriePanel.HorizontalScrollbarBarColor = true;
            this.listeSeriePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.listeSeriePanel.HorizontalScrollbarSize = 12;
            this.listeSeriePanel.Location = new System.Drawing.Point(4, 7);
            this.listeSeriePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listeSeriePanel.Name = "listeSeriePanel";
            this.listeSeriePanel.Size = new System.Drawing.Size(728, 780);
            this.listeSeriePanel.TabIndex = 2;
            this.listeSeriePanel.VerticalScrollbar = true;
            this.listeSeriePanel.VerticalScrollbarBarColor = true;
            this.listeSeriePanel.VerticalScrollbarHighlightOnWheel = false;
            this.listeSeriePanel.VerticalScrollbarSize = 13;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tab_Serie);
            this.metroTabControl1.Controls.Add(this.tab_Planning);
            this.metroTabControl1.Controls.Add(tab_Donnee);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.metroTabControl1.Location = new System.Drawing.Point(27, 74);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(1543, 886);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tab_Planning
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.tab_Planning, true);
            this.tab_Planning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tab_Planning.Controls.Add(this.panel1);
            this.tab_Planning.Controls.Add(this.planingMetroGrid);
            this.tab_Planning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.tab_Planning.Location = new System.Drawing.Point(4, 38);
            this.tab_Planning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_Planning.Name = "tab_Planning";
            this.tab_Planning.Size = new System.Drawing.Size(1536, 844);
            this.tab_Planning.TabIndex = 4;
            this.tab_Planning.Text = "Planning";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.initGridButton);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 41);
            this.panel1.TabIndex = 1;
            // 
            // initGridButton
            // 
            this.initGridButton.Location = new System.Drawing.Point(5, 4);
            this.initGridButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.initGridButton.Name = "initGridButton";
            this.initGridButton.Size = new System.Drawing.Size(100, 28);
            this.initGridButton.TabIndex = 0;
            this.initGridButton.Text = "reinitialiser";
            this.initGridButton.UseSelectable = true;
            this.initGridButton.Click += new System.EventHandler(this.initGridButton_Click);
            // 
            // planingMetroGrid
            // 
            this.planingMetroGrid.AllowUserToResizeRows = false;
            this.planingMetroGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.planingMetroGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.planingMetroGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.planingMetroGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.planingMetroGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.planingMetroGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.planingMetroGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.planingMetroGrid.EnableHeadersVisualStyles = false;
            this.planingMetroGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.planingMetroGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.planingMetroGrid.Location = new System.Drawing.Point(4, 52);
            this.planingMetroGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.planingMetroGrid.Name = "planingMetroGrid";
            this.planingMetroGrid.ReadOnly = true;
            this.planingMetroGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.planingMetroGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.planingMetroGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.planingMetroGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planingMetroGrid.Size = new System.Drawing.Size(960, 690);
            this.planingMetroGrid.Style = MetroFramework.MetroColorStyle.Orange;
            this.planingMetroGrid.TabIndex = 0;
            this.planingMetroGrid.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.planingMetroGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.planingMetroGrid_CellContentDoubleClick);
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
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // htmlToolTip2
            // 
            this.htmlToolTip2.OwnerDraw = true;
            // 
            // utilisateurLogin
            // 
            this.utilisateurLogin.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.utilisateurLogin.Location = new System.Drawing.Point(1052, 37);
            this.utilisateurLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.utilisateurLogin.Name = "utilisateurLogin";
            this.utilisateurLogin.Size = new System.Drawing.Size(355, 28);
            this.utilisateurLogin.TabIndex = 7;
            this.utilisateurLogin.Text = "metroLabel26";
            this.utilisateurLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.utilisateurLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // utilisateurImageAvatar
            // 
            this.utilisateurImageAvatar.BackColor = System.Drawing.Color.Transparent;
            this.utilisateurImageAvatar.Location = new System.Drawing.Point(1415, 14);
            this.utilisateurImageAvatar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utilisateurImageAvatar.Name = "utilisateurImageAvatar";
            this.utilisateurImageAvatar.Size = new System.Drawing.Size(147, 86);
            this.utilisateurImageAvatar.TabIndex = 6;
            this.utilisateurImageAvatar.TabStop = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(1307, 14);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(80, 20);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Bienvenue,";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Form_Utilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1597, 985);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.utilisateurImageAvatar);
            this.Controls.Add(this.utilisateurLogin);
            this.Controls.Add(this.metroLabel4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Utilisateur";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Bienvenue";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            tab_Donnee.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utilisateurImagePictureBox)).EndInit();
            this.tab_Serie.ResumeLayout(false);
            this.tab_Serie.PerformLayout();
            this.fichePanel.ResumeLayout(false);
            this.ficheSeriePanel.ResumeLayout(false);
            this.ficheSeriePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSeriePictureBox)).EndInit();
            this.ficheEpisodePanel.ResumeLayout(false);
            this.ficheEpisodePanel.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.tab_Planning.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.planingMetroGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilisateurImageAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /*
        private void tab_ListeSerie_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
         */

        #endregion

        private MetroFramework.Controls.MetroTabPage tab_Serie;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private MetroFramework.Controls.MetroPanel listeSeriePanel;
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip2;
        private MetroFramework.Controls.MetroPanel fichePanel;
        private MetroFramework.Controls.MetroButton reInit;
        private MetroFramework.Controls.MetroPanel ficheEpisodePanel;
        private MetroFramework.Controls.MetroPanel ficheSeriePanel;
        private MetroFramework.Controls.MetroLabel nomEpisodeLabel;
        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label castingSerieLabel;
        private System.Windows.Forms.Label realisationSerieLabel;
        private System.Windows.Forms.Label genreSerieLabel;
        private System.Windows.Forms.Label productionSerieLabel;
        private System.Windows.Forms.PictureBox imageSeriePictureBox;
        private System.Windows.Forms.TextBox synopsieSerieTextBox;
        private MetroFramework.Controls.MetroComboBox noteComboBox;
        private MetroFramework.Controls.MetroButton suiviButton;
        private MetroFramework.Controls.MetroLabel metroLabelNote;
        private MetroFramework.Controls.MetroLabel dateEpisodeLabel;
        private MetroFramework.Controls.MetroLabel diffusionEpisodeLabel;
        private System.Windows.Forms.Label titreEpisodeLabel;
        private System.Windows.Forms.TextBox synopsisEpisodeTextBox;
        private MetroFramework.Controls.MetroComboBox genreCombo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ordreApparitionCombo;
        private System.Windows.Forms.TabPage tab_Planning;
        private MetroFramework.Controls.MetroGrid planingMetroGrid;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel utilisateurPrenomLabel;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox utilisateurAncienMDPTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label utilisateurMailLabel;
        private MetroFramework.Controls.MetroLabel utilisateurNouveauMDPTextBox;
        private System.Windows.Forms.TextBox utilisateurPrenomTextBox;
        private System.Windows.Forms.TextBox utilisateurNomTextBox;
        private MetroFramework.Controls.MetroLabel utilisateurMembreDepuisLabel;
        private MetroFramework.Controls.MetroButton utilisateurAppliquerModificationButton;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime utilisateurDateNaissanceDateTimePicker;
        private MetroFramework.Controls.MetroButton retourButton;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton initGridButton;
        private System.Windows.Forms.PictureBox utilisateurImagePictureBox;
        private System.Windows.Forms.PictureBox utilisateurImageAvatar;
        private MetroFramework.Controls.MetroLabel utilisateurLogin;
        private MetroFramework.Controls.MetroLabel metroLabel4;


    }
}

