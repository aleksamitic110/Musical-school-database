namespace Prodavnica.Forme
{
    partial class DodajZaposlenogForma
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbDatumDo = new System.Windows.Forms.CheckBox();
            this.DatumDo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.datumOd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMbr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.datumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.txbSrednjeSlovo = new System.Windows.Forms.TextBox();
            this.txbStrucnaSprema = new System.Windows.Forms.TextBox();
            this.txbPrezime = new System.Windows.Forms.TextBox();
            this.txbIme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbDatumDo);
            this.groupBox1.Controls.Add(this.DatumDo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.datumOd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txbMbr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
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
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(414, 530);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o zaposlenom";
            // 
            // chbDatumDo
            // 
            this.chbDatumDo.AutoSize = true;
            this.chbDatumDo.Checked = true;
            this.chbDatumDo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDatumDo.Location = new System.Drawing.Point(165, 401);
            this.chbDatumDo.Margin = new System.Windows.Forms.Padding(4);
            this.chbDatumDo.Name = "chbDatumDo";
            this.chbDatumDo.Size = new System.Drawing.Size(211, 24);
            this.chbDatumDo.TabIndex = 8;
            this.chbDatumDo.Text = "Datum Do nije definisan";
            this.chbDatumDo.UseVisualStyleBackColor = true;
            this.chbDatumDo.CheckedChanged += new System.EventHandler(this.omoguciDatumDo);
            // 
            // DatumDo
            // 
            this.DatumDo.Enabled = false;
            this.DatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatumDo.Location = new System.Drawing.Point(165, 367);
            this.DatumDo.Margin = new System.Windows.Forms.Padding(4);
            this.DatumDo.Name = "DatumDo";
            this.DatumDo.Size = new System.Drawing.Size(201, 26);
            this.DatumDo.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 374);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Datum Do:";
            // 
            // datumOd
            // 
            this.datumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumOd.Location = new System.Drawing.Point(165, 314);
            this.datumOd.Margin = new System.Windows.Forms.Padding(4);
            this.datumOd.Name = "datumOd";
            this.datumOd.Size = new System.Drawing.Size(201, 26);
            this.datumOd.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 321);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Datum Od:";
            // 
            // txbMbr
            // 
            this.txbMbr.Location = new System.Drawing.Point(165, 172);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SandyBrown;
            this.button1.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(221, 463);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "DODAJ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // datumRodjenja
            // 
            this.datumRodjenja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumRodjenja.Location = new System.Drawing.Point(165, 210);
            this.datumRodjenja.Margin = new System.Windows.Forms.Padding(4);
            this.datumRodjenja.Name = "datumRodjenja";
            this.datumRodjenja.Size = new System.Drawing.Size(201, 26);
            this.datumRodjenja.TabIndex = 4;
            // 
            // txbSrednjeSlovo
            // 
            this.txbSrednjeSlovo.Location = new System.Drawing.Point(165, 135);
            this.txbSrednjeSlovo.Margin = new System.Windows.Forms.Padding(4);
            this.txbSrednjeSlovo.MaxLength = 1;
            this.txbSrednjeSlovo.Name = "txbSrednjeSlovo";
            this.txbSrednjeSlovo.Size = new System.Drawing.Size(201, 26);
            this.txbSrednjeSlovo.TabIndex = 2;
            // 
            // txbStrucnaSprema
            // 
            this.txbStrucnaSprema.Location = new System.Drawing.Point(165, 260);
            this.txbStrucnaSprema.Margin = new System.Windows.Forms.Padding(4);
            this.txbStrucnaSprema.Name = "txbStrucnaSprema";
            this.txbStrucnaSprema.Size = new System.Drawing.Size(201, 26);
            this.txbStrucnaSprema.TabIndex = 5;
            // 
            // txbPrezime
            // 
            this.txbPrezime.Location = new System.Drawing.Point(165, 92);
            this.txbPrezime.Margin = new System.Windows.Forms.Padding(4);
            this.txbPrezime.Name = "txbPrezime";
            this.txbPrezime.Size = new System.Drawing.Size(201, 26);
            this.txbPrezime.TabIndex = 1;
            // 
            // txbIme
            // 
            this.txbIme.Location = new System.Drawing.Point(165, 49);
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
            // DodajZaposlenogForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(443, 558);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(461, 605);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 605);
            this.Name = "DodajZaposlenogForma";
            this.Text = "DODAVANJE ZAPOSLENOG";
            this.Load += new System.EventHandler(this.DodajZaposlenogForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker datumRodjenja;
        private System.Windows.Forms.TextBox txbSrednjeSlovo;
        private System.Windows.Forms.TextBox txbStrucnaSprema;
        private System.Windows.Forms.TextBox txbPrezime;
        private System.Windows.Forms.TextBox txbIme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbMbr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datumOd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbDatumDo;
        private System.Windows.Forms.DateTimePicker DatumDo;
        private System.Windows.Forms.Label label8;
    }
}