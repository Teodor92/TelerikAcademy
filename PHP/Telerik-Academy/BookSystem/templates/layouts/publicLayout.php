<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">  
        <title><?=$data['title'] ?></title>
        <link href="styles/bootstrap.css" rel="stylesheet" />
    </head>
    <body>
        <div class="navbar">
            <div class="navbar-inner">
                <a class="brand" href="index.php">Book system</a>
                <ul class="nav">
                    <li><a href="index.php">All books</a></li>
                    <li><a href="login.php">Login</a></li>
                    <li><a href="register.php">Register</a></li>
                </ul>
            </div>
        </div>
        <div class="container-fluid">
            <?php
            include $data['content'];
            ?>
        </div>
    </body>
</html>
