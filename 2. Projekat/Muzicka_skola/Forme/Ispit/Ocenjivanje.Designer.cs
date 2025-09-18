namespace Muzicka_skola.Forme.Ispit
{
    partial class Ocenjivanje
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
            this.datagrd = new System.Windows.Forms.DataGridView();
            this.buttonOceni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrd)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrd
            // 
            this.datagrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrd.Location = new System.Drawing.Point(12, 12);
            this.datagrd.Name = "datagrd";
            this.datagrd.RowHeadersWidth = 51;
            this.datagrd.RowTemplate.Height = 24;
            this.datagrd.Size = new System.Drawing.Size(776, 346);
            this.datagrd.TabIndex = 2;
            // 
            // buttonOceni
            // 
            this.buttonOceni.Location = new System.Drawing.Point(250, 376);
            this.buttonOceni.Name = "buttonOceni";
            this.buttonOceni.Size = new System.Drawing.Size(309, 52);
            this.buttonOceni.TabIndex = 3;
            this.buttonOceni.Text = "Oceni Polaznika";
            this.buttonOceni.UseVisualStyleBackColor = true;
            this.buttonOceni.Click += new System.EventHandler(this.buttonOceni_Click);
            // 
            // Ocenjivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.buttonOceni);
            this.Controls.Add(this.datagrd);
            this.Name = "Ocenjivanje";
            this.Text = "Ocenjivanje";
            ((System.ComponentModel.ISupportInitialize)(this.datagrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrd;
        private System.Windows.Forms.Button buttonOceni;
    }
}