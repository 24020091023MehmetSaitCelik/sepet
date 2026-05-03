using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace SepetApp
{
    public class Sepet
    {
        public int Id { get; set; }
        public string MusteriAdi { get; set; }
        public string Durum { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }

    public class SepetDAO
    {
        // Tüm sepetleri getir
        public List<Sepet> TumSepetleriGetir()
        {
            List<Sepet> liste = new List<Sepet>();
            string sql = "SELECT id, musteri_adi, durum, olusturma_tarihi FROM sepetler ORDER BY id";

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    liste.Add(new Sepet
                    {
                        Id = rd.GetInt32(0),
                        MusteriAdi = rd.GetString(1),
                        Durum = rd.GetString(2),
                        OlusturmaTarihi = rd.GetDateTime(3)
                    });
                }
            }
            return liste;
        }

        // Duruma göre filtrele
        public List<Sepet> DurumFiltrele(string durum)
        {
            List<Sepet> liste = new List<Sepet>();
            string sql = "SELECT id, musteri_adi, durum, olusturma_tarihi FROM sepetler WHERE durum = @durum ORDER BY id";

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@durum", durum);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    liste.Add(new Sepet
                    {
                        Id = rd.GetInt32(0),
                        MusteriAdi = rd.GetString(1),
                        Durum = rd.GetString(2),
                        OlusturmaTarihi = rd.GetDateTime(3)
                    });
                }
            }
            return liste;
        }

        // Yeni sepet ekle
        public bool SepetEkle(string musteriAdi, string durum)
        {
            string sql = "INSERT INTO sepetler (musteri_adi, durum) VALUES (@ad, @durum)";

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ad", musteriAdi);
                cmd.Parameters.AddWithValue("@durum", durum);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
