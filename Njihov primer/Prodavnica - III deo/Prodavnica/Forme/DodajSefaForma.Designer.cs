namespace Prodavnica
{
    partial class DodajSefaForma
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
            this.datumPostavljanja = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMbr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.datumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.txbSrednjeSlovo = new System.Windows.Forms.TextBox();
            this.txbStrucnaSprema = new System.Windows.Forms.TextBox();
            this.txbPrezime = new System.Windows.Forms.TextBox();
            this.txbIme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datumPostavljanja
            // 
            this.datumPostavljanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumPostavljanja.Location = new System.Drawing.Point(184, 315);
            this.datumPostavljanja.Margin = new System.Windows.Forms.Padding(4);
            this.datumPostavljanja.Name = "datumPostavljanja";
            this.datumPostavljanja.Size = new System.Drawing.Size(201, 26);
            this.datumPostavljanja.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 321);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Datum postavljanja:";
            // 
            // txbMbr
            // 
            this.txbMbr.Location = new System.Drawing.Point(184, 176);
            this.txbMbr.Margin = new System.Windows.Forms.Padding(4);
            this.txbMbr.MaxLength = 9;
            this.txbMbr.Name = "txbMbr";
            this.txbMbr.Size = new System.Drawing.Size(201, 26);
            this.txbMbr.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Jmbg:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodaj.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnDodaj.Location = new System.Drawing.Point(240, 377);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(145, 46);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "DODAJ";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // datumRodjenja
            // 
            this.datumRodjenja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumRodjenja.Location = new System.Drawing.Point(184, 217);
            this.datumRodjenja.Margin = new System.Windows.Forms.Padding(4);
            this.datumRodjenja.Name = "datumRodjenja";
            this.datumRodjenja.Size = new System.Drawing.Size(201, 26);
            this.datumRodjenja.TabIndex = 4;
            // 
            // txbSrednjeSlovo
            // 
            this.txbSrednjeSlovo.Location = new System.Drawing.Point(184, 135);
            this.txbSrednjeSlovo.Margin = new System.Windows.Forms.Padding(4);
            this.txbSrednjeSlovo.MaxLength = 1;
            this.txbSrednjeSlovo.Name = "txbSrednjeSlovo";
            this.txbSrednjeSlovo.Size = new System.Drawing.Size(201, 26);
            this.txbSrednjeSlovo.TabIndex = 2;
            // 
            // txbStrucnaSprema
            // 
            this.txbStrucnaSprema.Location = new System.Drawing.Point(184, 260);
            this.txbStrucnaSprema.Margin = new System.Windows.Forms.Padding(4);
            this.txbStrucnaSprema.Name = "txbStrucnaSprema";
            this.txbStrucnaSprema.Size = new System.Drawing.Size(201, 26);
            this.txbStrucnaSprema.TabIndex = 5;
            // 
            // txbPrezime
            // 
            this.txbPrezime.Location = new System.Drawing.Point(184, 89);
            this.txbPrezime.Margin = new System.Windows.Forms.Padding(4);
            this.txbPrezime.Name = "txbPrezime";
            this.txbPrezime.Size = new System.Drawing.Size(201, 26);
            this.txbPrezime.TabIndex = 1;
            // 
            // txbIme
            // 
            this.txbIme.Location = new System.Drawing.Point(184, 46);
            this.txbIme.Margin = new System.Windows.Forms.Padding(4);
            this.txbIme.Name = "txbIme";
            this.txbIme.Size = new System.Drawing.Size(201, 26);
            this.txbIme.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 267);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Strucna Sprema:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Datum Rodjenja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prezime:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datumPostavljanja);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txbMbr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.datumRodjenja);
            this.groupBox1.Controls.Add(this.txbSrednjeSlovo);
            this.groupBox1.Controls.Add(this.txbStrucnaSprema);
            this.groupBox1.Controls.Add(this.txbPrezime);
            this.groupBox1.Controls.Add(this.txbIme);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(413, 431);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o sefu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Srednje Slovo:";
            // 
            // DodajSefaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(443, 457);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(461, 504);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 504);
            this.Name = "DodajSefaForma";
            this.Text = "DodajSefa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker datumPostavljanja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbMbr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DateTimePicker datumRodjenja;
        private System.Windows.Forms.TextBox txbSrednjeSlovo;
        private System.Windows.Forms.TextBox txbStrucnaSprema;
        private System.Windows.Forms.TextBox txbPrezime;
        private System.Windows.Forms.TextBox txbIme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
    }
}