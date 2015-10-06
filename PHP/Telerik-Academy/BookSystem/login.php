<?php

include './includes/connection.php';
include './includes/functions.php';
$data = array();
$data['errors'] = array();

if (isset($_POST['login']))
{
    $username = htmlspecialchars($_POST['username']);
    $password = htmlspecialchars($_POST['password']);

    if (strlen($username) < 5)
    {
        $data['errors']['usernameLength'] = "Username should not be shorter that 5 characters!";
    }

    if (strlen($password) < 5)
    {
        $data['errors']['passwordLength'] = "Password should not be shorter that 5 characters!";
    }

    if (count($data['errors']) == 0)
    {
        $check = mysqli_query($connection, 'SELECT * FROM users WHERE username = "' . $username . '" AND password = "' . $password . '"');
        $num = $check->num_rows;

        if ($num != 0)
        {
            while ($row = mysqli_fetch_assoc($check))
            {
                $_SESSION['user_id'] = $row['user_id'];
            }
            
            $_SESSION['isLoggedIn'] = true;
            header("Location: index.php");
        }
        else
        {
            $data['errors']['invalidLogin'] = "Wrong username or password!";
        }
    }
}

$data['title'] = 'Login';
$data['content'] = 'templates/loginTemplate.php';

if (!isLoggedIn())
{
    render($data, 'templates/layouts/publicLayout.php');
}
