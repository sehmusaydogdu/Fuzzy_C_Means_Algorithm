using System.Data.OleDb;

namespace C_Means_Algorithm.Models
{
    public class Baglanti
    {

        //Singletion Pattern
        private Baglanti() { }

        private static OleDbConnection _baglan;
        public static OleDbConnection Baglan => _baglan ??
                                           new OleDbConnection
                                           ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cluster.xls;Extended Properties=Excel 8.0;");
       


    }
}
