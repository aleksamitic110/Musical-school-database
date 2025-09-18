namespace Muzicka_skola.Forme.Polaznici
{
	partial class PrikazKursevaPolaznika
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
			this.dataGridViewKursevaPolaznika = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewKursevaPolaznika)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewKursevaPolaznika
			// 
			this.dataGridViewKursevaPolaznika.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewKursevaPolaznika.Location = new System.Drawing.Point(12, 12);
			this.dataGridViewKursevaPolaznika.Name = "dataGridViewKursevaPolaznika";
			this.dataGridViewKursevaPolaznika.Size = new System.Drawing.Size(776, 426);
			this.dataGridViewKursevaPolaznika.TabIndex = 0;
			// 
			// PrikazKursevaPolaznika
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridViewKursevaPolaznika);
			this.Name = "PrikazKursevaPolaznika";
			this.Text = "PrikazKursevaPolaznika";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewKursevaPolaznika)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewKursevaPolaznika;
	}
}