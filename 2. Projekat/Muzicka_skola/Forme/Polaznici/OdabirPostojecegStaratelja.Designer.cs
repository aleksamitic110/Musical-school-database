namespace Muzicka_skola.Forme.Polaznici
{
	partial class OdabirPostojecegStaratelja
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
			this.dataGridViewOdaberiStaratelja = new System.Windows.Forms.DataGridView();
			this.buttonOdaberiStaratelja = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdaberiStaratelja)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewOdaberiStaratelja
			// 
			this.dataGridViewOdaberiStaratelja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewOdaberiStaratelja.Location = new System.Drawing.Point(12, 12);
			this.dataGridViewOdaberiStaratelja.Name = "dataGridViewOdaberiStaratelja";
			this.dataGridViewOdaberiStaratelja.Size = new System.Drawing.Size(1026, 389);
			this.dataGridViewOdaberiStaratelja.TabIndex = 0;
			// 
			// buttonOdaberiStaratelja
			// 
			this.buttonOdaberiStaratelja.Location = new System.Drawing.Point(12, 407);
			this.buttonOdaberiStaratelja.Name = "buttonOdaberiStaratelja";
			this.buttonOdaberiStaratelja.Size = new System.Drawing.Size(1026, 39);
			this.buttonOdaberiStaratelja.TabIndex = 1;
			this.buttonOdaberiStaratelja.Text = "OK";
			this.buttonOdaberiStaratelja.UseVisualStyleBackColor = true;
			this.buttonOdaberiStaratelja.Click += new System.EventHandler(this.buttonOdaberiStaratelja_Click);
			// 
			// OdabirPostojecegStaratelja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1050, 450);
			this.Controls.Add(this.buttonOdaberiStaratelja);
			this.Controls.Add(this.dataGridViewOdaberiStaratelja);
			this.Name = "OdabirPostojecegStaratelja";
			this.Text = "OdabirPsotojecegStaratelja";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOdaberiStaratelja)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewOdaberiStaratelja;
		private System.Windows.Forms.Button buttonOdaberiStaratelja;
	}
}