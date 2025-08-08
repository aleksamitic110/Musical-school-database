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
            this.idFilijalaTextBox = new System.Windows.Forms.TextBox();
            this.JMBGNastavnikaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dodajKursButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // idFilijalaTextBox
            // 
            this.idFilijalaTextBox.Location = new System.Drawing.Point(397, 23);
            this.idFilijalaTextBox.Name = "idFilijalaTextBox";
            this.idFilijalaTextBox.Size = new System.Drawing.Size(139, 20);
            this.idFilijalaTextBox.TabIndex = 11;
            // 
            // JMBGNastavnikaTextBox
            // 
            this.JMBGNastavnikaTextBox.Location = new System.Drawing.Point(397, 49);
            this.JMBGNastavnikaTextBox.Name = "JMBGNastavnikaTextBox";
            this.JMBGNastavnikaTextBox.Size = new System.Drawing.Size(139, 20);
            this.JMBGNastavnikaTextBox.TabIndex = 12;
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
            // DodajKurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 350);
            this.Controls.Add(this.dodajKursButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.JMBGNastavnikaTextBox);
            this.Controls.Add(this.idFilijalaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nazivKursaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idKursaTextBox);
            this.Name = "DodajKurs";
            this.Text = "dodajKurs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox idFilijalaTextBox;
        private System.Windows.Forms.TextBox JMBGNastavnikaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dodajKursButton;
    }
}