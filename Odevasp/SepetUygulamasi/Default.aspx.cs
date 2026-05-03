using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace SepetUygulamasi
{
    public partial class Default : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["SepetDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SepetleriYukle();
                UrunleriYukle();
            }
        }

        void SepetleriYukle()
        {
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT * FROM sepetler ORDER BY id", conn))
            {
                conn.Open();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                gvSepetler.DataSource = dt;
                gvSepetler.DataBind();
            }
        }

        void UrunleriYukle()
        {
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT * FROM urunler ORDER BY id", conn))
            {
                conn.Open();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                gvUrunler.DataSource = dt;
                gvUrunler.DataBind();
            }
        }

        protected void btnSepetEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMusteriAdi.Text)) return;

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("INSERT INTO sepetler (musteri_adi, durum, olusturma_tarihi, guncelleme_tarihi) VALUES (@ad, @durum, GETDATE(), GETDATE())", conn))
            {
                cmd.Parameters.AddWithValue("@ad", txtMusteriAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@durum", ddlDurum.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            txtMusteriAdi.Text = "";
            SepetleriYukle();
        }

        protected void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text) || string.IsNullOrWhiteSpace(txtFiyat.Text)) return;

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("INSERT INTO urunler (urun_adi, fiyat, stok, olusturma_tarihi) VALUES (@ad, @fiyat, 0, GETDATE())", conn))
            {
                cmd.Parameters.AddWithValue("@ad", txtUrunAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@fiyat", decimal.Parse(txtFiyat.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            txtUrunAdi.Text = "";
            txtFiyat.Text = "";
            UrunleriYukle();
        }

        protected void gvSepetler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvSepetler.DataKeys[index].Value);
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("DELETE FROM sepetler WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                SepetleriYukle();
            }
        }

        protected void gvUrunler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvUrunler.DataKeys[index].Value);
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand("DELETE FROM urunler WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                UrunleriYukle();
            }
        }
    }
}