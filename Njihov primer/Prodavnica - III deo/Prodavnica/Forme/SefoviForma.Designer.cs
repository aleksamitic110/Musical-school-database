namespace Prodavnica
{
    partial class SefoviForma
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
            this.sefovi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnObrisiSefa = new System.Windows.Forms.Button();
            this.btnIzmeniSefa = new System.Windows.Forms.Button();
            this.btnDodajSefa = new System.Windows.Forms.Button();
            this.btnDodajPostojeceg = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sefovi);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(635, 347);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sefovi";
            // 
            // sefovi
            // 
            this.sefovi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.sefovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sefovi.FullRowSelect = true;
            this.sefovi.GridLines = true;
            this.sefovi.Location = new System.Drawing.Point(4, 19);
            this.sefovi.Margin = new System.Windows.Forms.Padding(4);
            this.sefovi.Name = "sefovi";
            this.sefovi.Size = new System.Drawing.Size(627, 324);
            this.sefovi.TabIndex = 0;
            this.sefovi.UseCompatibleStateImageBehavior = false;
            this.sefovi.View = System.Windows.Forms.View.Details;
            this.sefovi.SelectedIndexChanged += new System.EventHandler(this.sefovi_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Jbr";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mbr";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ime";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Srednje Slovo";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Prezime";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Datum Rodjenja";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Strucna Sprema";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Sef";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 40;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Id Radnog Odnosa";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 90;
            // 
            // btnObrisiSefa
            // 
            this.btnObrisiSefa.BackColor = System.Drawing.Color.SandyBrown;
            this.btnObrisiSefa.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiSefa.Location = new System.Drawing.Point(675, 146);
            this.btnObrisiSefa.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisiSefa.Name = "btnObrisiSefa";
            this.btnObrisiSefa.Size = new System.Drawing.Size(200, 49);
            this.btnObrisiSefa.TabIndex = 40;
            this.btnObrisiSefa.Text = "Obrisi sefa";
            this.btnObrisiSefa.UseVisualStyleBackColor = false;
            this.btnObrisiSefa.Click += new System.EventHandler(this.btnObrisiSefa_Click);
            // 
            // btnIzmeniSefa
            // 
            this.btnIzmeniSefa.BackColor = System.Drawing.Color.SandyBrown;
            this.btnIzmeniSefa.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniSefa.Location = new System.Drawing.Point(675, 89);
            this.btnIzmeniSefa.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeniSefa.Name = "btnIzmeniSefa";
            this.btnIzmeniSefa.Size = new System.Drawing.Size(200, 49);
            this.btnIzmeniSefa.TabIndex = 39;
            this.btnIzmeniSefa.Text = "Izmeni sefa";
            this.btnIzmeniSefa.UseVisualStyleBackColor = false;
            this.btnIzmeniSefa.Click += new System.EventHandler(this.btnIzmeniSefa_Click);
            // 
            // btnDodajSefa
            // 
            this.btnDodajSefa.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodajSefa.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajSefa.Location = new System.Drawing.Point(675, 32);
            this.btnDodajSefa.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajSefa.Name = "btnDodajSefa";
            this.btnDodajSefa.Size = new System.Drawing.Size(200, 49);
            this.btnDodajSefa.TabIndex = 38;
            this.btnDodajSefa.Text = "Dodaj sefa";
            this.btnDodajSefa.UseVisualStyleBackColor = false;
            this.btnDodajSefa.Click += new System.EventHandler(this.btnDodajSefa_Click);
            // 
            // btnDodajPostojeceg
            // 
            this.btnDodajPostojeceg.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodajPostojeceg.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajPostojeceg.Location = new System.Drawing.Point(675, 203);
            this.btnDodajPostojeceg.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajPostojeceg.Name = "btnDodajPostojeceg";
            this.btnDodajPostojeceg.Size = new System.Drawing.Size(200, 49);
            this.btnDodajPostojeceg.TabIndex = 41;
            this.btnDodajPostojeceg.Text = "Dodaj postojeceg sefa";
            this.btnDodajPostojeceg.UseVisualStyleBackColor = false;
            this.btnDodajPostojeceg.Click += new System.EventHandler(this.btnDodajPostojeceg_Click_1);
            // 
            // SefoviForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(907, 367);
            this.Controls.Add(this.btnDodajPostojeceg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnObrisiSefa);
            this.Controls.Add(this.btnIzmeniSefa);
            this.Controls.Add(this.btnDodajSefa);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(925, 414);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(925, 414);
            this.Name = "SefoviForma";
            this.Text = "SefoviForma";
            this.Load += new System.EventHandler(this.SefoviForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView sefovi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnObrisiSefa;
        private System.Windows.Forms.Button btnIzmeniSefa;
        private System.Windows.Forms.Button btnDodajSefa;
        private System.Windows.Forms.Button btnDodajPostojeceg;
    }
}