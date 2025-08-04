namespace Muzicka_skola.Forme
{
	partial class GlobalForm
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
            this.panelPrikaz = new System.Windows.Forms.Panel();
            this.dataGridViewPrikazPodataka = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.panelDodatniFilteri = new System.Windows.Forms.Panel();
            this.panelStandardniFilteri = new System.Windows.Forms.Panel();
            this.panelFunkcije = new System.Windows.Forms.Panel();
            this.panelDodatneFunkcije = new System.Windows.Forms.Panel();
            this.panelStandardneFunkcije = new System.Windows.Forms.Panel();
            this.DeleteFunkcija = new System.Windows.Forms.Button();
            this.UpdateFunkcija = new System.Windows.Forms.Button();
            this.AddFunkcija = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonIspiti = new System.Windows.Forms.Button();
            this.buttonKursevi = new System.Windows.Forms.Button();
            this.buttonNastavnici = new System.Windows.Forms.Button();
            this.buttunPolaznici = new System.Windows.Forms.Button();
            this.pictureBoxPocetna = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDodatneFunkcijeNastavnik = new System.Windows.Forms.Panel();
            this.radioButtonSviNastavnici = new System.Windows.Forms.RadioButton();
            this.radioButtonHonorarni = new System.Windows.Forms.RadioButton();
            this.radioButtonStalni = new System.Windows.Forms.RadioButton();
            this.panelPrikaz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrikazPodataka)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.panelFunkcije.SuspendLayout();
            this.panelDodatneFunkcije.SuspendLayout();
            this.panelStandardneFunkcije.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPocetna)).BeginInit();
            this.panelDodatneFunkcijeNastavnik.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrikaz
            // 
            this.panelPrikaz.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrikaz.Controls.Add(this.dataGridViewPrikazPodataka);
            this.panelPrikaz.Location = new System.Drawing.Point(309, 31);
            this.panelPrikaz.Margin = new System.Windows.Forms.Padding(4);
            this.panelPrikaz.Name = "panelPrikaz";
            this.panelPrikaz.Size = new System.Drawing.Size(1171, 594);
            this.panelPrikaz.TabIndex = 0;
            // 
            // dataGridViewPrikazPodataka
            // 
            this.dataGridViewPrikazPodataka.BackgroundColor = System.Drawing.Color.DarkSalmon;
            this.dataGridViewPrikazPodataka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrikazPodataka.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewPrikazPodataka.Location = new System.Drawing.Point(16, 17);
            this.dataGridViewPrikazPodataka.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewPrikazPodataka.Name = "dataGridViewPrikazPodataka";
            this.dataGridViewPrikazPodataka.RowHeadersWidth = 51;
            this.dataGridViewPrikazPodataka.Size = new System.Drawing.Size(1135, 561);
            this.dataGridViewPrikazPodataka.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.DarkKhaki;
            this.panelFilter.Controls.Add(this.panelDodatniFilteri);
            this.panelFilter.Controls.Add(this.panelStandardniFilteri);
            this.panelFilter.Location = new System.Drawing.Point(309, 633);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1171, 123);
            this.panelFilter.TabIndex = 1;
            // 
            // panelDodatniFilteri
            // 
            this.panelDodatniFilteri.BackColor = System.Drawing.Color.DarkOrange;
            this.panelDodatniFilteri.Location = new System.Drawing.Point(691, 4);
            this.panelDodatniFilteri.Margin = new System.Windows.Forms.Padding(4);
            this.panelDodatniFilteri.Name = "panelDodatniFilteri";
            this.panelDodatniFilteri.Size = new System.Drawing.Size(460, 116);
            this.panelDodatniFilteri.TabIndex = 1;
            // 
            // panelStandardniFilteri
            // 
            this.panelStandardniFilteri.BackColor = System.Drawing.Color.Gold;
            this.panelStandardniFilteri.Location = new System.Drawing.Point(16, 4);
            this.panelStandardniFilteri.Margin = new System.Windows.Forms.Padding(4);
            this.panelStandardniFilteri.Name = "panelStandardniFilteri";
            this.panelStandardniFilteri.Size = new System.Drawing.Size(667, 116);
            this.panelStandardniFilteri.TabIndex = 0;
            // 
            // panelFunkcije
            // 
            this.panelFunkcije.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelFunkcije.Controls.Add(this.panelDodatneFunkcije);
            this.panelFunkcije.Controls.Add(this.panelStandardneFunkcije);
            this.panelFunkcije.Controls.Add(this.buttonFilter);
            this.panelFunkcije.Location = new System.Drawing.Point(1487, 31);
            this.panelFunkcije.Margin = new System.Windows.Forms.Padding(4);
            this.panelFunkcije.Name = "panelFunkcije";
            this.panelFunkcije.Size = new System.Drawing.Size(409, 725);
            this.panelFunkcije.TabIndex = 2;
            // 
            // panelDodatneFunkcije
            // 
            this.panelDodatneFunkcije.BackColor = System.Drawing.Color.Orange;
            this.panelDodatneFunkcije.Controls.Add(this.panelDodatneFunkcijeNastavnik);
            this.panelDodatneFunkcije.Location = new System.Drawing.Point(4, 321);
            this.panelDodatneFunkcije.Margin = new System.Windows.Forms.Padding(4);
            this.panelDodatneFunkcije.Name = "panelDodatneFunkcije";
            this.panelDodatneFunkcije.Size = new System.Drawing.Size(401, 257);
            this.panelDodatneFunkcije.TabIndex = 2;
            // 
            // panelStandardneFunkcije
            // 
            this.panelStandardneFunkcije.BackColor = System.Drawing.Color.NavajoWhite;
            this.panelStandardneFunkcije.Controls.Add(this.DeleteFunkcija);
            this.panelStandardneFunkcije.Controls.Add(this.UpdateFunkcija);
            this.panelStandardneFunkcije.Controls.Add(this.AddFunkcija);
            this.panelStandardneFunkcije.Location = new System.Drawing.Point(4, 16);
            this.panelStandardneFunkcije.Margin = new System.Windows.Forms.Padding(4);
            this.panelStandardneFunkcije.Name = "panelStandardneFunkcije";
            this.panelStandardneFunkcije.Size = new System.Drawing.Size(401, 297);
            this.panelStandardneFunkcije.TabIndex = 1;
            // 
            // DeleteFunkcija
            // 
            this.DeleteFunkcija.Location = new System.Drawing.Point(23, 204);
            this.DeleteFunkcija.Name = "DeleteFunkcija";
            this.DeleteFunkcija.Size = new System.Drawing.Size(359, 61);
            this.DeleteFunkcija.TabIndex = 2;
            this.DeleteFunkcija.Text = "Delete";
            this.DeleteFunkcija.UseVisualStyleBackColor = true;
            // 
            // UpdateFunkcija
            // 
            this.UpdateFunkcija.Location = new System.Drawing.Point(23, 112);
            this.UpdateFunkcija.Name = "UpdateFunkcija";
            this.UpdateFunkcija.Size = new System.Drawing.Size(359, 64);
            this.UpdateFunkcija.TabIndex = 1;
            this.UpdateFunkcija.Text = "Update";
            this.UpdateFunkcija.UseVisualStyleBackColor = true;
            // 
            // AddFunkcija
            // 
            this.AddFunkcija.Location = new System.Drawing.Point(23, 20);
            this.AddFunkcija.Name = "AddFunkcija";
            this.AddFunkcija.Size = new System.Drawing.Size(359, 69);
            this.AddFunkcija.TabIndex = 0;
            this.AddFunkcija.Text = "Add";
            this.AddFunkcija.UseVisualStyleBackColor = true;
            this.AddFunkcija.Click += new System.EventHandler(this.AddFunkcija_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.Location = new System.Drawing.Point(4, 602);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(401, 119);
            this.buttonFilter.TabIndex = 0;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonIspiti);
            this.panel1.Controls.Add(this.buttonKursevi);
            this.panel1.Controls.Add(this.buttonNastavnici);
            this.panel1.Controls.Add(this.buttunPolaznici);
            this.panel1.Controls.Add(this.pictureBoxPocetna);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 725);
            this.panel1.TabIndex = 3;
            // 
            // buttonIspiti
            // 
            this.buttonIspiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIspiti.Location = new System.Drawing.Point(108, 606);
            this.buttonIspiti.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIspiti.Name = "buttonIspiti";
            this.buttonIspiti.Size = new System.Drawing.Size(163, 87);
            this.buttonIspiti.TabIndex = 11;
            this.buttonIspiti.Text = "Ispiti";
            this.buttonIspiti.UseVisualStyleBackColor = true;
            this.buttonIspiti.Click += new System.EventHandler(this.buttonIspiti_Click);
            // 
            // buttonKursevi
            // 
            this.buttonKursevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKursevi.Location = new System.Drawing.Point(83, 506);
            this.buttonKursevi.Margin = new System.Windows.Forms.Padding(4);
            this.buttonKursevi.Name = "buttonKursevi";
            this.buttonKursevi.Size = new System.Drawing.Size(201, 87);
            this.buttonKursevi.TabIndex = 10;
            this.buttonKursevi.Text = "Kursevi";
            this.buttonKursevi.UseVisualStyleBackColor = true;
            this.buttonKursevi.Click += new System.EventHandler(this.buttonKursevi_Click);
            // 
            // buttonNastavnici
            // 
            this.buttonNastavnici.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNastavnici.Location = new System.Drawing.Point(83, 411);
            this.buttonNastavnici.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNastavnici.Name = "buttonNastavnici";
            this.buttonNastavnici.Size = new System.Drawing.Size(205, 87);
            this.buttonNastavnici.TabIndex = 9;
            this.buttonNastavnici.Text = "Nastavnici";
            this.buttonNastavnici.UseVisualStyleBackColor = true;
            this.buttonNastavnici.Click += new System.EventHandler(this.buttonNastavnici_Click);
            // 
            // buttunPolaznici
            // 
            this.buttunPolaznici.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttunPolaznici.Location = new System.Drawing.Point(84, 338);
            this.buttunPolaznici.Margin = new System.Windows.Forms.Padding(4);
            this.buttunPolaznici.Name = "buttunPolaznici";
            this.buttunPolaznici.Size = new System.Drawing.Size(204, 54);
            this.buttunPolaznici.TabIndex = 8;
            this.buttunPolaznici.Text = "Polaznici";
            this.buttunPolaznici.UseVisualStyleBackColor = true;
            this.buttunPolaznici.Click += new System.EventHandler(this.buttunPolaznici_Click);
            // 
            // pictureBoxPocetna
            // 
            this.pictureBoxPocetna.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBoxPocetna.Location = new System.Drawing.Point(84, 107);
            this.pictureBoxPocetna.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPocetna.Name = "pictureBoxPocetna";
            this.pictureBoxPocetna.Size = new System.Drawing.Size(537, 202);
            this.pictureBoxPocetna.TabIndex = 7;
            this.pictureBoxPocetna.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 69);
            this.label1.TabIndex = 6;
            this.label1.Text = "MUZICKA SKOLA";
            // 
            // panelDodatneFunkcijeNastavnik
            // 
            this.panelDodatneFunkcijeNastavnik.Controls.Add(this.radioButtonStalni);
            this.panelDodatneFunkcijeNastavnik.Controls.Add(this.radioButtonHonorarni);
            this.panelDodatneFunkcijeNastavnik.Controls.Add(this.radioButtonSviNastavnici);
            this.panelDodatneFunkcijeNastavnik.Location = new System.Drawing.Point(0, 0);
            this.panelDodatneFunkcijeNastavnik.Name = "panelDodatneFunkcijeNastavnik";
            this.panelDodatneFunkcijeNastavnik.Size = new System.Drawing.Size(401, 257);
            this.panelDodatneFunkcijeNastavnik.TabIndex = 0;
            this.panelDodatneFunkcijeNastavnik.Visible = false;
            // 
            // radioButtonSviNastavnici
            // 
            this.radioButtonSviNastavnici.AutoSize = true;
            this.radioButtonSviNastavnici.Checked = true;
            this.radioButtonSviNastavnici.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSviNastavnici.Location = new System.Drawing.Point(23, 17);
            this.radioButtonSviNastavnici.Name = "radioButtonSviNastavnici";
            this.radioButtonSviNastavnici.Size = new System.Drawing.Size(136, 24);
            this.radioButtonSviNastavnici.TabIndex = 0;
            this.radioButtonSviNastavnici.TabStop = true;
            this.radioButtonSviNastavnici.Text = "Svi Nastavnici";
            this.radioButtonSviNastavnici.UseVisualStyleBackColor = true;
            this.radioButtonSviNastavnici.CheckedChanged += new System.EventHandler(this.NastavniciRadioButton_CheckedChanged);
            // 
            // radioButtonHonorarni
            // 
            this.radioButtonHonorarni.AutoSize = true;
            this.radioButtonHonorarni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHonorarni.Location = new System.Drawing.Point(181, 17);
            this.radioButtonHonorarni.Name = "radioButtonHonorarni";
            this.radioButtonHonorarni.Size = new System.Drawing.Size(104, 24);
            this.radioButtonHonorarni.TabIndex = 1;
            this.radioButtonHonorarni.Text = "Honorarni";
            this.radioButtonHonorarni.UseVisualStyleBackColor = true;
            this.radioButtonHonorarni.CheckedChanged += new System.EventHandler(this.NastavniciRadioButton_CheckedChanged);
            // 
            // radioButtonStalni
            // 
            this.radioButtonStalni.AutoSize = true;
            this.radioButtonStalni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStalni.Location = new System.Drawing.Point(310, 17);
            this.radioButtonStalni.Name = "radioButtonStalni";
            this.radioButtonStalni.Size = new System.Drawing.Size(72, 24);
            this.radioButtonStalni.TabIndex = 2;
            this.radioButtonStalni.Text = "Stalni";
            this.radioButtonStalni.UseVisualStyleBackColor = true;
            this.radioButtonStalni.CheckedChanged += new System.EventHandler(this.NastavniciRadioButton_CheckedChanged);
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 796);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelFunkcije);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelPrikaz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GlobalForm";
            this.Text = "GlobalForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelPrikaz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrikazPodataka)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFunkcije.ResumeLayout(false);
            this.panelDodatneFunkcije.ResumeLayout(false);
            this.panelStandardneFunkcije.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPocetna)).EndInit();
            this.panelDodatneFunkcijeNastavnik.ResumeLayout(false);
            this.panelDodatneFunkcijeNastavnik.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelPrikaz;
		private System.Windows.Forms.Panel panelFilter;
		private System.Windows.Forms.Panel panelFunkcije;
		private System.Windows.Forms.Button buttonFilter;
		private System.Windows.Forms.DataGridView dataGridViewPrikazPodataka;
		private System.Windows.Forms.Panel panelDodatneFunkcije;
		private System.Windows.Forms.Panel panelStandardneFunkcije;
		private System.Windows.Forms.Panel panelStandardniFilteri;
		private System.Windows.Forms.Panel panelDodatniFilteri;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonIspiti;
		private System.Windows.Forms.Button buttonKursevi;
		private System.Windows.Forms.Button buttonNastavnici;
		private System.Windows.Forms.Button buttunPolaznici;
		private System.Windows.Forms.PictureBox pictureBoxPocetna;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteFunkcija;
        private System.Windows.Forms.Button UpdateFunkcija;
        private System.Windows.Forms.Button AddFunkcija;
        private System.Windows.Forms.Panel panelDodatneFunkcijeNastavnik;
        private System.Windows.Forms.RadioButton radioButtonSviNastavnici;
        private System.Windows.Forms.RadioButton radioButtonStalni;
        private System.Windows.Forms.RadioButton radioButtonHonorarni;
    }
}