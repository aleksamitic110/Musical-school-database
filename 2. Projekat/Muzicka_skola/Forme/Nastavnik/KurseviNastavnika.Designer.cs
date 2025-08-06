namespace Muzicka_skola.Forme.Nastavnik
{
    partial class KurseviNastavnika
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPrikazPolaznika = new System.Windows.Forms.Button();
            this.buttonPrikaziKurseve = new System.Windows.Forms.Button();
            this.buttonPrikaziIspite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 291);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPrikaziIspite);
            this.groupBox1.Controls.Add(this.buttonPrikaziKurseve);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.buttonPrikazPolaznika);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 429);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // buttonPrikazPolaznika
            // 
            this.buttonPrikazPolaznika.Location = new System.Drawing.Point(315, 333);
            this.buttonPrikazPolaznika.Name = "buttonPrikazPolaznika";
            this.buttonPrikazPolaznika.Size = new System.Drawing.Size(150, 47);
            this.buttonPrikazPolaznika.TabIndex = 6;
            this.buttonPrikazPolaznika.Text = "Polaznici koji su polozili kurs";
            this.buttonPrikazPolaznika.UseVisualStyleBackColor = true;
            this.buttonPrikazPolaznika.Click += new System.EventHandler(this.buttonPrikazPolaznika_Click);
            // 
            // buttonPrikaziKurseve
            // 
            this.buttonPrikaziKurseve.Location = new System.Drawing.Point(127, 333);
            this.buttonPrikaziKurseve.Name = "buttonPrikaziKurseve";
            this.buttonPrikaziKurseve.Size = new System.Drawing.Size(150, 47);
            this.buttonPrikaziKurseve.TabIndex = 7;
            this.buttonPrikaziKurseve.Text = "Prikazi kurseve";
            this.buttonPrikaziKurseve.UseVisualStyleBackColor = true;
            this.buttonPrikaziKurseve.Click += new System.EventHandler(this.buttonPrikaziKurseve_Click);
            // 
            // buttonPrikaziIspite
            // 
            this.buttonPrikaziIspite.Location = new System.Drawing.Point(496, 333);
            this.buttonPrikaziIspite.Name = "buttonPrikaziIspite";
            this.buttonPrikaziIspite.Size = new System.Drawing.Size(150, 47);
            this.buttonPrikaziIspite.TabIndex = 8;
            this.buttonPrikaziIspite.Text = "Prikazi ispite koji predstoje";
            this.buttonPrikaziIspite.UseVisualStyleBackColor = true;
            this.buttonPrikaziIspite.Click += new System.EventHandler(this.buttonPrikaziIspite_Click);
            // 
            // KurseviNastavnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "KurseviNastavnika";
            this.Text = "Kursevi Nastavnika";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPrikazPolaznika;
        private System.Windows.Forms.Button buttonPrikaziIspite;
        private System.Windows.Forms.Button buttonPrikaziKurseve;
    }
}