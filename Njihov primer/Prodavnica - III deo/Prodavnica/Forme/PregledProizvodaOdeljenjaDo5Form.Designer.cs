namespace Prodavnica
{
    partial class PregledProizvodaOdeljenjaDo5Form
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
            this.proizvodi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnObrisiProizvod = new System.Windows.Forms.Button();
            this.btnIzmeniProizvod = new System.Windows.Forms.Button();
            this.btnDodajProizvod = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // proizvodi
            // 
            this.proizvodi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.proizvodi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proizvodi.FullRowSelect = true;
            this.proizvodi.GridLines = true;
            this.proizvodi.Location = new System.Drawing.Point(4, 19);
            this.proizvodi.Margin = new System.Windows.Forms.Padding(4);
            this.proizvodi.Name = "proizvodi";
            this.proizvodi.Size = new System.Drawing.Size(571, 331);
            this.proizvodi.TabIndex = 0;
            this.proizvodi.UseCompatibleStateImageBehavior = false;
            this.proizvodi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bar kod";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tip";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Naziv";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Proizvodjac";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Id prodaje";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 80;
            // 
            // btnObrisiProizvod
            // 
            this.btnObrisiProizvod.BackColor = System.Drawing.Color.SandyBrown;
            this.btnObrisiProizvod.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiProizvod.Location = new System.Drawing.Point(599, 171);
            this.btnObrisiProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisiProizvod.Name = "btnObrisiProizvod";
            this.btnObrisiProizvod.Size = new System.Drawing.Size(200, 62);
            this.btnObrisiProizvod.TabIndex = 39;
            this.btnObrisiProizvod.Text = "Obrisi igracku";
            this.btnObrisiProizvod.UseVisualStyleBackColor = false;
            this.btnObrisiProizvod.Click += new System.EventHandler(this.btnObrisiProizvod_Click);
            // 
            // btnIzmeniProizvod
            // 
            this.btnIzmeniProizvod.BackColor = System.Drawing.Color.SandyBrown;
            this.btnIzmeniProizvod.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniProizvod.Location = new System.Drawing.Point(599, 101);
            this.btnIzmeniProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeniProizvod.Name = "btnIzmeniProizvod";
            this.btnIzmeniProizvod.Size = new System.Drawing.Size(200, 62);
            this.btnIzmeniProizvod.TabIndex = 38;
            this.btnIzmeniProizvod.Text = "Izmeni igracku";
            this.btnIzmeniProizvod.UseVisualStyleBackColor = false;
            this.btnIzmeniProizvod.Click += new System.EventHandler(this.btnIzmeniProizvod_Click);
            // 
            // btnDodajProizvod
            // 
            this.btnDodajProizvod.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodajProizvod.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajProizvod.Location = new System.Drawing.Point(599, 32);
            this.btnDodajProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajProizvod.Name = "btnDodajProizvod";
            this.btnDodajProizvod.Size = new System.Drawing.Size(200, 62);
            this.btnDodajProizvod.TabIndex = 37;
            this.btnDodajProizvod.Text = "Dodaj igracku";
            this.btnDodajProizvod.UseVisualStyleBackColor = false;
            this.btnDodajProizvod.Click += new System.EventHandler(this.btnDodajProizvod_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.proizvodi);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(579, 354);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Igracke odeljenja do 5 god.";
            // 
            // PregledProizvodaOdeljenjaDo5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(811, 382);
            this.Controls.Add(this.btnObrisiProizvod);
            this.Controls.Add(this.btnIzmeniProizvod);
            this.Controls.Add(this.btnDodajProizvod);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(829, 429);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(829, 429);
            this.Name = "PregledProizvodaOdeljenjaDo5Form";
            this.Text = "PregledProizvodaOdeljenjaDo5Form";
            this.Load += new System.EventHandler(this.PregledProizvodaOdeljenjaDo5Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView proizvodi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnObrisiProizvod;
        private System.Windows.Forms.Button btnIzmeniProizvod;
        private System.Windows.Forms.Button btnDodajProizvod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}