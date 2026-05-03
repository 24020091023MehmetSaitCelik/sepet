using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace SepetApp
{
    public partial class Form1 : Form
    {
        private SepetDAO sepetDAO = new SepetDAO();
        private SepetUrunDAO sepetUrunDAO = new SepetUrunDAO();

        public Form1()
        {
            InitializeComponent();
            SetupDgvSepetler();
            SetupDgvUrunler();
            SetupSepetSecimOlayi();
            LoadSepetler();
        }

        private void SetupDgvSepetler()
        {
            dgvSepetler.Columns.Clear();
            dgvSepetler.Columns.Add("Id", "ID");
            dgvSepetler.Columns.Add("MusteriAdi", "Müşteri Adı");
            dgvSepetler.Columns.Add("Tarih", "Tarih");
            dgvSepetler.Columns.Add("Durum", "Durum");
            dgvSepetler.ReadOnly = true;
            dgvSepetler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSepetler.MultiSelect = false;
            dgvSepetler.AllowUserToAddRows = false;
        }

        private void SetupDgvUrunler()
        {
            dgvUrunler.Columns.Clear();
            dgvUrunler.Columns.Add("Id", "ID");
            dgvUrunler.Columns.Add("UrunAdi", "Ürün Adı");
            dgvUrunler.Columns.Add("Adet", "Adet");
            dgvUrunler.Columns.Add("BirimFiyat", "Birim Fiyat");
            dgvUrunler.ReadOnly = true;
            dgvUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUrunler.MultiSelect = false;
            dgvUrunler.AllowUserToAddRows = false;
        }

        private void SetupSepetSecimOlayi()
        {
            dgvSepetler.SelectionChanged += (s, e) =>
            {
                if (dgvSepetler.SelectedRows.Count == 0) return;
                int sepetId = Convert.ToInt32(dgvSepetler.SelectedRows[0].Cells["Id"].Value);
                LoadSepetUrunleri(sepetId);
            };
        }

        private void LoadSepetler()
        {
            dgvSepetler.Rows.Clear();
            string seciliDurum = cboDurum.SelectedItem?.ToString() ?? "aktif";

            foreach (var s in sepetDAO.DurumFiltrele(seciliDurum))
            {
                dgvSepetler.Rows.Add(s.Id, s.MusteriAdi, s.OlusturmaTarihi, s.Durum);
            }
            dgvUrunler.Rows.Clear();
        }

        private void LoadSepetUrunleri(int sepetId)
        {
            dgvUrunler.Rows.Clear();
            foreach (var u in sepetUrunDAO.SepetinUrunleri(sepetId))
            {
                dgvUrunler.Rows.Add(u.Id, u.UrunAdi, u.Adet, u.BirimFiyat);
            }
        }

        private void cboDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSepetler();
        }

        private void btnSepetEkle_Click(object sender, EventArgs e)
        {
            string ad = txtMusteriAdi.Text.Trim();
            string durum = cboDurum.SelectedItem?.ToString() ?? "aktif";

            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Müşteri adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sepetDAO.SepetEkle(ad, durum))
            {
                txtMusteriAdi.Text = "";
                LoadSepetler();
                MessageBox.Show("Sepet eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ekleme başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (dgvSepetler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Önce bir sepet seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string urunAdi = txtUrunAdi.Text.Trim();
            string adetStr = txtAdet.Text.Trim();

            if (string.IsNullOrEmpty(urunAdi) || string.IsNullOrEmpty(adetStr))
            {
                MessageBox.Show("Ürün adı ve adet boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(adetStr, out int adet))
            {
                MessageBox.Show("Adet sayı olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int sepetId = Convert.ToInt32(dgvSepetler.SelectedRows[0].Cells["Id"].Value);

            if (sepetUrunDAO.UrunEkle(sepetId, urunAdi, adet))
            {
                txtUrunAdi.Text = "";
                txtAdet.Text = "";
                LoadSepetUrunleri(sepetId);
                MessageBox.Show("Ürün eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ürün bulunamadı! Önce urunler tablosuna ekleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}