namespace Prodavnica
{
    partial class IzmeniProizvodVojnikForma
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbPlastika = new System.Windows.Forms.CheckBox();
            this.txbNazivSerije = new System.Windows.Forms.TextBox();
            this.chbMetal = new System.Windows.Forms.CheckBox();
            this.txbProizvodjac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.chbBaterije = new System.Windows.Forms.CheckBox();
            this.txbNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbPlastika);
            this.groupBox1.Controls.Add(this.txbNazivSerije);
            this.groupBox1.Controls.Add(this.chbMetal);
            this.groupBox1.Controls.Add(this.txbProizvodjac);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnIzmeni);
            this.groupBox1.Controls.Add(this.chbBaterije);
            this.groupBox1.Controls.Add(this.txbNaziv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(343, 403);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izmena podataka o vojniku";
            // 
            // chbPlastika
            // 
            this.chbPlastika.AutoSize = true;
            this.chbPlastika.Location = new System.Drawing.Point(190, 305);
            this.chbPlastika.Margin = new System.Windows.Forms.Padding(4);
            this.chbPlastika.Name = "chbPlastika";
            this.chbPlastika.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbPlastika.Size = new System.Drawing.Size(94, 28);
            this.chbPlastika.TabIndex = 5;
            this.chbPlastika.Text = "Plastika";
            this.chbPlastika.UseVisualStyleBackColor = true;
            // 
            // txbNazivSerije
            // 
            this.txbNazivSerije.Location = new System.Drawing.Point(133, 170);
            this.txbNazivSerije.Margin = new System.Windows.Forms.Padding(4);
            this.txbNazivSerije.Name = "txbNazivSerije";
            this.txbNazivSerije.Size = new System.Drawing.Size(199, 29);
            this.txbNazivSerije.TabIndex = 2;
            // 
            // chbMetal
            // 
            this.chbMetal.AutoSize = true;
            this.chbMetal.Location = new System.Drawing.Point(190, 259);
            this.chbMetal.Margin = new System.Windows.Forms.Padding(4);
            this.chbMetal.Name = "chbMetal";
            this.chbMetal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbMetal.Size = new System.Drawing.Size(77, 28);
            this.chbMetal.TabIndex = 4;
            this.chbMetal.Text = "Metal";
            this.chbMetal.UseVisualStyleBackColor = true;
            // 
            // txbProizvodjac
            // 
            this.txbProizvodjac.Location = new System.Drawing.Point(133, 106);
            this.txbProizvodjac.Margin = new System.Windows.Forms.Padding(4);
            this.txbProizvodjac.Name = "txbProizvodjac";
            this.txbProizvodjac.Size = new System.Drawing.Size(199, 29);
            this.txbProizvodjac.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Naziv serije:";
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.SandyBrown;
            this.btnIzmeni.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnIzmeni.Location = new System.Drawing.Point(162, 350);
            this.btnIzmeni.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(170, 45);
            this.btnIzmeni.TabIndex = 6;
            this.btnIzmeni.Text = "IZMENI";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // chbBaterije
            // 
            this.chbBaterije.AutoSize = true;
            this.chbBaterije.Location = new System.Drawing.Point(190, 214);
            this.chbBaterije.Margin = new System.Windows.Forms.Padding(4);
            this.chbBaterije.Name = "chbBaterije";
            this.chbBaterije.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbBaterije.Size = new System.Drawing.Size(94, 28);
            this.chbBaterije.TabIndex = 3;
            this.chbBaterije.Text = "Baterije";
            this.chbBaterije.UseVisualStyleBackColor = true;
            // 
            // txbNaziv
            // 
            this.txbNaziv.Location = new System.Drawing.Point(133, 46);
            this.txbNaziv.Margin = new System.Windows.Forms.Padding(4);
            this.txbNaziv.Name = "txbNaziv";
            this.txbNaziv.Size = new System.Drawing.Size(199, 29);
            this.txbNaziv.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proizvodjac:";
            // 
            // IzmeniProizvodVojnikForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(372, 423);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 470);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 470);
            this.Name = "IzmeniProizvodVojnikForma";
            this.Text = "IzmeniProizvodVojnikForma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbPlastika;
        private System.Windows.Forms.TextBox txbNazivSerije;
        private System.Windows.Forms.CheckBox chbMetal;
        private System.Windows.Forms.TextBox txbProizvodjac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.CheckBox chbBaterije;
        private System.Windows.Forms.TextBox txbNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}