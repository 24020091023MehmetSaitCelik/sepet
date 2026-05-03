<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SepetUygulamasi.Default" %>
<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <title>Sepet Uygulaması</title>
    <style>
        * { box-sizing: border-box; margin: 0; padding: 0; font-family: Arial, sans-serif; font-size: 13px; }
        body { background: #f0f0f0; padding: 20px; }
        .panel { background: #e8e8e8; border: 1px solid #aaa; border-radius: 4px; padding: 15px; max-width: 800px; margin: auto; }
        .form-row { display: flex; gap: 8px; align-items: center; margin-bottom: 12px; }
        .form-row input { padding: 4px 6px; border: 1px solid #999; background: white; }
        .form-row select { padding: 4px 6px; border: 1px solid #999; background: white; }
        .form-row button, .form-row input[type=submit] { padding: 4px 12px; background: #d4d0c8; border: 1px solid #888; cursor: pointer; }
        table { width: 100%; border-collapse: collapse; background: white; margin-bottom: 15px; }
        table th { background: #d4d0c8; border: 1px solid #999; padding: 4px 8px; text-align: left; }
        table td { border: 1px solid #ccc; padding: 4px 8px; }
        table tr:hover { background: #f5f5ff; }
        .section { margin-bottom: 20px; }
        a { color: red; }
    </style>
</head>
<body>
<form runat="server">
<div class="panel">

    <!-- SEPET BÖLÜMÜ -->
    <div class="section">
        <div class="form-row">
            <asp:TextBox ID="txtMusteriAdi" runat="server" placeholder="Müşteri adı" />
            <asp:DropDownList ID="ddlDurum" runat="server">
                <asp:ListItem Value="aktif">aktif</asp:ListItem>
                <asp:ListItem Value="iptal">iptal</asp:ListItem>
                <asp:ListItem Value="tamamlandi">tamamlandı</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSepetEkle" runat="server" Text="Sepet Ekle" OnClick="btnSepetEkle_Click" />
        </div>

        <asp:GridView ID="gvSepetler" runat="server" AutoGenerateColumns="False"
            BorderColor="#999" BorderStyle="Solid" BorderWidth="1px"
            CellPadding="4" Width="100%" DataKeyNames="id"
            OnRowCommand="gvSepetler_RowCommand">
            <HeaderStyle BackColor="#D4D0C8" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" />
                <asp:BoundField DataField="musteri_adi" HeaderText="Müşteri Adı" />
                <asp:BoundField DataField="olusturma_tarihi" HeaderText="Oluşturma Tarihi" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:BoundField DataField="durum" HeaderText="Durum" />
                <asp:ButtonField ButtonType="Link" CommandName="Sil" Text="Sil" HeaderText="İşlem" />
            </Columns>
        </asp:GridView>
    </div>

    <!-- ÜRÜN BÖLÜMÜ -->
    <div class="section">
        <div class="form-row">
            <asp:TextBox ID="txtUrunAdi" runat="server" placeholder="Ürün adı" />
            <asp:TextBox ID="txtFiyat" runat="server" placeholder="Fiyat" />
            <asp:Button ID="btnUrunEkle" runat="server" Text="Ürün Ekle" OnClick="btnUrunEkle_Click" />
        </div>

        <asp:GridView ID="gvUrunler" runat="server" AutoGenerateColumns="False"
            BorderColor="#999" BorderStyle="Solid" BorderWidth="1px"
            CellPadding="4" Width="100%" DataKeyNames="id"
            OnRowCommand="gvUrunler_RowCommand">
            <HeaderStyle BackColor="#D4D0C8" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" />
                <asp:BoundField DataField="urun_adi" HeaderText="Ürün Adı" />
                <asp:BoundField DataField="fiyat" HeaderText="Fiyat" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="stok" HeaderText="Stok" />
                <asp:BoundField DataField="kategori" HeaderText="Kategori" NullDisplayText="-" />
                <asp:ButtonField ButtonType="Link" CommandName="Sil" Text="Sil" HeaderText="İşlem" />
            </Columns>
        </asp:GridView>
    </div>

</div>
</form>
</body>
</html>