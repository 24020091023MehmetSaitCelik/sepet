using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace SepetApp
{
    public class SepetUrun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public double BirimFiyat { get; set; }
    }

    public class SepetUrunDAO
    {
        // Seçili sepete ait ürünleri getir
        public List<SepetUrun> SepetinUrunleri(int sepetId)
        {
            List<SepetUrun> liste = new List<SepetUrun>();
            string sql = "SELECT su.id, u.urun_adi, su.adet, su.birim_fiyat " +
                         "FROM sepet_urunler su " +
                         "INNER JOIN urunler u ON su.urun_id = u.id " +
                         "WHERE su.sepet_id = @sepetId";

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sepetId", sepetId);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    liste.Add(new SepetUrun
                    {
                        Id = rd.GetInt32(0),
                        UrunAdi = rd.GetString(1),
                        Adet = rd.GetInt32(2),
                        BirimFiyat = (double)rd.GetDecimal(3)
                    });
                }
            }
            return liste;
        }

        // Sepete ürün ekle
        public bool UrunEkle(int sepetId, string urunAdi, int adet)
        {
            string sqlBul = "SELECT id, fiyat FROM urunler WHERE urun_adi = @ad";

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmdBul = new SqlCommand(sqlBul, con);
                cmdBul.Parameters.AddWithValue("@ad", urunAdi);
                SqlDataReader rd = cmdBul.ExecuteReader();

                if (rd.Read())
                {
                    int urunId = rd.GetInt32(0);
                    double fiyat = (double)rd.GetDecimal(1);
                    rd.Close();

                    string sqlEkle = "INSERT INTO sepet_urunler (sepet_id, urun_id, adet, birim_fiyat) " +
                                     "VALUES (@sepetId, @urunId, @adet, @fiyat)";
                    SqlCommand cmdEkle = new SqlCommand(sqlEkle, con);
                    cmdEkle.Parameters.AddWithValue("@sepetId", sepetId);
                    cmdEkle.Parameters.AddWithValue("@urunId", urunId);
                    cmdEkle.Parameters.AddWithValue("@adet", adet);
                    cmdEkle.Parameters.AddWithValue("@fiyat", fiyat);
                    return cmdEkle.ExecuteNonQuery() > 0;
                }
                return false;
            }
        }
    }
}
