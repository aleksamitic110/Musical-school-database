namespace Prodavnica
{
    partial class ProdavniceForm
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
            this.listaProdavnica = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnObrisiProdavnicu = new System.Windows.Forms.Button();
            this.btnIzmeniProdavnicu = new System.Windows.Forms.Button();
            this.btnDodajProdavnicu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSefovi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaProdavnica);
            this.groupBox1.Location = new System.Drawing.Point(16, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(771, 644);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista prodavnica";
            // 
            // listaProdavnica
            // 
            this.listaProdavnica.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader6});
            this.listaProdavnica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaProdavnica.FullRowSelect = true;
            this.listaProdavnica.GridLines = true;
            this.listaProdavnica.Location = new System.Drawing.Point(4, 19);
            this.listaProdavnica.Margin = new System.Windows.Forms.Padding(4);
            this.listaProdavnica.Name = "listaProdavnica";
            this.listaProdavnica.Size = new System.Drawing.Size(763, 621);
            this.listaProdavnica.TabIndex = 4;
            this.listaProdavnica.UseCompatibleStateImageBehavior = false;
            this.listaProdavnica.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naziv";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Adresa";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Broj telefona";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Radni dan";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Subota";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nedelja";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnObrisiProdavnicu
            // 
            this.btnObrisiProdavnicu.BackColor = System.Drawing.Color.SandyBrown;
            this.btnObrisiProdavnicu.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnObrisiProdavnicu.Location = new System.Drawing.Point(29, 97);
            this.btnObrisiProdavnicu.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisiProdavnicu.Name = "btnObrisiProdavnicu";
            this.btnObrisiProdavnicu.Size = new System.Drawing.Size(200, 52);
            this.btnObrisiProdavnicu.TabIndex = 33;
            this.btnObrisiProdavnicu.Text = "Obrisi prodavnicu";
            this.btnObrisiProdavnicu.UseVisualStyleBackColor = false;
            this.btnObrisiProdavnicu.Click += new System.EventHandler(this.btnObrisiProdavnicu_Click);
            // 
            // btnIzmeniProdavnicu
            // 
            this.btnIzmeniProdavnicu.BackColor = System.Drawing.Color.SandyBrown;
            this.btnIzmeniProdavnicu.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnIzmeniProdavnicu.Location = new System.Drawing.Point(29, 156);
            this.btnIzmeniProdavnicu.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeniProdavnicu.Name = "btnIzmeniProdavnicu";
            this.btnIzmeniProdavnicu.Size = new System.Drawing.Size(200, 52);
            this.btnIzmeniProdavnicu.TabIndex = 32;
            this.btnIzmeniProdavnicu.Text = "Izmeni prodavnicu";
            this.btnIzmeniProdavnicu.UseVisualStyleBackColor = false;
            this.btnIzmeniProdavnicu.Click += new System.EventHandler(this.btnIzmeniProdavnicu_Click);
            // 
            // btnDodajProdavnicu
            // 
            this.btnDodajProdavnicu.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodajProdavnicu.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajProdavnicu.Location = new System.Drawing.Point(29, 40);
            this.btnDodajProdavnicu.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajProdavnicu.Name = "btnDodajProdavnicu";
            this.btnDodajProdavnicu.Size = new System.Drawing.Size(200, 49);
            this.btnDodajProdavnicu.TabIndex = 31;
            this.btnDodajProdavnicu.Text = "Dodaj prodavnicu";
            this.btnDodajProdavnicu.UseVisualStyleBackColor = false;
            this.btnDodajProdavnicu.Click += new System.EventHandler(this.btnDodajProdavnicu_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SandyBrown;
            this.button1.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(29, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 49);
            this.button1.TabIndex = 34;
            this.button1.Text = "Odeljenja do 5 god.";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SandyBrown;
            this.button2.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(29, 93);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 49);
            this.button2.TabIndex = 35;
            this.button2.Text = "Odeljenje od 6 do 15 god.";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SandyBrown;
            this.button3.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(29, 150);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 49);
            this.button3.TabIndex = 36;
            this.button3.Text = "Odeljenje za odrasle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDodajProdavnicu);
            this.groupBox2.Controls.Add(this.btnIzmeniProdavnicu);
            this.groupBox2.Controls.Add(this.btnObrisiProdavnicu);
            this.groupBox2.Location = new System.Drawing.Point(795, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(267, 226);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o prodavnici";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(795, 255);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(267, 213);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Odeljenja";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnZaposleni);
            this.groupBox4.Location = new System.Drawing.Point(795, 475);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(267, 91);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zaposleni";
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.BackColor = System.Drawing.Color.SandyBrown;
            this.btnZaposleni.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaposleni.Location = new System.Drawing.Point(29, 23);
            this.btnZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Size = new System.Drawing.Size(200, 49);
            this.btnZaposleni.TabIndex = 37;
            this.btnZaposleni.Text = "Zaposleni";
            this.btnZaposleni.UseVisualStyleBackColor = false;
            this.btnZaposleni.Click += new System.EventHandler(this.btnZaposleni_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSefovi);
            this.groupBox5.Location = new System.Drawing.Point(795, 574);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(267, 91);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sefovi";
            // 
            // btnSefovi
            // 
            this.btnSefovi.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSefovi.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSefovi.Location = new System.Drawing.Point(29, 23);
            this.btnSefovi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSefovi.Name = "btnSefovi";
            this.btnSefovi.Size = new System.Drawing.Size(200, 49);
            this.btnSefovi.TabIndex = 37;
            this.btnSefovi.Text = "Sefovi";
            this.btnSefovi.UseVisualStyleBackColor = false;
            this.btnSefovi.Click += new System.EventHandler(this.btnSefovi_Click);
            // 
            // ProdavniceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(1072, 683);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1090, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1090, 730);
            this.Name = "ProdavniceForm";
            this.Text = "LISTA PRODAVNICA";
            this.Load += new System.EventHandler(this.ProdavniceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listaProdavnica;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnObrisiProdavnicu;
        private System.Windows.Forms.Button btnIzmeniProdavnicu;
        private System.Windows.Forms.Button btnDodajProdavnicu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSefovi;
    }
}