<?php
$pageTitle = "New Message";
include './includes/header.php';
IsLogged();
?>

<form method="POST" action="add-message.php" class="form-horizontal">

    <div class="control-group">
        <label class="control-label" for="msg-content">Message:</label>
        <div class="controls">
            <textarea id="msg-content" name="content"></textarea>
        </div>
    </div>

    <div class="control-group">
        <div class="controls">
            <input class="btn btn-primary" type="submit" name="msg" value="Send" />
            <a class="btn btn-info" href="all-messages.php">All Messages</a> 
        </div>
    </div>
</form>

<?php
if (isset($_POST['msg']))
{
    $content = mysqli_real_escape_string($dbConect, htmlspecialchars($_POST['content']));
    $author = mysqli_real_escape_string($dbConect, htmlspecialchars($_SESSION['isLogged']));

    if (strlen($content) < 3)
    {
        $error = generateErrorMessage("Message is too short");
    }
    
    if (strlen($content) > 250)
    {
        $error = "Message is too long!";
    }

    if (isset($error))
    {
        echo $error;
    }
    else
    {
        $today = date("d.m.y");
        $query = mysqli_query($dbConect, 'INSERT INTO `messages` (`content`, `author`, `post_date`) VALUES ("' . $content . '", "' . $author . '", "' . $today . '")');

        if ($query)
        {
            header("Location: all-messages.php");
        }
        else
        {
            echo generateErrorMessage("Error!");
        }
    }
}
?>

<?php include './includes/footer.php' ?>