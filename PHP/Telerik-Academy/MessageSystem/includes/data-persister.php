<?php

function registerNewUser($username, $password, $nickname, $connection)
{
    $filteredUsername = mysqli_real_escape_string($connection, $username);
    $filteredPassword = mysqli_real_escape_string($connection, $password);
    $filteredNickname = mysqli_real_escape_string($connection, $nickname);
    $command = 'INSERT INTO users (username, password, nickname)'.
            ' VALUES("'.$filteredUsername.'", "'.$filteredPassword.'", "'.$filteredNickname.'")';
    
    mysqli_query($connection, $command);
}

function addMessage($author, $message, $connection)
{
    $command = '';
}

function getMessages($connection)
{
    $command = "SELECT * FROM messages";
    mysqli_query($connection, $command);
}

?>
