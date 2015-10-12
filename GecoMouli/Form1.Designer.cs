namespace GecoMouli
{
    partial class FormGecoMouli
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
            this.openFileDialogFicIn = new System.Windows.Forms.OpenFileDialog();
            this.enregistrementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonNiveau = new System.Windows.Forms.RadioButton();
            this.radioButtonPermutation = new System.Windows.Forms.RadioButton();
            this.radioButtonAlea = new System.Windows.Forms.RadioButton();
            this.radioButtonPoules = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMeilleursDerniers = new System.Windows.Forms.RadioButton();
            this.radioButtonStartAlea = new System.Windows.Forms.RadioButton();
            this.radioButtonMeilleursPremiers = new System.Windows.Forms.RadioButton();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonSupprNvlleCourse = new System.Windows.Forms.Button();
            this.buttonNouvelleCateg = new System.Windows.Forms.Button();
            this.textBoxNvlleCateg = new System.Windows.Forms.TextBox();
            this.comboBoxGroupeQualif = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPoules = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownQualifies = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewNouvelle = new System.Windows.Forms.ListView();
            this.chCategorie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQualifiables = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPoules = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQualifiesParPoules = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotalQualifies = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numericUpDownNbCircuits = new System.Windows.Forms.NumericUpDown();
            this.listViewPrec = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelResultats = new System.Windows.Forms.Label();
            this.labelFicOutNameNQ = new System.Windows.Forms.Label();
            this.labelFicOutNameQ = new System.Windows.Forms.Label();
            this.textBoxFicOut = new System.Windows.Forms.TextBox();
            this.labelFicOut = new System.Windows.Forms.Label();
            this.labelFicIn = new System.Windows.Forms.Label();
            this.buttonFicIn = new System.Windows.Forms.Button();
            this.textBoxFicIn = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSuffixe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrefixe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPenalitesManque = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPenalitePM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxConserverCateg = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxConserverCircuit = new System.Windows.Forms.CheckBox();
            this.textBoxSuffixeCircuit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPrefixeCircuit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxNouvCircuit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.enregistrementBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQualifies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbCircuits)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogFicIn
            // 
            this.openFileDialogFicIn.Filter = "Fichiers CSV|*.csv";
            this.openFileDialogFicIn.ReadOnlyChecked = true;
            this.openFileDialogFicIn.ShowReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 696);
            this.tabControl1.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxNouvCircuit);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.buttonRun);
            this.tabPage1.Controls.Add(this.buttonSupprNvlleCourse);
            this.tabPage1.Controls.Add(this.buttonNouvelleCateg);
            this.tabPage1.Controls.Add(this.textBoxNvlleCateg);
            this.tabPage1.Controls.Add(this.comboBoxGroupeQualif);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericUpDownPoules);
            this.tabPage1.Controls.Add(this.numericUpDownQualifies);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listViewNouvelle);
            this.tabPage1.Controls.Add(this.numericUpDownNbCircuits);
            this.tabPage1.Controls.Add(this.listViewPrec);
            this.tabPage1.Controls.Add(this.labelResultats);
            this.tabPage1.Controls.Add(this.labelFicOutNameNQ);
            this.tabPage1.Controls.Add(this.labelFicOutNameQ);
            this.tabPage1.Controls.Add(this.textBoxFicOut);
            this.tabPage1.Controls.Add(this.labelFicOut);
            this.tabPage1.Controls.Add(this.labelFicIn);
            this.tabPage1.Controls.Add(this.buttonFicIn);
            this.tabPage1.Controls.Add(this.textBoxFicIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(710, 670);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Génération";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonNiveau);
            this.groupBox2.Controls.Add(this.radioButtonPermutation);
            this.groupBox2.Controls.Add(this.radioButtonAlea);
            this.groupBox2.Controls.Add(this.radioButtonPoules);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(21, 566);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 41);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Répartition des concurrents";
            // 
            // radioButtonNiveau
            // 
            this.radioButtonNiveau.AutoSize = true;
            this.radioButtonNiveau.Location = new System.Drawing.Point(230, 19);
            this.radioButtonNiveau.Name = "radioButtonNiveau";
            this.radioButtonNiveau.Size = new System.Drawing.Size(76, 17);
            this.radioButtonNiveau.TabIndex = 34;
            this.radioButtonNiveau.Text = "Par niveau";
            this.radioButtonNiveau.UseVisualStyleBackColor = true;
            // 
            // radioButtonPermutation
            // 
            this.radioButtonPermutation.AutoSize = true;
            this.radioButtonPermutation.Checked = true;
            this.radioButtonPermutation.Location = new System.Drawing.Point(314, 19);
            this.radioButtonPermutation.Name = "radioButtonPermutation";
            this.radioButtonPermutation.Size = new System.Drawing.Size(126, 17);
            this.radioButtonPermutation.TabIndex = 33;
            this.radioButtonPermutation.TabStop = true;
            this.radioButtonPermutation.Text = "Permutation circulaire";
            this.radioButtonPermutation.UseVisualStyleBackColor = true;
            // 
            // radioButtonAlea
            // 
            this.radioButtonAlea.AutoSize = true;
            this.radioButtonAlea.Location = new System.Drawing.Point(158, 19);
            this.radioButtonAlea.Name = "radioButtonAlea";
            this.radioButtonAlea.Size = new System.Drawing.Size(66, 17);
            this.radioButtonAlea.TabIndex = 32;
            this.radioButtonAlea.Text = "Aléatoire";
            this.radioButtonAlea.UseVisualStyleBackColor = true;
            // 
            // radioButtonPoules
            // 
            this.radioButtonPoules.AutoSize = true;
            this.radioButtonPoules.Location = new System.Drawing.Point(32, 19);
            this.radioButtonPoules.Name = "radioButtonPoules";
            this.radioButtonPoules.Size = new System.Drawing.Size(120, 17);
            this.radioButtonPoules.TabIndex = 31;
            this.radioButtonPoules.Text = "Préserver les poules";
            this.radioButtonPoules.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMeilleursDerniers);
            this.groupBox1.Controls.Add(this.radioButtonStartAlea);
            this.groupBox1.Controls.Add(this.radioButtonMeilleursPremiers);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(19, 613);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 41);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Organisation de la start-list";
            // 
            // radioButtonMeilleursDerniers
            // 
            this.radioButtonMeilleursDerniers.AutoSize = true;
            this.radioButtonMeilleursDerniers.Location = new System.Drawing.Point(284, 19);
            this.radioButtonMeilleursDerniers.Name = "radioButtonMeilleursDerniers";
            this.radioButtonMeilleursDerniers.Size = new System.Drawing.Size(135, 17);
            this.radioButtonMeilleursDerniers.TabIndex = 3;
            this.radioButtonMeilleursDerniers.Text = "Les meilleurs en dernier";
            this.radioButtonMeilleursDerniers.UseVisualStyleBackColor = true;
            // 
            // radioButtonStartAlea
            // 
            this.radioButtonStartAlea.AutoSize = true;
            this.radioButtonStartAlea.Location = new System.Drawing.Point(187, 18);
            this.radioButtonStartAlea.Name = "radioButtonStartAlea";
            this.radioButtonStartAlea.Size = new System.Drawing.Size(66, 17);
            this.radioButtonStartAlea.TabIndex = 2;
            this.radioButtonStartAlea.Text = "Aléatoire";
            this.radioButtonStartAlea.UseVisualStyleBackColor = true;
            // 
            // radioButtonMeilleursPremiers
            // 
            this.radioButtonMeilleursPremiers.AutoSize = true;
            this.radioButtonMeilleursPremiers.Checked = true;
            this.radioButtonMeilleursPremiers.Location = new System.Drawing.Point(34, 18);
            this.radioButtonMeilleursPremiers.Name = "radioButtonMeilleursPremiers";
            this.radioButtonMeilleursPremiers.Size = new System.Drawing.Size(137, 17);
            this.radioButtonMeilleursPremiers.TabIndex = 1;
            this.radioButtonMeilleursPremiers.TabStop = true;
            this.radioButtonMeilleursPremiers.Text = "Les meilleurs en premier";
            this.radioButtonMeilleursPremiers.UseVisualStyleBackColor = true;
            // 
            // buttonRun
            // 
            this.buttonRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(575, 600);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(116, 30);
            this.buttonRun.TabIndex = 40;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonSupprNvlleCourse
            // 
            this.buttonSupprNvlleCourse.Enabled = false;
            this.buttonSupprNvlleCourse.Location = new System.Drawing.Point(575, 490);
            this.buttonSupprNvlleCourse.Name = "buttonSupprNvlleCourse";
            this.buttonSupprNvlleCourse.Size = new System.Drawing.Size(116, 21);
            this.buttonSupprNvlleCourse.TabIndex = 39;
            this.buttonSupprNvlleCourse.Text = "Suppr. la catég.";
            this.buttonSupprNvlleCourse.UseVisualStyleBackColor = true;
            this.buttonSupprNvlleCourse.Click += new System.EventHandler(this.buttonSupprNvlleCourse_Click);
            // 
            // buttonNouvelleCateg
            // 
            this.buttonNouvelleCateg.Location = new System.Drawing.Point(575, 460);
            this.buttonNouvelleCateg.Name = "buttonNouvelleCateg";
            this.buttonNouvelleCateg.Size = new System.Drawing.Size(116, 24);
            this.buttonNouvelleCateg.TabIndex = 38;
            this.buttonNouvelleCateg.Text = "Nouvelle catég.";
            this.buttonNouvelleCateg.UseVisualStyleBackColor = true;
            this.buttonNouvelleCateg.Click += new System.EventHandler(this.buttonNouvelleCateg_Click);
            // 
            // textBoxNvlleCateg
            // 
            this.textBoxNvlleCateg.Enabled = false;
            this.textBoxNvlleCateg.Location = new System.Drawing.Point(53, 529);
            this.textBoxNvlleCateg.Name = "textBoxNvlleCateg";
            this.textBoxNvlleCateg.Size = new System.Drawing.Size(60, 20);
            this.textBoxNvlleCateg.TabIndex = 37;
            this.textBoxNvlleCateg.TextChanged += new System.EventHandler(this.textBoxNvlleCateg_TextChanged);
            // 
            // comboBoxGroupeQualif
            // 
            this.comboBoxGroupeQualif.Enabled = false;
            this.comboBoxGroupeQualif.FormattingEnabled = true;
            this.comboBoxGroupeQualif.Location = new System.Drawing.Point(330, 398);
            this.comboBoxGroupeQualif.Name = "comboBoxGroupeQualif";
            this.comboBoxGroupeQualif.Size = new System.Drawing.Size(110, 21);
            this.comboBoxGroupeQualif.TabIndex = 36;
            this.comboBoxGroupeQualif.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupeQualif_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Course précédente";
            // 
            // numericUpDownPoules
            // 
            this.numericUpDownPoules.Enabled = false;
            this.numericUpDownPoules.Location = new System.Drawing.Point(183, 530);
            this.numericUpDownPoules.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPoules.Name = "numericUpDownPoules";
            this.numericUpDownPoules.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownPoules.TabIndex = 34;
            this.numericUpDownPoules.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPoules.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownPoules.ValueChanged += new System.EventHandler(this.numericUpDownPoules_ValueChanged);
            // 
            // numericUpDownQualifies
            // 
            this.numericUpDownQualifies.Enabled = false;
            this.numericUpDownQualifies.Location = new System.Drawing.Point(255, 530);
            this.numericUpDownQualifies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQualifies.Name = "numericUpDownQualifies";
            this.numericUpDownQualifies.Size = new System.Drawing.Size(91, 20);
            this.numericUpDownQualifies.TabIndex = 33;
            this.numericUpDownQualifies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownQualifies.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownQualifies.ValueChanged += new System.EventHandler(this.numericUpDownQualifies_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Nouvelle course";
            // 
            // listViewNouvelle
            // 
            this.listViewNouvelle.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewNouvelle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCategorie,
            this.chQualifiables,
            this.chPoules,
            this.chQualifiesParPoules,
            this.chTotalQualifies,
            this.columnHeader4});
            this.listViewNouvelle.FullRowSelect = true;
            this.listViewNouvelle.GridLines = true;
            this.listViewNouvelle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewNouvelle.HideSelection = false;
            this.listViewNouvelle.Location = new System.Drawing.Point(53, 435);
            this.listViewNouvelle.MultiSelect = false;
            this.listViewNouvelle.Name = "listViewNouvelle";
            this.listViewNouvelle.Size = new System.Drawing.Size(500, 89);
            this.listViewNouvelle.TabIndex = 31;
            this.listViewNouvelle.UseCompatibleStateImageBehavior = false;
            this.listViewNouvelle.View = System.Windows.Forms.View.Details;
            this.listViewNouvelle.SelectedIndexChanged += new System.EventHandler(this.listViewNouvelle_SelectedIndexChanged);
            // 
            // chCategorie
            // 
            this.chCategorie.Text = "Catégorie";
            // 
            // chQualifiables
            // 
            this.chQualifiables.Text = "Qualifiables";
            this.chQualifiables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chQualifiables.Width = 67;
            // 
            // chPoules
            // 
            this.chPoules.Text = "Nb poules";
            this.chPoules.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chPoules.Width = 65;
            // 
            // chQualifiesParPoules
            // 
            this.chQualifiesParPoules.Text = "Qualifiés par poule";
            this.chQualifiesParPoules.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chQualifiesParPoules.Width = 99;
            // 
            // chTotalQualifies
            // 
            this.chTotalQualifies.Text = "Nb total qualifiés";
            this.chTotalQualifies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chTotalQualifies.Width = 94;
            // 
            // numericUpDownNbCircuits
            // 
            this.numericUpDownNbCircuits.Enabled = false;
            this.numericUpDownNbCircuits.Location = new System.Drawing.Point(212, 398);
            this.numericUpDownNbCircuits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNbCircuits.Name = "numericUpDownNbCircuits";
            this.numericUpDownNbCircuits.Size = new System.Drawing.Size(111, 20);
            this.numericUpDownNbCircuits.TabIndex = 30;
            this.numericUpDownNbCircuits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNbCircuits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNbCircuits.ValueChanged += new System.EventHandler(this.numericUpDownNbCircuits_ValueChanged);
            // 
            // listViewPrec
            // 
            this.listViewPrec.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewPrec.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3});
            this.listViewPrec.FullRowSelect = true;
            this.listViewPrec.GridLines = true;
            this.listViewPrec.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPrec.HideSelection = false;
            this.listViewPrec.Location = new System.Drawing.Point(53, 133);
            this.listViewPrec.MultiSelect = false;
            this.listViewPrec.Name = "listViewPrec";
            this.listViewPrec.Size = new System.Drawing.Size(500, 259);
            this.listViewPrec.TabIndex = 29;
            this.listViewPrec.UseCompatibleStateImageBehavior = false;
            this.listViewPrec.View = System.Windows.Forms.View.Details;
            this.listViewPrec.SelectedIndexChanged += new System.EventHandler(this.listViewPrec_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Poules";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nb concurrents";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nb de circuits de qualif";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nouvelle catégorie";
            this.columnHeader3.Width = 110;
            // 
            // labelResultats
            // 
            this.labelResultats.AutoSize = true;
            this.labelResultats.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelResultats.Location = new System.Drawing.Point(159, 100);
            this.labelResultats.Name = "labelResultats";
            this.labelResultats.Size = new System.Drawing.Size(111, 13);
            this.labelResultats.TabIndex = 24;
            this.labelResultats.Text = "StarList Resultats.html";
            // 
            // labelFicOutNameNQ
            // 
            this.labelFicOutNameNQ.AutoSize = true;
            this.labelFicOutNameNQ.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelFicOutNameNQ.Location = new System.Drawing.Point(159, 87);
            this.labelFicOutNameNQ.Name = "labelFicOutNameNQ";
            this.labelFicOutNameNQ.Size = new System.Drawing.Size(81, 13);
            this.labelFicOutNameNQ.TabIndex = 23;
            this.labelFicOutNameNQ.Text = "StarList NQ.csv";
            // 
            // labelFicOutNameQ
            // 
            this.labelFicOutNameQ.AutoSize = true;
            this.labelFicOutNameQ.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelFicOutNameQ.Location = new System.Drawing.Point(159, 74);
            this.labelFicOutNameQ.Name = "labelFicOutNameQ";
            this.labelFicOutNameQ.Size = new System.Drawing.Size(108, 13);
            this.labelFicOutNameQ.TabIndex = 22;
            this.labelFicOutNameQ.Text = "StartList Qualifies.csv";
            // 
            // textBoxFicOut
            // 
            this.textBoxFicOut.Location = new System.Drawing.Point(162, 47);
            this.textBoxFicOut.Name = "textBoxFicOut";
            this.textBoxFicOut.Size = new System.Drawing.Size(486, 20);
            this.textBoxFicOut.TabIndex = 21;
            this.textBoxFicOut.Text = "StartList";
            this.textBoxFicOut.TextChanged += new System.EventHandler(this.textBoxFicOut_TextChanged);
            // 
            // labelFicOut
            // 
            this.labelFicOut.AutoSize = true;
            this.labelFicOut.Location = new System.Drawing.Point(16, 50);
            this.labelFicOut.Name = "labelFicOut";
            this.labelFicOut.Size = new System.Drawing.Size(133, 13);
            this.labelFicOut.TabIndex = 20;
            this.labelFicOut.Text = "Nom des fichiers à générer";
            // 
            // labelFicIn
            // 
            this.labelFicIn.AutoSize = true;
            this.labelFicIn.Location = new System.Drawing.Point(16, 17);
            this.labelFicIn.Name = "labelFicIn";
            this.labelFicIn.Size = new System.Drawing.Size(140, 13);
            this.labelFicIn.TabIndex = 19;
            this.labelFicIn.Text = "Fichier courses précédentes";
            // 
            // buttonFicIn
            // 
            this.buttonFicIn.Location = new System.Drawing.Point(654, 11);
            this.buttonFicIn.Name = "buttonFicIn";
            this.buttonFicIn.Size = new System.Drawing.Size(37, 23);
            this.buttonFicIn.TabIndex = 18;
            this.buttonFicIn.Text = "...";
            this.buttonFicIn.UseVisualStyleBackColor = true;
            this.buttonFicIn.Click += new System.EventHandler(this.buttonFicIn_Click);
            // 
            // textBoxFicIn
            // 
            this.textBoxFicIn.Location = new System.Drawing.Point(162, 14);
            this.textBoxFicIn.Name = "textBoxFicIn";
            this.textBoxFicIn.ReadOnly = true;
            this.textBoxFicIn.Size = new System.Drawing.Size(486, 20);
            this.textBoxFicIn.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.checkBoxConserverCircuit);
            this.tabPage2.Controls.Add(this.textBoxSuffixeCircuit);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.textBoxPrefixeCircuit);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.checkBoxConserverCateg);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBoxSuffixe);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxPrefixe);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxPenalitesManque);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBoxPenalitePM);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(710, 670);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paramètres";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "s";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "s";
            // 
            // textBoxSuffixe
            // 
            this.textBoxSuffixe.Location = new System.Drawing.Point(220, 206);
            this.textBoxSuffixe.Name = "textBoxSuffixe";
            this.textBoxSuffixe.Size = new System.Drawing.Size(100, 20);
            this.textBoxSuffixe.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Suffixe nouvelle catégorie";
            // 
            // textBoxPrefixe
            // 
            this.textBoxPrefixe.Location = new System.Drawing.Point(220, 156);
            this.textBoxPrefixe.Name = "textBoxPrefixe";
            this.textBoxPrefixe.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrefixe.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Préfixe nouvelle catégorie";
            // 
            // textBoxPenalitesManque
            // 
            this.textBoxPenalitesManque.Location = new System.Drawing.Point(220, 88);
            this.textBoxPenalitesManque.Name = "textBoxPenalitesManque";
            this.textBoxPenalitesManque.Size = new System.Drawing.Size(100, 20);
            this.textBoxPenalitesManque.TabIndex = 41;
            this.textBoxPenalitesManque.Text = "3600";
            this.textBoxPenalitesManque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Pénalité course manquante";
            // 
            // textBoxPenalitePM
            // 
            this.textBoxPenalitePM.Location = new System.Drawing.Point(220, 62);
            this.textBoxPenalitePM.Name = "textBoxPenalitePM";
            this.textBoxPenalitePM.Size = new System.Drawing.Size(100, 20);
            this.textBoxPenalitePM.TabIndex = 39;
            this.textBoxPenalitePM.Text = "3600";
            this.textBoxPenalitePM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Pénalité PM, abandons,...";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Circuit";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 88;
            // 
            // checkBoxConserverCateg
            // 
            this.checkBoxConserverCateg.AutoSize = true;
            this.checkBoxConserverCateg.Checked = true;
            this.checkBoxConserverCateg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConserverCateg.Location = new System.Drawing.Point(220, 183);
            this.checkBoxConserverCateg.Name = "checkBoxConserverCateg";
            this.checkBoxConserverCateg.Size = new System.Drawing.Size(15, 14);
            this.checkBoxConserverCateg.TabIndex = 48;
            this.checkBoxConserverCateg.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Conserver le nom de la catégorie";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Utiliser le nom de la catégorie";
            // 
            // checkBoxConserverCircuit
            // 
            this.checkBoxConserverCircuit.AutoSize = true;
            this.checkBoxConserverCircuit.Location = new System.Drawing.Point(220, 291);
            this.checkBoxConserverCircuit.Name = "checkBoxConserverCircuit";
            this.checkBoxConserverCircuit.Size = new System.Drawing.Size(15, 14);
            this.checkBoxConserverCircuit.TabIndex = 54;
            this.checkBoxConserverCircuit.UseVisualStyleBackColor = true;
            // 
            // textBoxSuffixeCircuit
            // 
            this.textBoxSuffixeCircuit.Location = new System.Drawing.Point(220, 314);
            this.textBoxSuffixeCircuit.Name = "textBoxSuffixeCircuit";
            this.textBoxSuffixeCircuit.Size = new System.Drawing.Size(100, 20);
            this.textBoxSuffixeCircuit.TabIndex = 53;
            this.textBoxSuffixeCircuit.Text = "Quart";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 317);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Suffixe nouveau circuit";
            // 
            // textBoxPrefixeCircuit
            // 
            this.textBoxPrefixeCircuit.Location = new System.Drawing.Point(220, 264);
            this.textBoxPrefixeCircuit.Name = "textBoxPrefixeCircuit";
            this.textBoxPrefixeCircuit.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrefixeCircuit.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Préfixe nouveau circuit";
            // 
            // textBoxNouvCircuit
            // 
            this.textBoxNouvCircuit.Enabled = false;
            this.textBoxNouvCircuit.Location = new System.Drawing.Point(441, 529);
            this.textBoxNouvCircuit.Name = "textBoxNouvCircuit";
            this.textBoxNouvCircuit.Size = new System.Drawing.Size(88, 20);
            this.textBoxNouvCircuit.TabIndex = 43;
            this.textBoxNouvCircuit.TextChanged += new System.EventHandler(this.textBoxNouveauCircuit_TextChanged);
            // 
            // FormGecoMouli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(720, 701);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGecoMouli";
            this.Text = "GecoMouli";
            this.Load += new System.EventHandler(this.FormGecoMouli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enregistrementBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQualifies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbCircuits)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogFicIn;
        private System.Windows.Forms.BindingSource enregistrementBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonNiveau;
        private System.Windows.Forms.RadioButton radioButtonPermutation;
        private System.Windows.Forms.RadioButton radioButtonAlea;
        private System.Windows.Forms.RadioButton radioButtonPoules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonMeilleursDerniers;
        private System.Windows.Forms.RadioButton radioButtonStartAlea;
        private System.Windows.Forms.RadioButton radioButtonMeilleursPremiers;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonSupprNvlleCourse;
        private System.Windows.Forms.Button buttonNouvelleCateg;
        private System.Windows.Forms.TextBox textBoxNvlleCateg;
        private System.Windows.Forms.ComboBox comboBoxGroupeQualif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPoules;
        private System.Windows.Forms.NumericUpDown numericUpDownQualifies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewNouvelle;
        private System.Windows.Forms.ColumnHeader chCategorie;
        private System.Windows.Forms.ColumnHeader chQualifiables;
        private System.Windows.Forms.ColumnHeader chPoules;
        private System.Windows.Forms.ColumnHeader chQualifiesParPoules;
        private System.Windows.Forms.ColumnHeader chTotalQualifies;
        private System.Windows.Forms.NumericUpDown numericUpDownNbCircuits;
        private System.Windows.Forms.ListView listViewPrec;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelResultats;
        private System.Windows.Forms.Label labelFicOutNameNQ;
        private System.Windows.Forms.Label labelFicOutNameQ;
        private System.Windows.Forms.TextBox textBoxFicOut;
        private System.Windows.Forms.Label labelFicOut;
        private System.Windows.Forms.Label labelFicIn;
        private System.Windows.Forms.Button buttonFicIn;
        private System.Windows.Forms.TextBox textBoxFicIn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxPenalitesManque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPenalitePM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSuffixe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrefixe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxConserverCateg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxConserverCircuit;
        private System.Windows.Forms.TextBox textBoxSuffixeCircuit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPrefixeCircuit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxNouvCircuit;
    }
}

