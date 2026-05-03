<?php
include 'db.php';

// Sepet ekle
if (isset($_POST['sepet_ekle'])) {
    $musteri = $_POST['musteri_adi'];
    $durum = $_POST['durum'];
    $sql = "INSERT INTO sepetler (musteri_adi, durum, olusturma_tarihi, guncelleme_tarihi) VALUES (?, ?, GETDATE(), GETDATE())";
    sqlsrv_query($conn, $sql, array($musteri, $durum));
}

// Ürün ekle
if (isset($_POST['urun_ekle'])) {
    $ad = $_POST['urun_adi'];
    $fiyat = $_POST['fiyat'];
    $sql = "INSERT INTO urunler (urun_adi, fiyat, stok, olusturma_tarihi) VALUES (?, ?, 0, GETDATE())";
    sqlsrv_query($conn, $sql, array($ad, $fiyat));
}

// Sepetleri çek
$sepetler = sqlsrv_query($conn, "SELECT * FROM sepetler ORDER BY id");

// Ürünleri çek
$urunler = sqlsrv_query($conn, "SELECT * FROM urunler ORDER BY id");
?>
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
        .form-row button { padding: 4px 12px; background: #d4d0c8; border: 1px solid #888; cursor: pointer; }
        .form-row button:hover { background: #c0bdb5; }
        table { width: 100%; border-collapse: collapse; background: white; margin-bottom: 15px; }
        table th { background: #d4d0c8; border: 1px solid #999; padding: 4px 8px; text-align: left; }
        table td { border: 1px solid #ccc; padding: 4px 8px; }
        table tr:hover { background: #f5f5ff; }
        h3 { margin-bottom: 8px; font-size: 13px; color: #333; }
        .section { margin-bottom: 20px; }
        a.sil { color: red; text-decoration: none; font-size: 11px; }
    </style>
</head>
<body>
<div class="panel">

    <!-- SEPET BÖLÜMÜ -->
    <div class="section">
        <form method="POST">
            <div class="form-row">
                <input type="text" name="musteri_adi" placeholder="Müşteri adı" required>
                <select name="durum">
                    <option value="aktif">aktif</option>
                    <option value="iptal">iptal</option>
                    <option value="tamamlandi">tamamlandı</option>
                </select>
                <button type="submit" name="sepet_ekle">Sepet Ekle</button>
            </div>
        </form>

        <table>
            <tr>
                <th>#</th>
                <th>Müşteri Adı</th>
                <th>Oluşturma Tarihi</th>
                <th>Durum</th>
                <th>İşlem</th>
            </tr>
            <?php while ($row = sqlsrv_fetch_array($sepetler, SQLSRV_FETCH_ASSOC)): ?>
            <tr>
                <td><?= $row['id'] ?></td>
                <td><?= htmlspecialchars($row['musteri_adi']) ?></td>
                <td><?= $row['olusturma_tarihi']->format('Y-m-d H:i:s') ?></td>
                <td><?= $row['durum'] ?></td>
                <td><a class="sil" href="islem.php?islem=sepet_sil&id=<?= $row['id'] ?>">Sil</a></td>
            </tr>
            <?php endwhile; ?>
        </table>
    </div>

    <!-- ÜRÜN BÖLÜMÜ -->
    <div class="section">
        <form method="POST">
            <div class="form-row">
                <input type="text" name="urun_adi" placeholder="Ürün adı" required>
                <input type="number" name="fiyat" placeholder="Fiyat" step="0.01" required>
                <button type="submit" name="urun_ekle">Ürün Ekle</button>
            </div>
        </form>

        <table>
            <tr>
                <th>#</th>
                <th>Ürün Adı</th>
                <th>Fiyat</th>
                <th>Stok</th>
                <th>Kategori</th>
                <th>İşlem</th>
            </tr>
            <?php while ($row = sqlsrv_fetch_array($urunler, SQLSRV_FETCH_ASSOC)): ?>
            <tr>
                <td><?= $row['id'] ?></td>
                <td><?= htmlspecialchars($row['urun_adi']) ?></td>
                <td><?= number_format($row['fiyat'], 2) ?> TL</td>
                <td><?= $row['stok'] ?></td>
                <td><?= $row['kategori'] ?? '-' ?></td>
                <td><a class="sil" href="islem.php?islem=urun_sil&id=<?= $row['id'] ?>">Sil</a></td>
            </tr>
            <?php endwhile; ?>
        </table>
    </div>

</div>
</body>
</html>