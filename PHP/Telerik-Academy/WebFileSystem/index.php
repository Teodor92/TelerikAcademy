
<?php
$pageTitle = "Home";
include './includes/header.php';

$message = "";
if (isLoggedIn())
{
    header("Location: files.php");
}

if ($_POST)
{
    if (isset($_POST["username"])
            && isset($_POST["password"]))
    {
        $username = htmlspecialchars(trim($_POST['username']));
        $password = htmlspecialchars(trim($_POST['password']));
        
        if ($username == "user" && $password == "qwerty")
        {
            $_SESSION['isLoggedIn'] = true;
            header("Location: files.php");
            exit;
        }
        else
        {
            $message = "Wrong credentials!";
        }
    }
}

?>

<h1>Simple Web File System</h1>
<h4 class="text-error"><?= $message ?></h4>
<div class="row-fluid">
    <div class="offset4 span8">
        <form class="form-horizontal" action="index.php" method="POST">
        <div class="control-group">
            <label for="username">Username:</label>
            <input id="username" type="text" name="username" value="user">
        </div>

        <div class="control-group">
            <label for="password">Password</label>
            <input id="password" type="password" name="password" value="qwerty">
        </div>

        <div class="control-group">
            <input class="btn btn-primary" type="submit" value="Login" />
        </div>
    </form>
    </div>
</div>

<?php
include './includes/footer.php';
?>
