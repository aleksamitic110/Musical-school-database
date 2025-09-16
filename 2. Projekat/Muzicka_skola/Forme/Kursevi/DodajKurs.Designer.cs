namespace Muzicka_skola.Forme.Kursevi
{
    partial class DodajKurs
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
            this.idKursaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nazivKursaTextBox = new System.Windows.Forms.TextBox();
            this.napredni = new System.Windows.Forms.RadioButton();
            this.srednji = new System.Windows.Forms.RadioButton();
            this.pocetni = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grupna = new System.Windows.Forms.RadioButton();
            this.individualna = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dodajKursButton = new System.Windows.Forms.Button();
            this.jmbgNastavnikaComboBox = new System.Windows.Forms.ComboBox();
            this.idFilijalaComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.instrumentalni = new System.Windows.Forms.RadioButton();
            this.teorijski = new System.Windows.Forms.RadioButton();
            this.vokalni = new System.Windows.Forms.RadioButton();
            this.panelVokalni = new System.Windows.Forms.Panel();
            this.Individualno = new System.Windows.Forms.RadioButton();
            this.horsko = new System.Windows.Forms.RadioButton();
            this.panelInstrumentalni = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInstrument = new System.Windows.Forms.TextBox();
            this.panelTeorijski = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNazivPredmeta = new System.Windows.Forms.TextBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelVokalni.SuspendLayout();
            this.panelInstrumentalni.SuspendLayout();
            this.panelTeorijski.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // idKursaTextBox
            // 
            this.idKursaTextBox.Location = new System.Drawing.Point(84, 23);
            this.idKursaTextBox.Name = "idKursaTextBox";
            this.idKursaTextBox.Size = new System.Drawing.Size(139, 20);
            this.idKursaTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Kursa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Naziv:";
            // 
            // nazivKursaTextBox
            // 
            this.nazivKursaTextBox.Location = new System.Drawing.Point(84, 49);
            this.nazivKursaTextBox.Name = "nazivKursaTextBox";
            this.nazivKursaTextBox.Size = new System.Drawing.Size(139, 20);
            this.nazivKursaTextBox.TabIndex = 3;
            // 
            // napredni
            // 
            this.napredni.AutoSize = true;
            this.napredni.Location = new System.Drawing.Point(54, 19);
            this.napredni.Name = "napredni";
            this.napredni.Size = new System.Drawing.Size(68, 17);
            this.napredni.TabIndex = 5;
            this.napredni.TabStop = true;
            this.napredni.Text = "Napredni";
            this.napredni.UseVisualStyleBackColor = true;
            // 
            // srednji
            // 
            this.srednji.AutoSize = true;
            this.srednji.Location = new System.Drawing.Point(54, 42);
            this.srednji.Name = "srednji";
            this.srednji.Size = new System.Drawing.Size(57, 17);
            this.srednji.TabIndex = 6;
            this.srednji.TabStop = true;
            this.srednji.Text = "Srednji";
            this.srednji.UseVisualStyleBackColor = true;
            // 
            // pocetni
            // 
            this.pocetni.AutoSize = true;
            this.pocetni.Location = new System.Drawing.Point(54, 65);
            this.pocetni.Name = "pocetni";
            this.pocetni.Size = new System.Drawing.Size(61, 17);
            this.pocetni.TabIndex = 7;
            this.pocetni.TabStop = true;
            this.pocetni.Text = "Pocetni";
            this.pocetni.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.pocetni);
            this.groupBox1.Controls.Add(this.srednji);
            this.groupBox1.Controls.Add(this.napredni);
            this.groupBox1.Location = new System.Drawing.Point(30, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 98);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nivo: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grupna);
            this.groupBox2.Controls.Add(this.individualna);
            this.groupBox2.Location = new System.Drawing.Point(30, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 73);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tip Nastave:";
            // 
            // grupna
            // 
            this.grupna.AutoSize = true;
            this.grupna.Location = new System.Drawing.Point(54, 42);
            this.grupna.Name = "grupna";
            this.grupna.Size = new System.Drawing.Size(103, 17);
            this.grupna.TabIndex = 1;
            this.grupna.TabStop = true;
            this.grupna.Text = "Grupna Nastava";
            this.grupna.UseVisualStyleBackColor = true;
            // 
            // individualna
            // 
            this.individualna.AutoSize = true;
            this.individualna.Location = new System.Drawing.Point(54, 19);
            this.individualna.Name = "individualna";
            this.individualna.Size = new System.Drawing.Size(125, 17);
            this.individualna.TabIndex = 0;
            this.individualna.TabStop = true;
            this.individualna.Text = "Individualna Nastava";
            this.individualna.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ID Filijale:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "JMBG Nastavnika:";
            // 
            // dodajKursButton
            // 
            this.dodajKursButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dodajKursButton.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajKursButton.Location = new System.Drawing.Point(30, 282);
            this.dodajKursButton.Name = "dodajKursButton";
            this.dodajKursButton.Size = new System.Drawing.Size(506, 46);
            this.dodajKursButton.TabIndex = 14;
            this.dodajKursButton.Text = "DODAJ NOVI KURS";
            this.dodajKursButton.UseVisualStyleBackColor = false;
            this.dodajKursButton.Click += new System.EventHandler(this.dodajKursButton_Click);
            // 
            // jmbgNastavnikaComboBox
            // 
            this.jmbgNastavnikaComboBox.FormattingEnabled = true;
            this.jmbgNastavnikaComboBox.Location = new System.Drawing.Point(397, 49);
            this.jmbgNastavnikaComboBox.Name = "jmbgNastavnikaComboBox";
            this.jmbgNastavnikaComboBox.Size = new System.Drawing.Size(139, 21);
            this.jmbgNastavnikaComboBox.TabIndex = 15;
            // 
            // idFilijalaComboBox
            // 
            this.idFilijalaComboBox.FormattingEnabled = true;
            this.idFilijalaComboBox.Location = new System.Drawing.Point(397, 23);
            this.idFilijalaComboBox.Name = "idFilijalaComboBox";
            this.idFilijalaComboBox.Size = new System.Drawing.Size(139, 21);
            this.idFilijalaComboBox.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.vokalni);
            this.groupBox3.Controls.Add(this.teorijski);
            this.groupBox3.Controls.Add(this.instrumentalni);
            this.groupBox3.Location = new System.Drawing.Point(301, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 97);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pod Tip Kursa";
            // 
            // instrumentalni
            // 
            this.instrumentalni.AutoSize = true;
            this.instrumentalni.Location = new System.Drawing.Point(69, 19);
            this.instrumentalni.Name = "instrumentalni";
            this.instrumentalni.Size = new System.Drawing.Size(90, 17);
            this.instrumentalni.TabIndex = 0;
            this.instrumentalni.TabStop = true;
            this.instrumentalni.Text = "Instrumentalni";
            this.instrumentalni.UseVisualStyleBackColor = true;
            this.instrumentalni.CheckedChanged += new System.EventHandler(this.instrumentalni_CheckedChanged);
            // 
            // teorijski
            // 
            this.teorijski.AutoSize = true;
            this.teorijski.Location = new System.Drawing.Point(69, 42);
            this.teorijski.Name = "teorijski";
            this.teorijski.Size = new System.Drawing.Size(64, 17);
            this.teorijski.TabIndex = 1;
            this.teorijski.TabStop = true;
            this.teorijski.Text = "Teorijski";
            this.teorijski.UseVisualStyleBackColor = true;
            this.teorijski.CheckedChanged += new System.EventHandler(this.teorijski_CheckedChanged);
            // 
            // vokalni
            // 
            this.vokalni.AutoSize = true;
            this.vokalni.Location = new System.Drawing.Point(69, 65);
            this.vokalni.Name = "vokalni";
            this.vokalni.Size = new System.Drawing.Size(60, 17);
            this.vokalni.TabIndex = 2;
            this.vokalni.TabStop = true;
            this.vokalni.Text = "Vokalni";
            this.vokalni.UseVisualStyleBackColor = true;
            this.vokalni.CheckedChanged += new System.EventHandler(this.vokalni_CheckedChanged);
            // 
            // panelVokalni
            // 
            this.panelVokalni.Controls.Add(this.horsko);
            this.panelVokalni.Controls.Add(this.Individualno);
            this.panelVokalni.Location = new System.Drawing.Point(0, 0);
            this.panelVokalni.Name = "panelVokalni";
            this.panelVokalni.Size = new System.Drawing.Size(235, 73);
            this.panelVokalni.TabIndex = 18;
            this.panelVokalni.Visible = false;
            // 
            // Individualno
            // 
            this.Individualno.AutoSize = true;
            this.Individualno.Location = new System.Drawing.Point(69, 19);
            this.Individualno.Name = "Individualno";
            this.Individualno.Size = new System.Drawing.Size(82, 17);
            this.Individualno.TabIndex = 0;
            this.Individualno.TabStop = true;
            this.Individualno.Text = "Individualno";
            this.Individualno.UseVisualStyleBackColor = true;
            // 
            // horsko
            // 
            this.horsko.AutoSize = true;
            this.horsko.Location = new System.Drawing.Point(69, 42);
            this.horsko.Name = "horsko";
            this.horsko.Size = new System.Drawing.Size(59, 17);
            this.horsko.TabIndex = 1;
            this.horsko.TabStop = true;
            this.horsko.Text = "Horsko";
            this.horsko.UseVisualStyleBackColor = true;
            // 
            // panelInstrumentalni
            // 
            this.panelInstrumentalni.Controls.Add(this.textBoxInstrument);
            this.panelInstrumentalni.Controls.Add(this.label5);
            this.panelInstrumentalni.Location = new System.Drawing.Point(301, 179);
            this.panelInstrumentalni.Name = "panelInstrumentalni";
            this.panelInstrumentalni.Size = new System.Drawing.Size(235, 73);
            this.panelInstrumentalni.TabIndex = 19;
            this.panelInstrumentalni.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Instrument:";
            // 
            // textBoxInstrument
            // 
            this.textBoxInstrument.Location = new System.Drawing.Point(87, 29);
            this.textBoxInstrument.Name = "textBoxInstrument";
            this.textBoxInstrument.Size = new System.Drawing.Size(136, 20);
            this.textBoxInstrument.TabIndex = 1;
            // 
            // panelTeorijski
            // 
            this.panelTeorijski.Controls.Add(this.textBoxNazivPredmeta);
            this.panelTeorijski.Controls.Add(this.label6);
            this.panelTeorijski.Location = new System.Drawing.Point(301, 179);
            this.panelTeorijski.Name = "panelTeorijski";
            this.panelTeorijski.Size = new System.Drawing.Size(235, 73);
            this.panelTeorijski.TabIndex = 19;
            this.panelTeorijski.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Naziv Predmeta:";
            // 
            // textBoxNazivPredmeta
            // 
            this.textBoxNazivPredmeta.Location = new System.Drawing.Point(69, 32);
            this.textBoxNazivPredmeta.Name = "textBoxNazivPredmeta";
            this.textBoxNazivPredmeta.Size = new System.Drawing.Size(154, 20);
            this.textBoxNazivPredmeta.TabIndex = 1;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelVokalni);
            this.panelContainer.Location = new System.Drawing.Point(301, 179);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(235, 73);
            this.panelContainer.TabIndex = 20;
            // 
            // DodajKurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 342);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInstrumentalni);
            this.Controls.Add(this.panelTeorijski);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.idFilijalaComboBox);
            this.Controls.Add(this.jmbgNastavnikaComboBox);
            this.Controls.Add(this.dodajKursButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nazivKursaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idKursaTextBox);
            this.Name = "DodajKurs";
            this.Text = "dodajKurs";
            this.Load += new System.EventHandler(this.DodajKurs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelVokalni.ResumeLayout(false);
            this.panelVokalni.PerformLayout();
            this.panelInstrumentalni.ResumeLayout(false);
            this.panelInstrumentalni.PerformLayout();
            this.panelTeorijski.ResumeLayout(false);
            this.panelTeorijski.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idKursaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazivKursaTextBox;
        private System.Windows.Forms.RadioButton napredni;
        private System.Windows.Forms.RadioButton srednji;
        private System.Windows.Forms.RadioButton pocetni;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton grupna;
        private System.Windows.Forms.RadioButton individualna;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dodajKursButton;
        private System.Windows.Forms.ComboBox jmbgNastavnikaComboBox;
        private System.Windows.Forms.ComboBox idFilijalaComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton vokalni;
        private System.Windows.Forms.RadioButton teorijski;
        private System.Windows.Forms.RadioButton instrumentalni;
        private System.Windows.Forms.Panel panelVokalni;
        private System.Windows.Forms.RadioButton horsko;
        private System.Windows.Forms.RadioButton Individualno;
        private System.Windows.Forms.Panel panelInstrumentalni;
        private System.Windows.Forms.TextBox textBoxInstrument;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelTeorijski;
        private System.Windows.Forms.TextBox textBoxNazivPredmeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelContainer;
    }
}