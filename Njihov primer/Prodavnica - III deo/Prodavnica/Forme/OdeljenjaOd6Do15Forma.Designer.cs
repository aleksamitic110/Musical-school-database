namespace Prodavnica.Forme
{
    partial class OdeljenjaOd6Do15Forma
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
            this.btnObrisiOdeljenje = new System.Windows.Forms.Button();
            this.btnIzmeniOdeljenje = new System.Windows.Forms.Button();
            this.btnDodajOdeljenje = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.odeljenja = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPregledIgracaka = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnObrisiOdeljenje
            // 
            this.btnObrisiOdeljenje.BackColor = System.Drawing.Color.SandyBrown;
            this.btnObrisiOdeljenje.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiOdeljenje.Location = new System.Drawing.Point(549, 172);
            this.btnObrisiOdeljenje.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisiOdeljenje.Name = "btnObrisiOdeljenje";
            this.btnObrisiOdeljenje.Size = new System.Drawing.Size(200, 62);
            this.btnObrisiOdeljenje.TabIndex = 38;
            this.btnObrisiOdeljenje.Text = "Obrisi Odeljenje";
            this.btnObrisiOdeljenje.UseVisualStyleBackColor = false;
            this.btnObrisiOdeljenje.Click += new System.EventHandler(this.btnObrisiOdeljenje_Click_1);
            // 
            // btnIzmeniOdeljenje
            // 
            this.btnIzmeniOdeljenje.BackColor = System.Drawing.Color.SandyBrown;
            this.btnIzmeniOdeljenje.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniOdeljenje.Location = new System.Drawing.Point(549, 103);
            this.btnIzmeniOdeljenje.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeniOdeljenje.Name = "btnIzmeniOdeljenje";
            this.btnIzmeniOdeljenje.Size = new System.Drawing.Size(200, 62);
            this.btnIzmeniOdeljenje.TabIndex = 37;
            this.btnIzmeniOdeljenje.Text = "Izmeni Odeljenje";
            this.btnIzmeniOdeljenje.UseVisualStyleBackColor = false;
            this.btnIzmeniOdeljenje.Click += new System.EventHandler(this.btnIzmeniOdeljenje_Click_1);
            // 
            // btnDodajOdeljenje
            // 
            this.btnDodajOdeljenje.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodajOdeljenje.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajOdeljenje.Location = new System.Drawing.Point(549, 34);
            this.btnDodajOdeljenje.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajOdeljenje.Name = "btnDodajOdeljenje";
            this.btnDodajOdeljenje.Size = new System.Drawing.Size(200, 62);
            this.btnDodajOdeljenje.TabIndex = 36;
            this.btnDodajOdeljenje.Text = "Dodaj Odeljenje";
            this.btnDodajOdeljenje.UseVisualStyleBackColor = false;
            this.btnDodajOdeljenje.Click += new System.EventHandler(this.btnDodajOdeljenje_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.odeljenja);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(505, 355);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odeljenja od 6 do 15 god.";
            // 
            // odeljenja
            // 
            this.odeljenja.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.odeljenja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.odeljenja.FullRowSelect = true;
            this.odeljenja.GridLines = true;
            this.odeljenja.Location = new System.Drawing.Point(4, 19);
            this.odeljenja.Margin = new System.Windows.Forms.Padding(4);
            this.odeljenja.Name = "odeljenja";
            this.odeljenja.Size = new System.Drawing.Size(497, 332);
            this.odeljenja.TabIndex = 0;
            this.odeljenja.UseCompatibleStateImageBehavior = false;
            this.odeljenja.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lokacija";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Broj Kasa";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Info Pult";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // btnPregledIgracaka
            // 
            this.btnPregledIgracaka.BackColor = System.Drawing.Color.SandyBrown;
            this.btnPregledIgracaka.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPregledIgracaka.Location = new System.Drawing.Point(549, 304);
            this.btnPregledIgracaka.Margin = new System.Windows.Forms.Padding(4);
            this.btnPregledIgracaka.Name = "btnPregledIgracaka";
            this.btnPregledIgracaka.Size = new System.Drawing.Size(200, 62);
            this.btnPregledIgracaka.TabIndex = 39;
            this.btnPregledIgracaka.Text = "Pregled igracaka";
            this.btnPregledIgracaka.UseVisualStyleBackColor = false;
            this.btnPregledIgracaka.Click += new System.EventHandler(this.btnPregledIgracaka_Click);
            // 
            // OdeljenjaOd6Do15Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(767, 383);
            this.Controls.Add(this.btnPregledIgracaka);
            this.Controls.Add(this.btnObrisiOdeljenje);
            this.Controls.Add(this.btnIzmeniOdeljenje);
            this.Controls.Add(this.btnDodajOdeljenje);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(785, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(785, 430);
            this.Name = "OdeljenjaOd6Do15Forma";
            this.Text = "PRODAVNICA";
            this.Load += new System.EventHandler(this.OdeljenjaOd6Do15Forma_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnObrisiOdeljenje;
        private System.Windows.Forms.Button btnIzmeniOdeljenje;
        private System.Windows.Forms.Button btnDodajOdeljenje;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView odeljenja;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnPregledIgracaka;
    }
}