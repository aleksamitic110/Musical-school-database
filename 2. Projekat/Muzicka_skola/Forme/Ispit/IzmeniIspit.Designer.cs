namespace Muzicka_skola.Forme.Ispit
{
    partial class IzmeniIspit
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
            this.buttonIzmeniIspit = new System.Windows.Forms.Button();
            this.comboBoxNastavnici = new System.Windows.Forms.ComboBox();
            this.buttonDodajNastavnika = new System.Windows.Forms.Button();
            this.buttonObrisiNastavnikaIzListbox = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxDodatiNastavnici = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonIzmeniIspit
            // 
            this.buttonIzmeniIspit.Location = new System.Drawing.Point(28, 287);
            this.buttonIzmeniIspit.Name = "buttonIzmeniIspit";
            this.buttonIzmeniIspit.Size = new System.Drawing.Size(269, 54);
            this.buttonIzmeniIspit.TabIndex = 45;
            this.buttonIzmeniIspit.Text = "Izmeni Ispit";
            this.buttonIzmeniIspit.UseVisualStyleBackColor = true;
            this.buttonIzmeniIspit.Click += new System.EventHandler(this.buttonIzmeniIspit_Click);
            // 
            // comboBoxNastavnici
            // 
            this.comboBoxNastavnici.FormattingEnabled = true;
            this.comboBoxNastavnici.Location = new System.Drawing.Point(111, 79);
            this.comboBoxNastavnici.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNastavnici.Name = "comboBoxNastavnici";
            this.comboBoxNastavnici.Size = new System.Drawing.Size(184, 24);
            this.comboBoxNastavnici.TabIndex = 44;
            // 
            // buttonDodajNastavnika
            // 
            this.buttonDodajNastavnika.Location = new System.Drawing.Point(111, 110);
            this.buttonDodajNastavnika.Name = "buttonDodajNastavnika";
            this.buttonDodajNastavnika.Size = new System.Drawing.Size(184, 23);
            this.buttonDodajNastavnika.TabIndex = 43;
            this.buttonDodajNastavnika.Text = "dodaj";
            this.buttonDodajNastavnika.UseVisualStyleBackColor = true;
            this.buttonDodajNastavnika.Click += new System.EventHandler(this.buttonDodajNastavnika_Click);
            // 
            // buttonObrisiNastavnikaIzListbox
            // 
            this.buttonObrisiNastavnikaIzListbox.Location = new System.Drawing.Point(28, 195);
            this.buttonObrisiNastavnikaIzListbox.Name = "buttonObrisiNastavnikaIzListbox";
            this.buttonObrisiNastavnikaIzListbox.Size = new System.Drawing.Size(69, 23);
            this.buttonObrisiNastavnikaIzListbox.TabIndex = 42;
            this.buttonObrisiNastavnikaIzListbox.Text = "obrisi";
            this.buttonObrisiNastavnikaIzListbox.UseVisualStyleBackColor = true;
            this.buttonObrisiNastavnikaIzListbox.Click += new System.EventHandler(this.buttonObrisiNastavnikaIzListbox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 32);
            this.label7.TabIndex = 41;
            this.label7.Text = "Dodati\r\nNastavnici:";
            // 
            // listBoxDodatiNastavnici
            // 
            this.listBoxDodatiNastavnici.FormattingEnabled = true;
            this.listBoxDodatiNastavnici.ItemHeight = 16;
            this.listBoxDodatiNastavnici.Location = new System.Drawing.Point(111, 149);
            this.listBoxDodatiNastavnici.Name = "listBoxDodatiNastavnici";
            this.listBoxDodatiNastavnici.Size = new System.Drawing.Size(186, 116);
            this.listBoxDodatiNastavnici.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 32);
            this.label6.TabIndex = 39;
            this.label6.Text = "Nastavnik \r\nu komisiji:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 34);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 22);
            this.dateTimePicker1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Datum:";
            // 
            // IzmeniIspit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 368);
            this.Controls.Add(this.buttonIzmeniIspit);
            this.Controls.Add(this.comboBoxNastavnici);
            this.Controls.Add(this.buttonDodajNastavnika);
            this.Controls.Add(this.buttonObrisiNastavnikaIzListbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxDodatiNastavnici);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Name = "IzmeniIspit";
            this.Text = "IzmeniIspit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIzmeniIspit;
        private System.Windows.Forms.ComboBox comboBoxNastavnici;
        private System.Windows.Forms.Button buttonDodajNastavnika;
        private System.Windows.Forms.Button buttonObrisiNastavnikaIzListbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxDodatiNastavnici;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
    }
}