<?php
$pageTitle = "Register";
include './includes/header.php';
?>

<form method="post">
    <div>Username:</div>
    <input type="text" name="username" />
    <div>Password:</div>
    <input type="password" name="password" />
    <br />
    <input class="btn btn-primary" type="submit" name="go" value="Register" />
    <a class="btn btn-info" href="index.php">Login</a>
</form>


<?php
if (isset($_POST['go']))
{
    $username = mysqli_real_escape_string($dbConect, htmlspecialchars($_POST['username']));
    $password = mysqli_real_escape_string($dbConect, htmlspecialchars($_POST['password']));

    if (strlen($username) < 5)
    {
        $error = generateErrorMessage("Username should be atleast 5 charaters!");
    }

    if (strlen($password) < 5)
    {
        $error = generateErrorMessage("Password should be atleast 5 charaters!");
    }

    $check = mysqli_query($dbConect, "SELECT username FROM users WHERE username = '$username'");
    $result = $check->num_rows;

    if ($result > 0)
    {
        $error = generateErrorMessage("User already exists");
    }
    else if ($result == 0)
    {
        $insert = mysqli_query($dbConect, "INSERT INTO `users`(`username`, `password`) VALUES ('$username', '$password')");

        if ($insert)
        {
            echo generateErrorMessage("Resistred! Enter <a href='index.php'>here</a>!");
        }
        else
        {
            echo generateErrorMessage("Failed. Pleaase try again!");
        }
    }

    if (isset($error))
    {
        echo $error;
    }
}
?>

<?php
include './includes/footer.php';
?>