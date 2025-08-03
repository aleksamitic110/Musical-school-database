namespace Muzicka_skola
{
	partial class MainForm
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
			this.pictureBoxPocetna = new System.Windows.Forms.PictureBox();
			this.buttunPolaznici = new System.Windows.Forms.Button();
			this.buttonNastavnici = new System.Windows.Forms.Button();
			this.buttonKursevi = new System.Windows.Forms.Button();
			this.buttonIspiti = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPocetna)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(101, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(413, 55);
			this.label1.TabIndex = 0;
			this.label1.Text = "MUZICKA SKOLA";
			// 
			// pictureBoxPocetna
			// 
			this.pictureBoxPocetna.BackColor = System.Drawing.Color.IndianRed;
			this.pictureBoxPocetna.Location = new System.Drawing.Point(111, 67);
			this.pictureBoxPocetna.Name = "pictureBoxPocetna";
			this.pictureBoxPocetna.Size = new System.Drawing.Size(403, 164);
			this.pictureBoxPocetna.TabIndex = 1;
			this.pictureBoxPocetna.TabStop = false;
			// 
			// buttunPolaznici
			// 
			this.buttunPolaznici.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttunPolaznici.Location = new System.Drawing.Point(111, 237);
			this.buttunPolaznici.Name = "buttunPolaznici";
			this.buttunPolaznici.Size = new System.Drawing.Size(403, 71);
			this.buttunPolaznici.TabIndex = 2;
			this.buttunPolaznici.Text = "Polaznici";
			this.buttunPolaznici.UseVisualStyleBackColor = true;
			this.buttunPolaznici.Click += new System.EventHandler(this.buttunPolaznici_Click);
			// 
			// buttonNastavnici
			// 
			this.buttonNastavnici.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonNastavnici.Location = new System.Drawing.Point(111, 314);
			this.buttonNastavnici.Name = "buttonNastavnici";
			this.buttonNastavnici.Size = new System.Drawing.Size(403, 71);
			this.buttonNastavnici.TabIndex = 3;
			this.buttonNastavnici.Text = "Nastavnici";
			this.buttonNastavnici.UseVisualStyleBackColor = true;
			this.buttonNastavnici.Click += new System.EventHandler(this.buttonNastavnici_Click);
			// 
			// buttonKursevi
			// 
			this.buttonKursevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonKursevi.Location = new System.Drawing.Point(111, 391);
			this.buttonKursevi.Name = "buttonKursevi";
			this.buttonKursevi.Size = new System.Drawing.Size(403, 71);
			this.buttonKursevi.TabIndex = 4;
			this.buttonKursevi.Text = "Kursevi";
			this.buttonKursevi.UseVisualStyleBackColor = true;
			this.buttonKursevi.Click += new System.EventHandler(this.buttonKursevi_Click);
			// 
			// buttonIspiti
			// 
			this.buttonIspiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonIspiti.Location = new System.Drawing.Point(111, 468);
			this.buttonIspiti.Name = "buttonIspiti";
			this.buttonIspiti.Size = new System.Drawing.Size(403, 71);
			this.buttonIspiti.TabIndex = 5;
			this.buttonIspiti.Text = "Ispiti";
			this.buttonIspiti.UseVisualStyleBackColor = true;
			this.buttonIspiti.Click += new System.EventHandler(this.buttonIspiti_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.ClientSize = new System.Drawing.Size(621, 556);
			this.Controls.Add(this.buttonIspiti);
			this.Controls.Add(this.buttonKursevi);
			this.Controls.Add(this.buttonNastavnici);
			this.Controls.Add(this.buttunPolaznici);
			this.Controls.Add(this.pictureBoxPocetna);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "Muzicka skola";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPocetna)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBoxPocetna;
		private System.Windows.Forms.Button buttunPolaznici;
		private System.Windows.Forms.Button buttonNastavnici;
		private System.Windows.Forms.Button buttonKursevi;
		private System.Windows.Forms.Button buttonIspiti;
	}
}

