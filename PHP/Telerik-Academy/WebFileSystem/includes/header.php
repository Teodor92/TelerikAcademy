<!DOCTYPE html>
<html>
    <?php
    session_start();
    require 'includes/helper-funcs.php';
    ?>
    <head>
        <meta charset="utf-8" />
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title><?= $pageTitle ?></title>
        <link rel="stylesheet" href="styles/bootstrap.css">
    </head>
    <body>
        <?php
        if(isLoggedIn())
        {
        ?>

        <nav>
            <div class="navbar">
                <div class="navbar-inner">
                    <a class="brand" href="index.php">My App</a>
                    <ul class="nav">
                        <li class="active"><a href="#">Home</a></li>
                        <li><a href="files.php">Files</a></li>
                        <li><a href="upload.php">Upload</a></li>
                        <li><a href="logout.php">Logout</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <?php
        }
        ?>
        <div class="container">