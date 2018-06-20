using C_Means_Algorithm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace C_Means_Algorithm
{
    public partial class Form1 : Form
    {
        private DataTable tablo;
        public K_Point[] nokta;
        public K_Point[] merkez;
        public F_Point[] fnokta;

        public int[] eleman_sayisi;
        public double[] f_eleman;

        //True  : K - means
        //False : C - means
        private bool select_algorithm;

        private Iterasyon iterasyon;
        public Form1() => InitializeComponent();

        private void BtnCalculator_Click(object sender, EventArgs e)
        {
            VerileriGoster();

            if (select_algorithm == true)
                K_Means_Algorithm();

            if (select_algorithm == false)
                C_Means_Algorithm();
            
        }

        /// <summary>
        /// K - Means Algoritması çalıştırılıyor.
        /// </summary>
        private void K_Means_Algorithm()
        {
            int kumeSayisi = Convert.ToInt32(txtKumeSayisi.Text);
            int count = this.tablo.Rows.Count;
            merkez = new K_Point[kumeSayisi];
            bool state = true;
            int sayi = 1;
            chartKume.Series.Clear();
            richIterasyon.Text = "";
            Random random = new Random();
            for (int i = 0; i < kumeSayisi; ++i)
            {
                merkez[i].X = Convert.ToDouble(tablo.Rows[random.Next(0,tablo.Rows.Count)][0]);
                merkez[i].Y = Convert.ToDouble(tablo.Rows[random.Next(0,tablo.Rows.Count)][1]);
                merkez[i].Set = i;
            }
            iterasyon = new Iterasyon(this,nokta,merkez);
            while (state)
            {
                if (!iterasyon.K_means_Iterasyon_Yap(count, kumeSayisi))
                    state = false;

                double num2 = iterasyon.Merkez_Hesapla(count, kumeSayisi, eleman_sayisi);
                RichTextBox richText = richIterasyon;
                richText.Text = richText.Text + sayi.ToString() + ". iterasyon F: " + num2.ToString() + "\n";
                ++sayi;
            }
            chartKume.Series.Clear();
            chartKume.Series.Add("Merkezler");
            chartKume.Series["Merkezler"].ChartType = SeriesChartType.Point;
            chartKume.Series["Merkezler"].MarkerSize = 12;
            for (int i = 0; i < kumeSayisi; ++i)
            {
                if (eleman_sayisi[i] > 0)
                {
                    string name = "Kume " + i.ToString() + " (" + this.eleman_sayisi[i].ToString() + ")";
                    chartKume.Series.Add(new Series(name));
                    chartKume.Series[name].ChartType = SeriesChartType.Point;
                    chartKume.Series["Merkezler"].Points.AddXY(merkez[i].X, merkez[i].Y);
                }
            }
            for (int i = 0; i < count; ++i)
                chartKume.Series["Kume " + nokta[i].Set.ToString() + " (" + eleman_sayisi[nokta[i].Set].ToString() + ")"].Points.AddXY(nokta[i].X, nokta[i].Y);
            chartKume.Update();
        }

        /// <summary>
        ///Hangi Algoritmanın çalışmasını istediğinizi bu kısımdan seçebilirsiniz.
        ///Seçilen Algoritmaya göre veri girişi alanlaı açılacaktır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAlgorithm.SelectedIndex == 0)
            {
                txtKatSayisi.Visible = false;  //Katsayısı sayisi giriş alanını görünmez yaptım
                lblKatSayi.Text = "";
                select_algorithm = true;
            }
            if (comboAlgorithm.SelectedIndex == 1)
            {
                select_algorithm = false;
                txtKatSayisi.Visible = true;  //Katsayısı sayisi giriş alanını görünür yaptım
                lblKatSayi.Text = "Katsayıyı Giriniz ";
            }
            txtKumeSayisi.Visible = true;  //Kume sayisi giriş alanını görünür yaptım
            btnCalculator.Enabled = true;  //Hesaplama butonu aktif hale getirildi.
            lblKume.Text = "Küme Sayısını Giriniz";
        }
        
        /// <summary>
        /// Verileri Chart ve DataGridView de göstermek için kullanılıyor.
        /// </summary>
        private void VerileriGoster()
        {
            OleDbConnection connection = Baglanti.Baglan;
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + this.lstVeriSetleri.SelectedItem.ToString() + "]", connection);
            tablo = new DataTable();
            adapter.Fill(tablo);
            dataKoordinat.DataSource = tablo;

            nokta = new K_Point[tablo.Rows.Count];
            fnokta = new F_Point[tablo.Rows.Count];
            chartKume.Series.Clear();
            chartKume.Series.Add("Veriler");
            chartKume.Series[0].ChartType = SeriesChartType.Point;
            for (int index = 0; index < this.tablo.Rows.Count; ++index)
            {
               nokta[index].X = fnokta[index].X = Convert.ToDouble(tablo.Rows[index][0]);
               nokta[index].Y = fnokta[index].Y = Convert.ToDouble(tablo.Rows[index][1]);
               chartKume.Series[0].Points.AddXY(this.tablo.Rows[index][0], new object[1]{tablo.Rows[index][1]});
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriListesiOlustur();
            VerileriGoster();
        }

        /// <summary>
        /// Listbox nesnesine verilerin tablo adlarını dolduruyor.
        /// </summary>
        private void VeriListesiOlustur()
        {
            OleDbConnection connection = Baglanti.Baglan;
            connection.Open();
            DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            List<string> lstVeri = new List<string>();
            int i = 0;
            foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
            {
                lstVeri.Add(row["TABLE_NAME"].ToString());
                lstVeriSetleri.Items.Add(lstVeri[i]);
                ++i;
            }
            connection.Close();
            lstVeriSetleri.SelectedIndex = 0;
        }

        /// <summary>
        /// ListBox'ta seçili olan veri kümesinin adına göre verileri ekrana basıyor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVeriSetleri_DoubleClick(object sender, EventArgs e) => VerileriGoster();
        private void C_Means_Algorithm()
        {
            try
            {
                int kumeSayisi = Convert.ToInt16(txtKumeSayisi.Text);
                int count = tablo.Rows.Count;
                double m = Convert.ToDouble(txtKatSayisi.Text);
                merkez = new K_Point[kumeSayisi];
                int num1 = 1;
                this.chartKume.Series.Clear();
                this.richIterasyon.Text = "";
                Random random = new Random();
                for (int i = 0; i < kumeSayisi; ++i)
                {
                    merkez[i].X = Convert.ToDouble(tablo.Rows[random.Next(0, this.tablo.Rows.Count)][0]);
                    merkez[i].Y = Convert.ToDouble(tablo.Rows[random.Next(0, this.tablo.Rows.Count)][1]);
                    merkez[i].Set = i;
                }
                for (int i = 0; i < count; ++i)
                {
                    this.fnokta[i].Set = new double[kumeSayisi];
                    double num2 = double.MaxValue;
                    int yeri = 0;
                    for (int j = 0; j < kumeSayisi; ++j)
                    {
                        double num3 = Uzaklik.Mesafe(this.merkez[j], this.fnokta[i]);
                        if (num2 > num3)
                        {
                            yeri = j;
                            num2 = num3;
                        }
                    }
                    this.fnokta[i].Set[yeri] = 1.0;
                }
                double num4 = 1.0;
                while (num4 > 0.01)
                {
                    num4 = Fuzzy_K_Means_Iterasyon(count, kumeSayisi, m);
                    double num2 = FuzzyMerkezHesapla(count, kumeSayisi, m);
                    RichTextBox richTextBox1 = richIterasyon;
                    richTextBox1.Text = richTextBox1.Text + num1.ToString() + ". iterasyon J: " + num2.ToString() + "\n";
                    ++num1;
                }
                chartKume.Series.Clear();
                chartKume.Series.Add("Merkezler");
                chartKume.Series["Merkezler"].ChartType = SeriesChartType.Point;
                chartKume.Series["Merkezler"].MarkerSize = 12;
                for (int index = 0; index < kumeSayisi; ++index)
                {
                    if (f_eleman[index] > 0.0)
                    {
                        string name = "Kume " + index.ToString();
                        chartKume.Series.Add(new Series(name));
                        chartKume.Series[name].ChartType = SeriesChartType.Point;
                        chartKume.Series["Merkezler"].Points.AddXY(this.merkez[index].X, this.merkez[index].Y);
                    }
                }
                for (int index = 0; index < kumeSayisi; ++index)
                {
                    if (!this.tablo.Columns.Contains(index.ToString()))
                        this.tablo.Columns.Add(index.ToString());
                }
                for (int index1 = 0; index1 < count; ++index1)
                {
                    for (int index2 = 0; index2 < kumeSayisi; ++index2)
                        this.tablo.Rows[index1][index2.ToString()] = fnokta[index1].Set[index2];
                    this.chartKume.Series["Kume " + Uzaklik.Gorsellestirme(fnokta[index1]).ToString()].Points.AddXY(this.fnokta[index1].X, this.fnokta[index1].Y);
                }
                this.chartKume.Update();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
            }
        }

        public double FuzzyMerkezHesapla(int verisayisi, int kumesayisi, double m)
        {
            f_eleman = new double[kumesayisi];
            for (int i = 0; i < kumesayisi; ++i)
                merkez[i].X = merkez[i].Y= 0.0;

            for (int i = 0; i < verisayisi; ++i)
            {
                for (int j = 0; j < kumesayisi; ++j)
                {
                    f_eleman[j] += Math.Pow (fnokta[i].Set[j], m);
                    merkez [j].X += Math.Pow(fnokta[i].Set[j], m) *fnokta[i].X;
                    merkez [j].Y += Math.Pow(fnokta[i].Set[j], m) *fnokta[i].Y;
                }
            }
            for (int i = 0; i < kumesayisi; ++i)
            {
                if (f_eleman[i] > 0.0)
                {
                   merkez[i].X /= this.f_eleman[i];
                   merkez[i].Y /= this.f_eleman[i];
                }
            }
            double toplam = 0.0;
            for (int i = 0; i < verisayisi; ++i)
            {
                for (int j = 0; j < kumesayisi; ++j)
                    toplam += Math.Pow(fnokta[i].Set[j], m) * Math.Pow(Uzaklik.Mesafe(merkez[j], fnokta[i]), 2.0);
            }
            return toplam;
        }

        public double Fuzzy_K_Means_Iterasyon(int verisayisi, int kumesayisi, double m)
        {
            double num1 = 0.0;
            double[] numArray = new double[kumesayisi];
            for (int index1 = 0; index1 < verisayisi; ++index1)
            {
                Array.Copy((Array)this.fnokta[index1].Set, (Array)numArray, kumesayisi);
                for (int index2 = 0; index2 < kumesayisi; ++index2)
                {
                    this.fnokta[index1].Set[index2] = 0.0;
                    for (int index3 = 0; index3 < kumesayisi; ++index3)
                    {
                        if (Uzaklik.Mesafe(this.merkez[index3], this.fnokta[index1]) > 0.0)
                        {
                            double num2 = Uzaklik.Mesafe(this.merkez[index3], this.fnokta[index1]);
                            this.fnokta[index1].Set[index2] += Math.Pow(Uzaklik.Mesafe(merkez[index2], this.fnokta[index1]) / num2, 2.0 / (m - 1.0));
                        }
                        else
                        {
                            this.fnokta[index1].Set[index2] = 0.0;
                            break;
                        }
                    }
                    if (fnokta[index1].Set[index2] > 0.0)
                        fnokta[index1].Set[index2] = 1.0 / this.fnokta[index1].Set[index2];
                    if (Math.Abs(this.fnokta[index1].Set[index2] - numArray[index2]) > num1)
                        num1 = Math.Abs(this.fnokta[index1].Set[index2] - numArray[index2]);
                }
            }
            return num1;
        }
    }
}
