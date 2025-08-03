namespace Prodavnica
{
    partial class ProizvodiDodajForm
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
            this.btnNastavi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxTip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbProizvodjac = new System.Windows.Forms.TextBox();
            this.cbxOdeljenje = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbNaziv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listaProdavnica = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNastavi
            // 
            this.btnNastavi.BackColor = System.Drawing.Color.SandyBrown;
            this.btnNastavi.Font = new System.Drawing.Font("Georgia", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnNastavi.Location = new System.Drawing.Point(475, 338);
            this.btnNastavi.Margin = new System.Windows.Forms.Padding(4);
            this.btnNastavi.Name = "btnNastavi";
            this.btnNastavi.Size = new System.Drawing.Size(372, 102);
            this.btnNastavi.TabIndex = 1;
            this.btnNastavi.Text = "Nastavi sa dodavanjem proizvoda";
            this.btnNastavi.UseVisualStyleBackColor = false;
            this.btnNastavi.Click += new System.EventHandler(this.BtnNastavi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxTip);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbProizvodjac);
            this.groupBox1.Controls.Add(this.cbxOdeljenje);
            this.groupBox1.Controls.Add(this.btnSacuvaj);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbNaziv);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(475, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(372, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci o proizvodu";
            // 
            // cbxTip
            // 
            this.cbxTip.Enabled = false;
            this.cbxTip.FormattingEnabled = true;
            this.cbxTip.Items.AddRange(new object[] {
            "VOJNICI",
            "LUTKE",
            "DODACI ZA LUTKE",
            "PUZZLE",
            "AUTOMOBILI",
            "IGRACKE PLASTIKA",
            "OSTALO"});
            this.cbxTip.Location = new System.Drawing.Point(153, 36);
            this.cbxTip.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTip.Name = "cbxTip";
            this.cbxTip.Size = new System.Drawing.Size(189, 24);
            this.cbxTip.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Odeljenje:";
            // 
            // txbProizvodjac
            // 
            this.txbProizvodjac.Enabled = false;
            this.txbProizvodjac.Location = new System.Drawing.Point(153, 121);
            this.txbProizvodjac.Margin = new System.Windows.Forms.Padding(4);
            this.txbProizvodjac.Name = "txbProizvodjac";
            this.txbProizvodjac.Size = new System.Drawing.Size(189, 22);
            this.txbProizvodjac.TabIndex = 2;
            // 
            // cbxOdeljenje
            // 
            this.cbxOdeljenje.Enabled = false;
            this.cbxOdeljenje.FormattingEnabled = true;
            this.cbxOdeljenje.Items.AddRange(new object[] {
            "prvi",
            "drugi",
            "treći",
            "četvrti"});
            this.cbxOdeljenje.Location = new System.Drawing.Point(153, 160);
            this.cbxOdeljenje.Margin = new System.Windows.Forms.Padding(4);
            this.cbxOdeljenje.Name = "cbxOdeljenje";
            this.cbxOdeljenje.Size = new System.Drawing.Size(189, 24);
            this.cbxOdeljenje.TabIndex = 3;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSacuvaj.Enabled = false;
            this.btnSacuvaj.Font = new System.Drawing.Font("Georgia", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSacuvaj.Location = new System.Drawing.Point(153, 211);
            this.btnSacuvaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(191, 60);
            this.btnSacuvaj.TabIndex = 4;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naziv:";
            // 
            // txbNaziv
            // 
            this.txbNaziv.Enabled = false;
            this.txbNaziv.Location = new System.Drawing.Point(153, 76);
            this.txbNaziv.Margin = new System.Windows.Forms.Padding(4);
            this.txbNaziv.Name = "txbNaziv";
            this.txbNaziv.Size = new System.Drawing.Size(189, 22);
            this.txbNaziv.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proizvodjac:";
            // 
            // listaProdavnica
            // 
            this.listaProdavnica.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listaProdavnica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaProdavnica.FullRowSelect = true;
            this.listaProdavnica.GridLines = true;
            this.listaProdavnica.Location = new System.Drawing.Point(4, 19);
            this.listaProdavnica.Margin = new System.Windows.Forms.Padding(4);
            this.listaProdavnica.MultiSelect = false;
            this.listaProdavnica.Name = "listaProdavnica";
            this.listaProdavnica.Size = new System.Drawing.Size(446, 411);
            this.listaProdavnica.TabIndex = 0;
            this.listaProdavnica.UseCompatibleStateImageBehavior = false;
            this.listaProdavnica.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Id";
            this.columnHeader7.Width = 40;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Naziv";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 140;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Adresa";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listaProdavnica);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(454, 434);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spisak prodavnica";
            // 
            // ProizvodiDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(860, 460);
            this.Controls.Add(this.btnNastavi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ProizvodiDodajForm";
            this.Text = "ProizvodiDodajForm";
            this.Load += new System.EventHandler(this.ProizvodiDodajForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNastavi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxOdeljenje;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNaziv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listaProdavnica;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbProizvodjac;
        private System.Windows.Forms.ComboBox cbxTip;
    }
}