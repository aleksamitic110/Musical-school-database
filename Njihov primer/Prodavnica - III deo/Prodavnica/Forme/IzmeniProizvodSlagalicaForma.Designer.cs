namespace Prodavnica
{
    partial class IzmeniProizvodSlagalicaForma
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
            this.brojDelova = new System.Windows.Forms.NumericUpDown();
            this.chbIlustracija = new System.Windows.Forms.CheckBox();
            this.chbUmetnicka = new System.Windows.Forms.CheckBox();
            this.txbProizvodjac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.chbTuristicka = new System.Windows.Forms.CheckBox();
            this.txbNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brojDelova)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brojDelova);
            this.groupBox1.Controls.Add(this.chbIlustracija);
            this.groupBox1.Controls.Add(this.chbUmetnicka);
            this.groupBox1.Controls.Add(this.txbProizvodjac);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnIzmeni);
            this.groupBox1.Controls.Add(this.chbTuristicka);
            this.groupBox1.Controls.Add(this.txbNaziv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(343, 403);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izmena podataka o slagalici";
            // 
            // brojDelova
            // 
            this.brojDelova.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brojDelova.Location = new System.Drawing.Point(132, 171);
            this.brojDelova.Margin = new System.Windows.Forms.Padding(4);
            this.brojDelova.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.brojDelova.Name = "brojDelova";
            this.brojDelova.Size = new System.Drawing.Size(200, 29);
            this.brojDelova.TabIndex = 2;
            this.brojDelova.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chbIlustracija
            // 
            this.chbIlustracija.AutoSize = true;
            this.chbIlustracija.Location = new System.Drawing.Point(190, 305);
            this.chbIlustracija.Margin = new System.Windows.Forms.Padding(4);
            this.chbIlustracija.Name = "chbIlustracija";
            this.chbIlustracija.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbIlustracija.Size = new System.Drawing.Size(108, 28);
            this.chbIlustracija.TabIndex = 5;
            this.chbIlustracija.Text = "Ilustracija";
            this.chbIlustracija.UseVisualStyleBackColor = true;
            // 
            // chbUmetnicka
            // 
            this.chbUmetnicka.AutoSize = true;
            this.chbUmetnicka.Location = new System.Drawing.Point(190, 259);
            this.chbUmetnicka.Margin = new System.Windows.Forms.Padding(4);
            this.chbUmetnicka.Name = "chbUmetnicka";
            this.chbUmetnicka.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbUmetnicka.Size = new System.Drawing.Size(120, 28);
            this.chbUmetnicka.TabIndex = 4;
            this.chbUmetnicka.Text = "Umetnicka";
            this.chbUmetnicka.UseVisualStyleBackColor = true;
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
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Broj delova:";
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
            // chbTuristicka
            // 
            this.chbTuristicka.AutoSize = true;
            this.chbTuristicka.Location = new System.Drawing.Point(190, 214);
            this.chbTuristicka.Margin = new System.Windows.Forms.Padding(4);
            this.chbTuristicka.Name = "chbTuristicka";
            this.chbTuristicka.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbTuristicka.Size = new System.Drawing.Size(111, 28);
            this.chbTuristicka.TabIndex = 3;
            this.chbTuristicka.Text = "Turisticka";
            this.chbTuristicka.UseVisualStyleBackColor = true;
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
            // IzmeniProizvodSlagalicaForma
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
            this.Name = "IzmeniProizvodSlagalicaForma";
            this.Text = "IzmeniProizvodSlagalicaForma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brojDelova)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown brojDelova;
        private System.Windows.Forms.CheckBox chbIlustracija;
        private System.Windows.Forms.CheckBox chbUmetnicka;
        private System.Windows.Forms.TextBox txbProizvodjac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.CheckBox chbTuristicka;
        private System.Windows.Forms.TextBox txbNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}