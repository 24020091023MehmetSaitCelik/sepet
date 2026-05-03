namespace SepetApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMusteriAdi = new TextBox();
            cboDurum = new ComboBox();
            btnSepetEkle = new Button();
            dgvSepetler = new DataGridView();
            txtUrunAdi = new TextBox();
            txtAdet = new TextBox();
            btnUrunEkle = new Button();
            dgvUrunler = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSepetler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).BeginInit();
            SuspendLayout();
          
            txtMusteriAdi.Location = new Point(23, 33);
            txtMusteriAdi.Name = "txtMusteriAdi";
            txtMusteriAdi.Size = new Size(125, 27);
            txtMusteriAdi.TabIndex = 0;
            
            cboDurum.FormattingEnabled = true;
            cboDurum.Items.AddRange(new object[] { "aktif", "tamamlandi", "iptal" });
            cboDurum.Location = new Point(163, 32);
            cboDurum.Name = "cboDurum";
            cboDurum.Size = new Size(140, 28);
            cboDurum.TabIndex = 1;
            
            btnSepetEkle.Location = new Point(336, 33);
            btnSepetEkle.Name = "btnSepetEkle";
            btnSepetEkle.Size = new Size(100, 29);
            btnSepetEkle.TabIndex = 2;
            btnSepetEkle.Text = "Sepet Ekle";
            btnSepetEkle.UseVisualStyleBackColor = true;
            this.btnSepetEkle.Click += btnSepetEkle_Click;
           
            dgvSepetler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSepetler.Location = new Point(23, 92);
            dgvSepetler.Name = "dgvSepetler";
            dgvSepetler.RowHeadersWidth = 51;
            dgvSepetler.Size = new Size(413, 188);
            dgvSepetler.TabIndex = 3;
          
            txtUrunAdi.Location = new Point(32, 325);
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(125, 27);
            txtUrunAdi.TabIndex = 4;
          
            txtAdet.Location = new Point(197, 327);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(125, 27);
            txtAdet.TabIndex = 5;
            
            btnUrunEkle.Location = new Point(342, 325);
            btnUrunEkle.Name = "btnUrunEkle";
            btnUrunEkle.Size = new Size(94, 29);
            btnUrunEkle.TabIndex = 6;
            btnUrunEkle.Text = "Ürün Ekle";
            btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += btnUrunEkle_Click;
            
            dgvUrunler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUrunler.Location = new Point(32, 430);
            dgvUrunler.Name = "dgvUrunler";
            dgvUrunler.RowHeadersWidth = 51;
            dgvUrunler.Size = new Size(404, 188);
            dgvUrunler.TabIndex = 7;
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 665);
            Controls.Add(dgvUrunler);
            Controls.Add(btnUrunEkle);
            Controls.Add(txtAdet);
            Controls.Add(txtUrunAdi);
            Controls.Add(dgvSepetler);
            Controls.Add(btnSepetEkle);
            Controls.Add(cboDurum);
            Controls.Add(txtMusteriAdi);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvSepetler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMusteriAdi;
        private ComboBox cboDurum;
        private Button btnSepetEkle;
        private DataGridView dgvSepetler;
        private TextBox txtUrunAdi;
        private TextBox txtAdet;
        private Button btnUrunEkle;
        private DataGridView dgvUrunler;
    }
}