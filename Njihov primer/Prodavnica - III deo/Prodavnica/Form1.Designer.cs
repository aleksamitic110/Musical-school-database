namespace Prodavnica
{
    partial class Form1
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
            this.cmdRead = new System.Windows.Forms.Button();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.cmdManytoOne = new System.Windows.Forms.Button();
            this.cmdOneToMany = new System.Windows.Forms.Button();
            this.cmdCreateOdeljenje = new System.Windows.Forms.Button();
            this.cmdManyToMany = new System.Windows.Forms.Button();
            this.cmdCreateRadnik = new System.Windows.Forms.Button();
            this.cmdCreateRadiU = new System.Windows.Forms.Button();
            this.cmdTPC = new System.Windows.Forms.Button();
            this.cmdCreateVojnik = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdCreateSubclassOdeljenje = new System.Windows.Forms.Button();
            this.cmdGet = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.cmdQuery1 = new System.Windows.Forms.Button();
            this.cmdQueryParameters = new System.Windows.Forms.Button();
            this.cmdQueryNamedParamters = new System.Windows.Forms.Button();
            this.cmdQueryNamedParameters1 = new System.Windows.Forms.Button();
            this.smdEnumerable = new System.Windows.Forms.Button();
            this.cmdScalar = new System.Windows.Forms.Button();
            this.cmdUnique = new System.Windows.Forms.Button();
            this.cmdMultiple = new System.Windows.Forms.Button();
            this.cmdPaging = new System.Windows.Forms.Button();
            this.cmdCriteria = new System.Windows.Forms.Button();
            this.cmdSQL = new System.Windows.Forms.Button();
            this.cmdQueryOver = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdTransaction = new System.Windows.Forms.Button();
            this.cmdLINQ = new System.Windows.Forms.Button();
            this.cmdLINQ1 = new System.Windows.Forms.Button();
            this.cmdLINQ2 = new System.Windows.Forms.Button();
            this.button_dtoexample1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdRead
            // 
            this.cmdRead.Location = new System.Drawing.Point(13, 13);
            this.cmdRead.Name = "cmdRead";
            this.cmdRead.Size = new System.Drawing.Size(271, 23);
            this.cmdRead.TabIndex = 0;
            this.cmdRead.Text = "Ucitavanje podataka o prodavnici";
            this.cmdRead.UseVisualStyleBackColor = true;
            this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(13, 43);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(271, 23);
            this.cmdCreate.TabIndex = 1;
            this.cmdCreate.Text = "Dodavanje nove prodavnice";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // cmdManytoOne
            // 
            this.cmdManytoOne.Location = new System.Drawing.Point(13, 73);
            this.cmdManytoOne.Name = "cmdManytoOne";
            this.cmdManytoOne.Size = new System.Drawing.Size(271, 23);
            this.cmdManytoOne.TabIndex = 2;
            this.cmdManytoOne.Text = "Veza Many-to-One";
            this.cmdManytoOne.UseVisualStyleBackColor = true;
            this.cmdManytoOne.Click += new System.EventHandler(this.cmdManytoOne_Click);
            // 
            // cmdOneToMany
            // 
            this.cmdOneToMany.Location = new System.Drawing.Point(13, 103);
            this.cmdOneToMany.Name = "cmdOneToMany";
            this.cmdOneToMany.Size = new System.Drawing.Size(271, 23);
            this.cmdOneToMany.TabIndex = 3;
            this.cmdOneToMany.Text = "Veza One-to-Many";
            this.cmdOneToMany.UseVisualStyleBackColor = true;
            this.cmdOneToMany.Click += new System.EventHandler(this.cmdOneToMany_Click);
            // 
            // cmdCreateOdeljenje
            // 
            this.cmdCreateOdeljenje.Location = new System.Drawing.Point(13, 133);
            this.cmdCreateOdeljenje.Name = "cmdCreateOdeljenje";
            this.cmdCreateOdeljenje.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateOdeljenje.TabIndex = 4;
            this.cmdCreateOdeljenje.Text = "Kreiranje odeljenja";
            this.cmdCreateOdeljenje.UseVisualStyleBackColor = true;
            this.cmdCreateOdeljenje.Click += new System.EventHandler(this.cmdCreateOdeljenje_Click);
            // 
            // cmdManyToMany
            // 
            this.cmdManyToMany.Location = new System.Drawing.Point(13, 163);
            this.cmdManyToMany.Name = "cmdManyToMany";
            this.cmdManyToMany.Size = new System.Drawing.Size(271, 23);
            this.cmdManyToMany.TabIndex = 5;
            this.cmdManyToMany.Text = "HasManytoMany";
            this.cmdManyToMany.UseVisualStyleBackColor = true;
            this.cmdManyToMany.Click += new System.EventHandler(this.cmdManyToMany_Click);
            // 
            // cmdCreateRadnik
            // 
            this.cmdCreateRadnik.Location = new System.Drawing.Point(13, 193);
            this.cmdCreateRadnik.Name = "cmdCreateRadnik";
            this.cmdCreateRadnik.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateRadnik.TabIndex = 6;
            this.cmdCreateRadnik.Text = "Kreiranje radnika";
            this.cmdCreateRadnik.UseVisualStyleBackColor = true;
            this.cmdCreateRadnik.Click += new System.EventHandler(this.cmdCreateRadnik_Click);
            // 
            // cmdCreateRadiU
            // 
            this.cmdCreateRadiU.Location = new System.Drawing.Point(13, 223);
            this.cmdCreateRadiU.Name = "cmdCreateRadiU";
            this.cmdCreateRadiU.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateRadiU.TabIndex = 7;
            this.cmdCreateRadiU.Text = "Kreiranje RadiU";
            this.cmdCreateRadiU.UseVisualStyleBackColor = true;
            this.cmdCreateRadiU.Click += new System.EventHandler(this.cmdCreateRadiU_Click);
            // 
            // cmdTPC
            // 
            this.cmdTPC.Location = new System.Drawing.Point(13, 252);
            this.cmdTPC.Name = "cmdTPC";
            this.cmdTPC.Size = new System.Drawing.Size(271, 23);
            this.cmdTPC.TabIndex = 8;
            this.cmdTPC.Text = "Table-per-Class inheritance";
            this.cmdTPC.UseVisualStyleBackColor = true;
            this.cmdTPC.Click += new System.EventHandler(this.cmdTPC_Click);
            // 
            // cmdCreateVojnik
            // 
            this.cmdCreateVojnik.Location = new System.Drawing.Point(13, 281);
            this.cmdCreateVojnik.Name = "cmdCreateVojnik";
            this.cmdCreateVojnik.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateVojnik.TabIndex = 9;
            this.cmdCreateVojnik.Text = "Kreiranje vojnika";
            this.cmdCreateVojnik.UseVisualStyleBackColor = true;
            this.cmdCreateVojnik.Click += new System.EventHandler(this.cmdCreateVojnik_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Table-per-Class-Hierarchy inheritance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdCreateSubclassOdeljenje
            // 
            this.cmdCreateSubclassOdeljenje.Location = new System.Drawing.Point(13, 341);
            this.cmdCreateSubclassOdeljenje.Name = "cmdCreateSubclassOdeljenje";
            this.cmdCreateSubclassOdeljenje.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateSubclassOdeljenje.TabIndex = 11;
            this.cmdCreateSubclassOdeljenje.Text = "Kreiranje podklase Odeljenja";
            this.cmdCreateSubclassOdeljenje.UseVisualStyleBackColor = true;
            this.cmdCreateSubclassOdeljenje.Click += new System.EventHandler(this.cmdCreateSubclassOdeljenje_Click);
            // 
            // cmdGet
            // 
            this.cmdGet.Location = new System.Drawing.Point(308, 13);
            this.cmdGet.Name = "cmdGet";
            this.cmdGet.Size = new System.Drawing.Size(271, 23);
            this.cmdGet.TabIndex = 12;
            this.cmdGet.Text = "Koriscenje metode Get";
            this.cmdGet.UseVisualStyleBackColor = true;
            this.cmdGet.Click += new System.EventHandler(this.cmdGet_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(308, 43);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(271, 23);
            this.cmdRefresh.TabIndex = 13;
            this.cmdRefresh.Text = "Koriscenje metode Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdQuery
            // 
            this.cmdQuery.Location = new System.Drawing.Point(308, 72);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(271, 23);
            this.cmdQuery.TabIndex = 14;
            this.cmdQuery.Text = "Krieranje upita";
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdFind1_Click);
            // 
            // cmdQuery1
            // 
            this.cmdQuery1.Location = new System.Drawing.Point(308, 101);
            this.cmdQuery1.Name = "cmdQuery1";
            this.cmdQuery1.Size = new System.Drawing.Size(271, 23);
            this.cmdQuery1.TabIndex = 15;
            this.cmdQuery1.Text = "Krieranje upita 1";
            this.cmdQuery1.UseVisualStyleBackColor = true;
            this.cmdQuery1.Click += new System.EventHandler(this.cmdQuery1_Click);
            // 
            // cmdQueryParameters
            // 
            this.cmdQueryParameters.Location = new System.Drawing.Point(308, 130);
            this.cmdQueryParameters.Name = "cmdQueryParameters";
            this.cmdQueryParameters.Size = new System.Drawing.Size(271, 23);
            this.cmdQueryParameters.TabIndex = 16;
            this.cmdQueryParameters.Text = "Krieranje upita sa parametrima";
            this.cmdQueryParameters.UseVisualStyleBackColor = true;
            this.cmdQueryParameters.Click += new System.EventHandler(this.cmdQueryParameters_Click);
            // 
            // cmdQueryNamedParamters
            // 
            this.cmdQueryNamedParamters.Location = new System.Drawing.Point(308, 163);
            this.cmdQueryNamedParamters.Name = "cmdQueryNamedParamters";
            this.cmdQueryNamedParamters.Size = new System.Drawing.Size(271, 23);
            this.cmdQueryNamedParamters.TabIndex = 17;
            this.cmdQueryNamedParamters.Text = "Krieranje upita sa imenovanim parametrima";
            this.cmdQueryNamedParamters.UseVisualStyleBackColor = true;
            this.cmdQueryNamedParamters.Click += new System.EventHandler(this.cmdQueryNamedParamters_Click);
            // 
            // cmdQueryNamedParameters1
            // 
            this.cmdQueryNamedParameters1.Location = new System.Drawing.Point(308, 193);
            this.cmdQueryNamedParameters1.Name = "cmdQueryNamedParameters1";
            this.cmdQueryNamedParameters1.Size = new System.Drawing.Size(271, 23);
            this.cmdQueryNamedParameters1.TabIndex = 18;
            this.cmdQueryNamedParameters1.Text = "Krieranje upita sa imenovanim parametrima 1";
            this.cmdQueryNamedParameters1.UseVisualStyleBackColor = true;
            this.cmdQueryNamedParameters1.Click += new System.EventHandler(this.cmdQueryNamedParameters1_Click);
            // 
            // smdEnumerable
            // 
            this.smdEnumerable.Location = new System.Drawing.Point(308, 223);
            this.smdEnumerable.Name = "smdEnumerable";
            this.smdEnumerable.Size = new System.Drawing.Size(271, 23);
            this.smdEnumerable.TabIndex = 19;
            this.smdEnumerable.Text = "Koriscenje Enumerable";
            this.smdEnumerable.UseVisualStyleBackColor = true;
            this.smdEnumerable.Click += new System.EventHandler(this.smdEnumerable_Click);
            // 
            // cmdScalar
            // 
            this.cmdScalar.Location = new System.Drawing.Point(308, 252);
            this.cmdScalar.Name = "cmdScalar";
            this.cmdScalar.Size = new System.Drawing.Size(271, 23);
            this.cmdScalar.TabIndex = 20;
            this.cmdScalar.Text = "Skalarni rezultati";
            this.cmdScalar.UseVisualStyleBackColor = true;
            this.cmdScalar.Click += new System.EventHandler(this.cmdScalar_Click);
            // 
            // cmdUnique
            // 
            this.cmdUnique.Location = new System.Drawing.Point(308, 281);
            this.cmdUnique.Name = "cmdUnique";
            this.cmdUnique.Size = new System.Drawing.Size(271, 23);
            this.cmdUnique.TabIndex = 22;
            this.cmdUnique.Text = "Unique rezultat";
            this.cmdUnique.UseVisualStyleBackColor = true;
            this.cmdUnique.Click += new System.EventHandler(this.cmdUnique_Click);
            // 
            // cmdMultiple
            // 
            this.cmdMultiple.Location = new System.Drawing.Point(308, 311);
            this.cmdMultiple.Name = "cmdMultiple";
            this.cmdMultiple.Size = new System.Drawing.Size(271, 23);
            this.cmdMultiple.TabIndex = 23;
            this.cmdMultiple.Text = "Visestruki rezultati";
            this.cmdMultiple.UseVisualStyleBackColor = true;
            this.cmdMultiple.Click += new System.EventHandler(this.cmdMultiple_Click);
            // 
            // cmdPaging
            // 
            this.cmdPaging.Location = new System.Drawing.Point(308, 341);
            this.cmdPaging.Name = "cmdPaging";
            this.cmdPaging.Size = new System.Drawing.Size(271, 23);
            this.cmdPaging.TabIndex = 24;
            this.cmdPaging.Text = "Stranicenje";
            this.cmdPaging.UseVisualStyleBackColor = true;
            this.cmdPaging.Click += new System.EventHandler(this.cmdPaging_Click);
            // 
            // cmdCriteria
            // 
            this.cmdCriteria.Location = new System.Drawing.Point(600, 12);
            this.cmdCriteria.Name = "cmdCriteria";
            this.cmdCriteria.Size = new System.Drawing.Size(271, 23);
            this.cmdCriteria.TabIndex = 25;
            this.cmdCriteria.Text = "Kreiranej Criteria";
            this.cmdCriteria.UseVisualStyleBackColor = true;
            this.cmdCriteria.Click += new System.EventHandler(this.cmdCriteria_Click);
            // 
            // cmdSQL
            // 
            this.cmdSQL.Location = new System.Drawing.Point(600, 72);
            this.cmdSQL.Name = "cmdSQL";
            this.cmdSQL.Size = new System.Drawing.Size(271, 23);
            this.cmdSQL.TabIndex = 26;
            this.cmdSQL.Text = "Native SQL";
            this.cmdSQL.UseVisualStyleBackColor = true;
            this.cmdSQL.Click += new System.EventHandler(this.cmdSQL_Click);
            // 
            // cmdQueryOver
            // 
            this.cmdQueryOver.Location = new System.Drawing.Point(600, 41);
            this.cmdQueryOver.Name = "cmdQueryOver";
            this.cmdQueryOver.Size = new System.Drawing.Size(271, 23);
            this.cmdQueryOver.TabIndex = 27;
            this.cmdQueryOver.Text = "Kreiranje QueryOver";
            this.cmdQueryOver.UseVisualStyleBackColor = true;
            this.cmdQueryOver.Click += new System.EventHandler(this.cmdQueryOver_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(600, 101);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(271, 23);
            this.cmdUpdate.TabIndex = 28;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(600, 133);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(271, 23);
            this.cmdDelete.TabIndex = 29;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdTransaction
            // 
            this.cmdTransaction.Location = new System.Drawing.Point(600, 162);
            this.cmdTransaction.Name = "cmdTransaction";
            this.cmdTransaction.Size = new System.Drawing.Size(271, 23);
            this.cmdTransaction.TabIndex = 30;
            this.cmdTransaction.Text = "Transakcija";
            this.cmdTransaction.UseVisualStyleBackColor = true;
            this.cmdTransaction.Click += new System.EventHandler(this.cmdTransaction_Click);
            // 
            // cmdLINQ
            // 
            this.cmdLINQ.Location = new System.Drawing.Point(600, 192);
            this.cmdLINQ.Name = "cmdLINQ";
            this.cmdLINQ.Size = new System.Drawing.Size(271, 23);
            this.cmdLINQ.TabIndex = 31;
            this.cmdLINQ.Text = "LINQ";
            this.cmdLINQ.UseVisualStyleBackColor = true;
            this.cmdLINQ.Click += new System.EventHandler(this.cmdLINQ_Click);
            // 
            // cmdLINQ1
            // 
            this.cmdLINQ1.Location = new System.Drawing.Point(600, 223);
            this.cmdLINQ1.Name = "cmdLINQ1";
            this.cmdLINQ1.Size = new System.Drawing.Size(271, 23);
            this.cmdLINQ1.TabIndex = 32;
            this.cmdLINQ1.Text = "LINQ 1";
            this.cmdLINQ1.UseVisualStyleBackColor = true;
            this.cmdLINQ1.Click += new System.EventHandler(this.cmdLINQ1_Click);
            // 
            // cmdLINQ2
            // 
            this.cmdLINQ2.Location = new System.Drawing.Point(600, 252);
            this.cmdLINQ2.Name = "cmdLINQ2";
            this.cmdLINQ2.Size = new System.Drawing.Size(271, 23);
            this.cmdLINQ2.TabIndex = 33;
            this.cmdLINQ2.Text = "LINQ 2";
            this.cmdLINQ2.UseVisualStyleBackColor = true;
            this.cmdLINQ2.Click += new System.EventHandler(this.cmdLINQ2_Click);
            // 
            // button_dtoexample1
            // 
            this.button_dtoexample1.Location = new System.Drawing.Point(600, 281);
            this.button_dtoexample1.Name = "button_dtoexample1";
            this.button_dtoexample1.Size = new System.Drawing.Size(271, 23);
            this.button_dtoexample1.TabIndex = 34;
            this.button_dtoexample1.Text = "Pregled odeljenja";
            this.button_dtoexample1.UseVisualStyleBackColor = true;
            this.button_dtoexample1.Click += new System.EventHandler(this.button_dtoexample1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 393);
            this.Controls.Add(this.button_dtoexample1);
            this.Controls.Add(this.cmdLINQ2);
            this.Controls.Add(this.cmdLINQ1);
            this.Controls.Add(this.cmdLINQ);
            this.Controls.Add(this.cmdTransaction);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdQueryOver);
            this.Controls.Add(this.cmdSQL);
            this.Controls.Add(this.cmdCriteria);
            this.Controls.Add(this.cmdPaging);
            this.Controls.Add(this.cmdMultiple);
            this.Controls.Add(this.cmdUnique);
            this.Controls.Add(this.cmdScalar);
            this.Controls.Add(this.smdEnumerable);
            this.Controls.Add(this.cmdQueryNamedParameters1);
            this.Controls.Add(this.cmdQueryNamedParamters);
            this.Controls.Add(this.cmdQueryParameters);
            this.Controls.Add(this.cmdQuery1);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdGet);
            this.Controls.Add(this.cmdCreateSubclassOdeljenje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdCreateVojnik);
            this.Controls.Add(this.cmdTPC);
            this.Controls.Add(this.cmdCreateRadiU);
            this.Controls.Add(this.cmdCreateRadnik);
            this.Controls.Add(this.cmdManyToMany);
            this.Controls.Add(this.cmdCreateOdeljenje);
            this.Controls.Add(this.cmdOneToMany);
            this.Controls.Add(this.cmdManytoOne);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.cmdRead);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdRead;
        private System.Windows.Forms.Button cmdCreate;
        private System.Windows.Forms.Button cmdManytoOne;
        private System.Windows.Forms.Button cmdOneToMany;
        private System.Windows.Forms.Button cmdCreateOdeljenje;
        private System.Windows.Forms.Button cmdManyToMany;
        private System.Windows.Forms.Button cmdCreateRadnik;
        private System.Windows.Forms.Button cmdCreateRadiU;
        private System.Windows.Forms.Button cmdTPC;
        private System.Windows.Forms.Button cmdCreateVojnik;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdCreateSubclassOdeljenje;
        private System.Windows.Forms.Button cmdGet;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.Button cmdQuery1;
        private System.Windows.Forms.Button cmdQueryParameters;
        private System.Windows.Forms.Button cmdQueryNamedParamters;
        private System.Windows.Forms.Button cmdQueryNamedParameters1;
        private System.Windows.Forms.Button smdEnumerable;
        private System.Windows.Forms.Button cmdScalar;
        private System.Windows.Forms.Button cmdUnique;
        private System.Windows.Forms.Button cmdMultiple;
        private System.Windows.Forms.Button cmdPaging;
        private System.Windows.Forms.Button cmdCriteria;
        private System.Windows.Forms.Button cmdSQL;
        private System.Windows.Forms.Button cmdQueryOver;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdTransaction;
        private System.Windows.Forms.Button cmdLINQ;
        private System.Windows.Forms.Button cmdLINQ1;
        private System.Windows.Forms.Button cmdLINQ2;
        private System.Windows.Forms.Button button_dtoexample1;
    }
}

