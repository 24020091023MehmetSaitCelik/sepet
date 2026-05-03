<?php
include 'db.php';

$islem = $_GET['islem'] ?? '';
$id = $_GET['id'] ?? 0;

if ($islem === 'sepet_sil') {
    sqlsrv_query($conn, "DELETE FROM sepetler WHERE id = ?", array($id));
    header("Location: index.php");
}

if ($islem === 'urun_sil') {
    sqlsrv_query($conn, "DELETE FROM urunler WHERE id = ?", array($id));
    header("Location: index.php");
}
?>