<?php

include './includes/connection.php';
include './includes/functions.php';
$data = array();
$data['errors'] = array();

if (isset($_POST['go']))
{
    $username = mysqli_real_escape_string($connection, htmlspecialchars($_POST['username']));
    $password = mysqli_real_escape_string($connection, htmlspecialchars($_POST['password']));

    if (strlen($username) < 5)
    {
        $data['errors']['usernameLength'] = "Username should be atleast 5 charaters!";
    }

    if (strlen($password) < 5)
    {
        $data['errors']['passwordLength'] = "Password should be atleast 5 charaters!";
    }

    $check = mysqli_query($connection, "SELECT username FROM users WHERE username = '$username'");
    $result = $check->num_rows;

    if ($result > 0)
    {
        $data['errors']['duplicate'] = "User already exists";
    }
    else if ($result == 0)
    {
        $insert = mysqli_query($connection, "INSERT INTO `users`(`username`, `password`) VALUES ('$username', '$password')");
        $check = mysqli_query($connection, 'SELECT * FROM users WHERE username = "' . $username . '" AND password = "' . $password . '"');

        if ($insert)
        {
            session_start();
            while ($row = mysqli_fetch_assoc($check))
            {
                var_dump($row);
                $_SESSION['user_id'] = $row['user_id'];
            }
            $_SESSION['isLoggedIn'] = true;
            header("Location: index.php");
        }
        else
        {
            $data['errors']['regFailed'] = "Failed. Pleaase try again!";
        }
    }

    if (isset($error))
    {
        echo $error;
    }
}

$data['title'] = 'Register';
$data['content'] = 'templates/registerTemplate.php';

if (!isLoggedIn())
{
    render($data, 'templates/layouts/publicLayout.php');
}
else
{
    header("Location: index.php");
}
