namespace Prodavnica
{
    partial class DodajProizvodIgrackePlastikaForma
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
            this.chbLomljiva = new System.Windows.Forms.CheckBox();
            this.uzrast = new System.Windows.Forms.NumericUpDown();
            this.txbProizvodjac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.chbVodootporna = new System.Windows.Forms.CheckBox();
            this.txbNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uzrast)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbLomljiva);
            this.groupBox1.Controls.Add(this.uzrast);
            this.groupBox1.Controls.Add(this.txbProizvodjac);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.chbVodootporna);
            this.groupBox1.Controls.Add(this.txbNaziv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(343, 348);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci o plasticnoj igracki";
            // 
            // chbLomljiva
            // 
            this.chbLomljiva.AutoSize = true;
            this.chbLomljiva.Location = new System.Drawing.Point(190, 259);
            this.chbLomljiva.Margin = new System.Windows.Forms.Padding(4);
            this.chbLomljiva.Name = "chbLomljiva";
            this.chbLomljiva.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbLomljiva.Size = new System.Drawing.Size(100, 28);
            this.chbLomljiva.TabIndex = 4;
            this.chbLomljiva.Text = "Lomljiva";
            this.chbLomljiva.UseVisualStyleBackColor = true;
            // 
            // uzrast
            // 
            this.uzrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uzrast.Location = new System.Drawing.Point(132, 168);
            this.uzrast.Margin = new System.Windows.Forms.Padding(4);
            this.uzrast.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uzrast.Name = "uzrast";
            this.uzrast.Size = new System.Drawing.Size(200, 29);
            this.uzrast.TabIndex = 2;
            this.uzrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Uzrast:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodaj.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnDodaj.Location = new System.Drawing.Point(162, 295);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(170, 45);
            this.btnDodaj.TabIndex = 5;
            this.btnDodaj.Text = "DODAJ";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // chbVodootporna
            // 
            this.chbVodootporna.AutoSize = true;
            this.chbVodootporna.Location = new System.Drawing.Point(190, 214);
            this.chbVodootporna.Margin = new System.Windows.Forms.Padding(4);
            this.chbVodootporna.Name = "chbVodootporna";
            this.chbVodootporna.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbVodootporna.Size = new System.Drawing.Size(142, 28);
            this.chbVodootporna.TabIndex = 3;
            this.chbVodootporna.Text = "Vodootporna";
            this.chbVodootporna.UseVisualStyleBackColor = true;
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
            // DodajProizvodIgrackePlastikaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(365, 374);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(383, 421);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(383, 421);
            this.Name = "DodajProizvodIgrackePlastikaForma";
            this.Text = "DODAVANJE PLASTICNIH IGRACAKA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uzrast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbProizvodjac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.CheckBox chbVodootporna;
        private System.Windows.Forms.TextBox txbNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown uzrast;
        private System.Windows.Forms.CheckBox chbLomljiva;
    }
}