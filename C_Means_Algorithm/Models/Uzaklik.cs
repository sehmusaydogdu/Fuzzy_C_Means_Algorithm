using System;

namespace C_Means_Algorithm.Models
{
    public class Uzaklik
    {
        public static double Mesafe(K_Point nokta1, K_Point nokta2) => Math.Sqrt(Math.Pow(nokta1.X - nokta2.X, 2.0) + Math.Pow(nokta1.Y - nokta2.Y, 2.0));

        public static double Mesafe(K_Point k_nokta, F_Point f_nokta) => Math.Sqrt(Math.Pow(k_nokta.X - f_nokta.X, 2.0) + Math.Pow(k_nokta.Y - f_nokta.Y, 2.0));

        public static int Gorsellestirme(F_Point fuzzy)
        {
            double gecici = fuzzy.Set[0];
            int toplam = 0;
            for (int i = 1; i < fuzzy.Set.Length; ++i)
            {
                if (fuzzy.Set[i] > gecici)
                {
                    gecici = fuzzy.Set[i];
                    toplam = i;
                }
            }
            return toplam;
        }
    }
}
