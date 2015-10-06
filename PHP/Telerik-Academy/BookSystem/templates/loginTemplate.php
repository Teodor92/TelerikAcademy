<?php
foreach ($data['errors'] as $error)
{
    ?> 
    <p class="text-error"><?= $error ?></p>
    <?php
}
?>

<form method="POST" action="login.php">
    <label for="username">Username:</label>
    <input id="username" type="text" name="username" />
    <label for="password">Password:</label>
    <input id="password" type="password" name="password" />
    <br />
    <input class="btn btn-primary" type="submit" name="login" value="Enter" />
</form>