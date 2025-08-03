namespace Prodavnica.Forme
{
    partial class DodajOdeljenjeDo5Forma
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
            this.button1 = new System.Windows.Forms.Button();
            this.chbPult = new System.Windows.Forms.CheckBox();
            this.brojKasa = new System.Windows.Forms.NumericUpDown();
            this.txbLokacija = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brojKasa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lokacija:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Broj Kasa:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chbPult);
            this.groupBox1.Controls.Add(this.brojKasa);
            this.groupBox1.Controls.Add(this.txbLokacija);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(348, 279);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci o odeljenju";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SandyBrown;
            this.button1.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(163, 213);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "DODAJ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chbPult
            // 
            this.chbPult.AutoSize = true;
            this.chbPult.Location = new System.Drawing.Point(227, 159);
            this.chbPult.Margin = new System.Windows.Forms.Padding(4);
            this.chbPult.Name = "chbPult";
            this.chbPult.Size = new System.Drawing.Size(98, 28);
            this.chbPult.TabIndex = 5;
            this.chbPult.Text = "Info Pult";
            this.chbPult.UseVisualStyleBackColor = true;
            // 
            // brojKasa
            // 
            this.brojKasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brojKasa.Location = new System.Drawing.Point(133, 98);
            this.brojKasa.Margin = new System.Windows.Forms.Padding(4);
            this.brojKasa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brojKasa.Name = "brojKasa";
            this.brojKasa.Size = new System.Drawing.Size(200, 29);
            this.brojKasa.TabIndex = 4;
            this.brojKasa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txbLokacija
            // 
            this.txbLokacija.Location = new System.Drawing.Point(133, 46);
            this.txbLokacija.Margin = new System.Windows.Forms.Padding(4);
            this.txbLokacija.Name = "txbLokacija";
            this.txbLokacija.Size = new System.Drawing.Size(199, 29);
            this.txbLokacija.TabIndex = 3;
            // 
            // DodajOdeljenjeDo5Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(372, 303);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 350);
            this.Name = "DodajOdeljenjeDo5Forma";
            this.Text = "DODAVANJE ODELJENJA";
            this.Load += new System.EventHandler(this.DodajOdeljenjeDo5Forma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brojKasa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chbPult;
        private System.Windows.Forms.NumericUpDown brojKasa;
        private System.Windows.Forms.TextBox txbLokacija;
    }
}