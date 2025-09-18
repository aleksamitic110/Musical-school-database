namespace Muzicka_skola.Forme.Ispit
{
    partial class DodajIspit
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.comboBoxKursevi = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonDodajNastavnika = new System.Windows.Forms.Button();
            this.buttonObrisiNastavnikaIzListbox = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxDodatiNastavnici = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxNastavnici = new System.Windows.Forms.ComboBox();
            this.buttonDodajIspit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kurs:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(116, 29);
            this.textBoxID.MaxLength = 13;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(186, 22);
            this.textBoxID.TabIndex = 10;
            // 
            // comboBoxKursevi
            // 
            this.comboBoxKursevi.FormattingEnabled = true;
            this.comboBoxKursevi.Location = new System.Drawing.Point(116, 73);
            this.comboBoxKursevi.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxKursevi.Name = "comboBoxKursevi";
            this.comboBoxKursevi.Size = new System.Drawing.Size(184, 24);
            this.comboBoxKursevi.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(116, 121);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 22);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // buttonDodajNastavnika
            // 
            this.buttonDodajNastavnika.Location = new System.Drawing.Point(116, 197);
            this.buttonDodajNastavnika.Name = "buttonDodajNastavnika";
            this.buttonDodajNastavnika.Size = new System.Drawing.Size(184, 23);
            this.buttonDodajNastavnika.TabIndex = 30;
            this.buttonDodajNastavnika.Text = "dodaj";
            this.buttonDodajNastavnika.UseVisualStyleBackColor = true;
            this.buttonDodajNastavnika.Click += new System.EventHandler(this.buttonDodajNastavnika_Click);
            // 
            // buttonObrisiNastavnikaIzListbox
            // 
            this.buttonObrisiNastavnikaIzListbox.Location = new System.Drawing.Point(33, 282);
            this.buttonObrisiNastavnikaIzListbox.Name = "buttonObrisiNastavnikaIzListbox";
            this.buttonObrisiNastavnikaIzListbox.Size = new System.Drawing.Size(69, 23);
            this.buttonObrisiNastavnikaIzListbox.TabIndex = 29;
            this.buttonObrisiNastavnikaIzListbox.Text = "obrisi";
            this.buttonObrisiNastavnikaIzListbox.UseVisualStyleBackColor = true;
            this.buttonObrisiNastavnikaIzListbox.Click += new System.EventHandler(this.buttonObrisiNastavnikaIzListbox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 32);
            this.label7.TabIndex = 28;
            this.label7.Text = "Dodati\r\nNastavnici:";
            // 
            // listBoxDodatiNastavnici
            // 
            this.listBoxDodatiNastavnici.FormattingEnabled = true;
            this.listBoxDodatiNastavnici.ItemHeight = 16;
            this.listBoxDodatiNastavnici.Location = new System.Drawing.Point(116, 236);
            this.listBoxDodatiNastavnici.Name = "listBoxDodatiNastavnici";
            this.listBoxDodatiNastavnici.Size = new System.Drawing.Size(186, 116);
            this.listBoxDodatiNastavnici.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 32);
            this.label6.TabIndex = 26;
            this.label6.Text = "Nastavnik \r\nu komisiji:";
            // 
            // comboBoxNastavnici
            // 
            this.comboBoxNastavnici.FormattingEnabled = true;
            this.comboBoxNastavnici.Location = new System.Drawing.Point(116, 166);
            this.comboBoxNastavnici.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNastavnici.Name = "comboBoxNastavnici";
            this.comboBoxNastavnici.Size = new System.Drawing.Size(184, 24);
            this.comboBoxNastavnici.TabIndex = 31;
            // 
            // buttonDodajIspit
            // 
            this.buttonDodajIspit.Location = new System.Drawing.Point(33, 374);
            this.buttonDodajIspit.Name = "buttonDodajIspit";
            this.buttonDodajIspit.Size = new System.Drawing.Size(269, 54);
            this.buttonDodajIspit.TabIndex = 32;
            this.buttonDodajIspit.Text = "Dodaj Ispit";
            this.buttonDodajIspit.UseVisualStyleBackColor = true;
            this.buttonDodajIspit.Click += new System.EventHandler(this.buttonDodajIspit_Click);
            // 
            // DodajIspit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 450);
            this.Controls.Add(this.buttonDodajIspit);
            this.Controls.Add(this.comboBoxNastavnici);
            this.Controls.Add(this.buttonDodajNastavnika);
            this.Controls.Add(this.buttonObrisiNastavnikaIzListbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxDodatiNastavnici);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxKursevi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
            this.Name = "DodajIspit";
            this.Text = "DodajIspit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.ComboBox comboBoxKursevi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonDodajNastavnika;
        private System.Windows.Forms.Button buttonObrisiNastavnikaIzListbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxDodatiNastavnici;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxNastavnici;
        private System.Windows.Forms.Button buttonDodajIspit;
    }
}