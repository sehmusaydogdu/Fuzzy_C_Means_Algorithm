using System;

namespace C_Means_Algorithm.Models
{
    public class Iterasyon
    {
        private K_Point[] nokta;
        private K_Point[] merkez;
        private Form1 form;
        public Iterasyon(Form1 _form,K_Point[] _nokta, K_Point[] _merkez)
        {
            form = _form;
            nokta = _nokta;
            merkez = _merkez;
        }
        public bool K_means_Iterasyon_Yap(int verisayisi, int kumesayisi)
        {
            bool durum = false;
            for (int i = 0; i < verisayisi; ++i)
            {
                double num1 = Uzaklik.Mesafe(nokta[i], merkez[0]);
                double kume = nokta[i].Set;
                nokta[i].Set = 0;
                for (int index2 = 1; index2 < kumesayisi; ++index2)
                {
                    double num2 = Uzaklik.Mesafe(this.nokta[i], this.merkez[index2]);
                    if (num2 < num1)
                    {
                        num1 = num2;
                        nokta[i].Set = index2;
                    }
                }
                if (kume != nokta[i].Set)
                {
                    durum = true;
                }
            }
            return durum;
        }

        public double Merkez_Hesapla(int verisayisi, int kumesayisi,int[] elemanSayisi)
        {
            elemanSayisi = new int[kumesayisi];
            for (int i = 0; i < kumesayisi; ++i)
                merkez[i].X = this.merkez[i].Y = 0.0;

            for (int i = 0; i < verisayisi; ++i)
            {
                ++elemanSayisi[nokta[i].Set];
                merkez[nokta[i].Set].X  += nokta[i].X;
                merkez[nokta[i].Set].Y  += nokta[i].Y;
            }
            for (int i = 0; i < kumesayisi; ++i)
            {
                if (elemanSayisi[i] > 0)
                {
                    merkez[i].X /= elemanSayisi[i];
                    merkez[i].Y /= elemanSayisi[i];
                }
            }
            double toplam = 0.0;
            for (int i = 0; i < verisayisi; ++i)
                toplam += Math.Pow(Uzaklik.Mesafe(this.merkez[nokta[i].Set],nokta[i]), 2.0);

            form.eleman_sayisi = elemanSayisi;
            return toplam;
        }
    }
}
