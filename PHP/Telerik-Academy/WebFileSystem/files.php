
<?php
$pageTitle = "Files";
include './includes/header.php';

checkIfLoggedIn();
$message = "";

if ($_GET && isset($_GET['id']))
{
    $fileName = htmlspecialchars(trim($_GET['id']));
    $fileDir = 'user_files' . DIRECTORY_SEPARATOR . $fileName;
    if (file_exists($fileDir))
    {
        downloadFile($fileDir);
    }
    else
    {
        $message = "File not Found!";
    }
}
?>
<h1><?= $pageTitle ?></h1>
<h4 class="text-error"><?= $message ?></h4>

<div class = "row-fluid">
    <table class = "table table-bordered table-striped">
        <thead>
            <tr>
                <th>File Name</th>
                <th>File Size</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <?php 
            if (is_dir('user_files'))
            {
                echo generateDirectoryFileTable('user_files');
            }
            ?>
        </tbody>
    </table>
</div>

<?php
include './includes/footer.php';
?>
