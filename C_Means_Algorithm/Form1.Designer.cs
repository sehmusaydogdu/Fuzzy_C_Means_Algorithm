namespace C_Means_Algorithm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboAlgorithm = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.txtKatSayisi = new System.Windows.Forms.TextBox();
            this.txtKumeSayisi = new System.Windows.Forms.TextBox();
            this.lstVeriSetleri = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartKume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richIterasyon = new System.Windows.Forms.RichTextBox();
            this.dataKoordinat = new System.Windows.Forms.DataGridView();
            this.lblKume = new System.Windows.Forms.Label();
            this.lblKatSayi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKume)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataKoordinat)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAlgorithm
            // 
            this.comboAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgorithm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboAlgorithm.FormattingEnabled = true;
            this.comboAlgorithm.Items.AddRange(new object[] {
            "K Means Algorithm",
            "C Means Algorithm"});
            this.comboAlgorithm.Location = new System.Drawing.Point(6, 31);
            this.comboAlgorithm.Name = "comboAlgorithm";
            this.comboAlgorithm.Size = new System.Drawing.Size(175, 26);
            this.comboAlgorithm.TabIndex = 1;
            this.comboAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboAlgorithm_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblKatSayi);
            this.groupBox1.Controls.Add(this.lblKume);
            this.groupBox1.Controls.Add(this.btnCalculator);
            this.groupBox1.Controls.Add(this.txtKatSayisi);
            this.groupBox1.Controls.Add(this.txtKumeSayisi);
            this.groupBox1.Controls.Add(this.comboAlgorithm);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithms";
            // 
            // btnCalculator
            // 
            this.btnCalculator.Enabled = false;
            this.btnCalculator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCalculator.Location = new System.Drawing.Point(6, 69);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(175, 37);
            this.btnCalculator.TabIndex = 4;
            this.btnCalculator.Text = "Calculator";
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.BtnCalculator_Click);
            // 
            // txtKatSayisi
            // 
            this.txtKatSayisi.Location = new System.Drawing.Point(207, 77);
            this.txtKatSayisi.Name = "txtKatSayisi";
            this.txtKatSayisi.Size = new System.Drawing.Size(144, 24);
            this.txtKatSayisi.TabIndex = 3;
            this.txtKatSayisi.Visible = false;
            // 
            // txtKumeSayisi
            // 
            this.txtKumeSayisi.Location = new System.Drawing.Point(207, 34);
            this.txtKumeSayisi.Name = "txtKumeSayisi";
            this.txtKumeSayisi.Size = new System.Drawing.Size(144, 24);
            this.txtKumeSayisi.TabIndex = 2;
            this.txtKumeSayisi.Visible = false;
            // 
            // lstVeriSetleri
            // 
            this.lstVeriSetleri.FormattingEnabled = true;
            this.lstVeriSetleri.ItemHeight = 16;
            this.lstVeriSetleri.Location = new System.Drawing.Point(17, 34);
            this.lstVeriSetleri.Name = "lstVeriSetleri";
            this.lstVeriSetleri.Size = new System.Drawing.Size(143, 308);
            this.lstVeriSetleri.TabIndex = 7;
            this.lstVeriSetleri.DoubleClick += new System.EventHandler(this.lstVeriSetleri_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstVeriSetleri);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(677, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 354);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Veri Setleri";
            // 
            // chartKume
            // 
            chartArea4.Name = "ChartArea1";
            this.chartKume.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartKume.Legends.Add(legend4);
            this.chartKume.Location = new System.Drawing.Point(12, 149);
            this.chartKume.Name = "chartKume";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartKume.Series.Add(series4);
            this.chartKume.Size = new System.Drawing.Size(637, 525);
            this.chartKume.TabIndex = 9;
            this.chartKume.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richIterasyon);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(865, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 345);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İterasyon Sonuçları";
            // 
            // richIterasyon
            // 
            this.richIterasyon.Location = new System.Drawing.Point(16, 34);
            this.richIterasyon.Name = "richIterasyon";
            this.richIterasyon.Size = new System.Drawing.Size(274, 291);
            this.richIterasyon.TabIndex = 9;
            this.richIterasyon.Text = "";
            // 
            // dataKoordinat
            // 
            this.dataKoordinat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataKoordinat.Location = new System.Drawing.Point(677, 386);
            this.dataKoordinat.Name = "dataKoordinat";
            this.dataKoordinat.Size = new System.Drawing.Size(493, 288);
            this.dataKoordinat.TabIndex = 11;
            // 
            // lblKume
            // 
            this.lblKume.AutoSize = true;
            this.lblKume.Location = new System.Drawing.Point(361, 37);
            this.lblKume.Name = "lblKume";
            this.lblKume.Size = new System.Drawing.Size(0, 18);
            this.lblKume.TabIndex = 5;
            // 
            // lblKatSayi
            // 
            this.lblKatSayi.AutoSize = true;
            this.lblKatSayi.Location = new System.Drawing.Point(361, 80);
            this.lblKatSayi.Name = "lblKatSayi";
            this.lblKatSayi.Size = new System.Drawing.Size(0, 18);
            this.lblKatSayi.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 686);
            this.Controls.Add(this.dataKoordinat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chartKume);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Fuzzy C means";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartKume)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataKoordinat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboAlgorithm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.TextBox txtKatSayisi;
        private System.Windows.Forms.TextBox txtKumeSayisi;
        private System.Windows.Forms.ListBox lstVeriSetleri;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKume;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richIterasyon;
        private System.Windows.Forms.DataGridView dataKoordinat;
        private System.Windows.Forms.Label lblKatSayi;
        private System.Windows.Forms.Label lblKume;
    }
}

