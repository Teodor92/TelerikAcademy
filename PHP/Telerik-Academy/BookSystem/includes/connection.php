<?php
session_start();

$connection = mysqli_connect('localhost', 'admin', '123456', 'books');
mysqli_set_charset($connection, 'utf8');
if (!$connection) {
    echo 'No connection with database';
    exit;
}
