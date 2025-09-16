namespace Muzicka_skola.Forme.Kursevi
{
    partial class DodajCas
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
            this.labelIdKursa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxIdCasa = new System.Windows.Forms.TextBox();
            this.textBoxLekcija = new System.Windows.Forms.TextBox();
            this.comboBoxIdUcionice = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIdKursa
            // 
            this.labelIdKursa.AutoSize = true;
            this.labelIdKursa.Font = new System.Drawing.Font("Stencil", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdKursa.Location = new System.Drawing.Point(57, 20);
            this.labelIdKursa.Name = "labelIdKursa";
            this.labelIdKursa.Size = new System.Drawing.Size(118, 47);
            this.labelIdKursa.TabIndex = 0;
            this.labelIdKursa.Text = "K999";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lekcija: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Ucionice:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID Casa: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 160);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // textBoxIdCasa
            // 
            this.textBoxIdCasa.Location = new System.Drawing.Point(80, 81);
            this.textBoxIdCasa.Name = "textBoxIdCasa";
            this.textBoxIdCasa.Size = new System.Drawing.Size(141, 20);
            this.textBoxIdCasa.TabIndex = 5;
            // 
            // textBoxLekcija
            // 
            this.textBoxLekcija.Location = new System.Drawing.Point(80, 107);
            this.textBoxLekcija.Name = "textBoxLekcija";
            this.textBoxLekcija.Size = new System.Drawing.Size(141, 20);
            this.textBoxLekcija.TabIndex = 6;
            // 
            // comboBoxIdUcionice
            // 
            this.comboBoxIdUcionice.FormattingEnabled = true;
            this.comboBoxIdUcionice.Location = new System.Drawing.Point(80, 133);
            this.comboBoxIdUcionice.Name = "comboBoxIdUcionice";
            this.comboBoxIdUcionice.Size = new System.Drawing.Size(141, 21);
            this.comboBoxIdUcionice.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(10, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "Zakazi Cas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DodajCas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 247);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxIdUcionice);
            this.Controls.Add(this.textBoxLekcija);
            this.Controls.Add(this.textBoxIdCasa);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelIdKursa);
            this.Name = "DodajCas";
            this.Text = "DodajCas";
            this.Load += new System.EventHandler(this.DodajCas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIdKursa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxIdCasa;
        private System.Windows.Forms.TextBox textBoxLekcija;
        private System.Windows.Forms.ComboBox comboBoxIdUcionice;
        private System.Windows.Forms.Button button1;
    }
}