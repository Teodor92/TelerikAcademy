<?php
$pageTitle = "Home";
include 'includes/header.php';
?>

<?php
if (isset($_SESSION['isLogged']))
{
    header("Location: messages.php");
}
?>
<form method="POST" action="index.php">
    <label for="username">Username:</label>
    <input id="username" type="text" name="username" />
    <label for="password">Password:</label>
    <input id="password" type="password" name="password" />
    <br />
    <input class="btn btn-primary" type="submit" name="login" value="Enter" /><a class="btn btn-info" href="register.php">Register</a>
</form>

<?php
if (isset($_POST['login']))
{
    $username = htmlspecialchars($_POST['username']);
    $password = htmlspecialchars($_POST['password']);

    if (strlen($username) < 5)
    {
        $error = generateErrorMessage("Username should not be shorter that 5 characters!");
    }

    if (strlen($password) < 5)
    {
        $error = generateErrorMessage("Password should not be shorter that 5 characters!");
    }

    if (isset($error))
    {
        echo $error;
    }
    else
    {
        $check = mysqli_query($dbConect, 'SELECT * FROM users WHERE username = "'.$username.'" AND password = "'.$password.'"');
        $num = $check->num_rows;

        if ($num != 0)
        {
            $_SESSION['isLogged'] = $username;
            header("Location: all-messages.php");
        }
        else
        {
            $error = generateErrorMessage("Wrong username or password!");
        }
    }
}
?>


<?php include_once("includes/footer.php"); ?>