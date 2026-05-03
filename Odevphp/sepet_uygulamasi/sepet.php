<?php 
include 'db.php'; 
session_start(); 
?>
<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <title>Sepetim</title>
</head>
<body>
    <h2>Sepetiniz</h2>
    <table border="1" cellpadding="10">
        <tr>
            <th>Ürün Adı</th>
            <th>Adet</th>
            <th>Birim Fiyat</th>
            <th>Toplam</th>
            <th>İşlem</th>
        </tr>
        <?php
        $genel_toplam = 0;
        if (isset($_SESSION['sepet']) && !empty($_SESSION['sepet'])) {
            foreach ($_SESSION['sepet'] as $id => $adet) {
                $sql = "SELECT name, price FROM products WHERE id = ?";
                $params = array($id);
                $stmt = sqlsrv_query($conn, $sql, $params);
                $urun = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC);
                
                $toplam = $urun['price'] * $adet;
                $genel_toplam += $toplam;

                echo "<tr>
                        <td>{$urun['name']}</td>
                        <td>$adet</td>
                        <td>{$urun['price']} TL</td>
                        <td>$toplam TL</td>
                        <td><a href='islem.php?islem=sil&id=$id'>Kaldır</a></td>
                      </tr>";
            }
        } else {
            echo "<tr><td colspan='5'>Sepetiniz boş.</td></tr>";
        }
        ?>
    </table>
    <h3>Genel Toplam: <?php echo $genel_toplam; ?> TL</h3>
    <a href="index.php">Alışverişe Devam Et</a>
</body>
</html>