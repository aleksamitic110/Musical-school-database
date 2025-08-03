namespace Prodavnica
{
    partial class ProizvodiForm
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
            this.btnObrisiProizvod = new System.Windows.Forms.Button();
            this.btnIzmeniProizvod = new System.Windows.Forms.Button();
            this.btnDodajProizvod = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaProizvoda = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txbBrojProizvoda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnObrisiProizvod
            // 
            this.btnObrisiProizvod.BackColor = System.Drawing.Color.SandyBrown;
            this.btnObrisiProizvod.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnObrisiProizvod.Location = new System.Drawing.Point(12, 282);
            this.btnObrisiProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisiProizvod.Name = "btnObrisiProizvod";
            this.btnObrisiProizvod.Size = new System.Drawing.Size(160, 62);
            this.btnObrisiProizvod.TabIndex = 49;
            this.btnObrisiProizvod.Text = "Obrisi proizvod";
            this.btnObrisiProizvod.UseVisualStyleBackColor = false;
            this.btnObrisiProizvod.Click += new System.EventHandler(this.btnObrisiProizvod_Click);
            // 
            // btnIzmeniProizvod
            // 
            this.btnIzmeniProizvod.BackColor = System.Drawing.Color.SandyBrown;
            this.btnIzmeniProizvod.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnIzmeniProizvod.Location = new System.Drawing.Point(12, 201);
            this.btnIzmeniProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmeniProizvod.Name = "btnIzmeniProizvod";
            this.btnIzmeniProizvod.Size = new System.Drawing.Size(160, 62);
            this.btnIzmeniProizvod.TabIndex = 48;
            this.btnIzmeniProizvod.Text = "Izmeni proizvod";
            this.btnIzmeniProizvod.UseVisualStyleBackColor = false;
            this.btnIzmeniProizvod.Click += new System.EventHandler(this.btnIzmeniProizvod_Click);
            // 
            // btnDodajProizvod
            // 
            this.btnDodajProizvod.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDodajProizvod.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajProizvod.Location = new System.Drawing.Point(12, 120);
            this.btnDodajProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajProizvod.Name = "btnDodajProizvod";
            this.btnDodajProizvod.Size = new System.Drawing.Size(160, 62);
            this.btnDodajProizvod.TabIndex = 47;
            this.btnDodajProizvod.Text = "Dodaj proizvod";
            this.btnDodajProizvod.UseVisualStyleBackColor = false;
            this.btnDodajProizvod.Click += new System.EventHandler(this.btnDodajProizvod_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaProizvoda);
            this.groupBox1.Location = new System.Drawing.Point(201, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(680, 459);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista igracaka";
            // 
            // listaProizvoda
            // 
            this.listaProizvoda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listaProizvoda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaProizvoda.FullRowSelect = true;
            this.listaProizvoda.GridLines = true;
            this.listaProizvoda.Location = new System.Drawing.Point(4, 19);
            this.listaProizvoda.Margin = new System.Windows.Forms.Padding(4);
            this.listaProizvoda.Name = "listaProizvoda";
            this.listaProizvoda.Size = new System.Drawing.Size(672, 436);
            this.listaProizvoda.TabIndex = 4;
            this.listaProizvoda.UseCompatibleStateImageBehavior = false;
            this.listaProizvoda.View = System.Windows.Forms.View.Details;
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
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Proizvodjac";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 180;
            // 
            // txbBrojProizvoda
            // 
            this.txbBrojProizvoda.Location = new System.Drawing.Point(12, 67);
            this.txbBrojProizvoda.Margin = new System.Windows.Forms.Padding(4);
            this.txbBrojProizvoda.Name = "txbBrojProizvoda";
            this.txbBrojProizvoda.Size = new System.Drawing.Size(160, 22);
            this.txbBrojProizvoda.TabIndex = 46;
            this.txbBrojProizvoda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "Ukupan broj proizvoda:";
            // 
            // ProizvodiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(894, 491);
            this.Controls.Add(this.btnObrisiProizvod);
            this.Controls.Add(this.btnIzmeniProizvod);
            this.Controls.Add(this.btnDodajProizvod);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txbBrojProizvoda);
            this.Controls.Add(this.label1);
            this.Name = "ProizvodiForm";
            this.Text = "ProizvodiForm";
            this.Load += new System.EventHandler(this.ProizvodiForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObrisiProizvod;
        private System.Windows.Forms.Button btnIzmeniProizvod;
        private System.Windows.Forms.Button btnDodajProizvod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listaProizvoda;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbBrojProizvoda;
        private System.Windows.Forms.Label label1;
    }
}