<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST");

$data = json_decode(file_get_contents("php://input"),true);
$pname = $data["username"];
$pemail = $data["email"];


include("servercon.php");
$query = "INSERT INTO tbluser (username, email) VALUES ('".$pname."' ,'".$pemail."')";

if (mysqli_query($dbconnect,$query) or die("Insert query failed")){
    echo json_encode(array("message" => "User Inserted Successfully", "status" => true));
}
else{
    echo json_encode(array("message" => "Failed", "status" => false));
}