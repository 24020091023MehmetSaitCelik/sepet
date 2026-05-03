<?php
$serverName = "localhost, 1433";
$connectionInfo = array(
    "Database" => "sepet_db",
    "UID" => "sa",
    "PWD" => "1234",
    "CharacterSet" => "UTF-8",
    "TrustServerCertificate" => true
);

$conn = sqlsrv_connect($serverName, $connectionInfo);

if ($conn === false) {
    echo "BAĞLANTI HATASI:<br>";
    print_r(sqlsrv_errors());
} else {
    echo "Bağlantı başarılı!";
}
?>