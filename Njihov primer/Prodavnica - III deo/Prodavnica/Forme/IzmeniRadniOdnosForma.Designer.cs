namespace Prodavnica.Forme
{
    partial class IzmeniRadniOdnosForma
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbDatumDo = new System.Windows.Forms.CheckBox();
            this.DatumDo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.datumOd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbDatumDo);
            this.groupBox1.Controls.Add(this.DatumDo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.datumOd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(361, 273);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o Radnom Odnosu";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chbDatumDo
            // 
            this.chbDatumDo.AutoSize = true;
            this.chbDatumDo.Checked = true;
            this.chbDatumDo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDatumDo.Location = new System.Drawing.Point(132, 137);
            this.chbDatumDo.Margin = new System.Windows.Forms.Padding(4);
            this.chbDatumDo.Name = "chbDatumDo";
            this.chbDatumDo.Size = new System.Drawing.Size(211, 24);
            this.chbDatumDo.TabIndex = 19;
            this.chbDatumDo.Text = "Datum Do nije definisan";
            this.chbDatumDo.UseVisualStyleBackColor = true;
            this.chbDatumDo.CheckedChanged += new System.EventHandler(this.omoguciDatumDo);
            // 
            // DatumDo
            // 
            this.DatumDo.Enabled = false;
            this.DatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatumDo.Location = new System.Drawing.Point(132, 102);
            this.DatumDo.Margin = new System.Windows.Forms.Padding(4);
            this.DatumDo.Name = "DatumDo";
            this.DatumDo.Size = new System.Drawing.Size(201, 26);
            this.DatumDo.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Datum Do:";
            // 
            // datumOd
            // 
            this.datumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumOd.Location = new System.Drawing.Point(132, 49);
            this.datumOd.Margin = new System.Windows.Forms.Padding(4);
            this.datumOd.Name = "datumOd";
            this.datumOd.Size = new System.Drawing.Size(201, 26);
            this.datumOd.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Datum Od:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SandyBrown;
            this.button1.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(189, 202);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "IZMENI";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IzmeniRadniOdnosForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(392, 293);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 340);
            this.Name = "IzmeniRadniOdnosForma";
            this.Text = "IZMENA RADNOG ODNOSA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbDatumDo;
        private System.Windows.Forms.DateTimePicker DatumDo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datumOd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}