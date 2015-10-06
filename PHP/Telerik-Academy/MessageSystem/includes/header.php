<!DOCTYPE html>
<html>
    <?php
    session_start();
    require 'includes/connect.php';
    require 'includes/helper-funcs.php';
    require 'includes/data-persister.php';
    ?>
    <head>
        <meta charset="utf-8" />
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title><?= $pageTitle ?></title>
        <link rel="stylesheet" href="styles/bootstrap.css">
    </head>
    <body>
        <?php
        if (isset($_SESSION['isLogged']))
        {
            ?>
            <nav>
                <div class="navbar">
                    <div class="navbar-inner">
                        <a class="brand" href="index.php">Message system</a>
                        <ul class="nav">
                            <li class="active"><a href="#">Home</a></li>
                            <li><a href="all-messages.php">Messages</a></li>
                            <li><a href="add-message.php">Add messages</a></li>
                            <li><a href="logout.php">Logout</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <?php
        }
        ?>
        <div class="container">
            <h1><?= $pageTitle ?></h1>