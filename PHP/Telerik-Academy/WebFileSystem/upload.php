
<?php
$pageTitle = "Upload";
include './includes/header.php';

checkIfLoggedIn();
$message = "";

if ($_FILES && isset($_FILES['file']))
{
    if (!is_dir('user_files'))
    {
        mkdir('user_files');
    }
    else
    {
        if (move_uploaded_file($_FILES['file']['tmp_name'], 'user_files' . DIRECTORY_SEPARATOR . $_FILES['file']['name']))
        {
            $message = "Upload successful!";
        }
        else
        {
            $message = "Upload failed!";
        }
    }
}
?>
<h1><?= $pageTitle ?></h1>
<h4 class="text-error"><?= $message ?></h4>
<div class="row-fluid">
    <div class="offset4 span8">
        <form class="form-horizontal" action="upload.php" method="POST" enctype="multipart/form-data">
            <div class="control-group">
                <label for="file">Select file:</label>
                <input id="file" type="file" name="file">
            </div>

            <div class="control-group">
                <input class="btn btn-primary" type="submit" value="Upload" />
            </div>
        </form>
    </div>
</div>

<?php
include './includes/footer.php';
?>
