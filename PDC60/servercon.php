<?php

$dbconnect = mysqli_connect("localhost","testuser","12345678","testdb");
if(mysqli_connect_errno()){
    echo "Failed to connect to MySqli: " . mysqli_connect_error();
    die();


}
?>

