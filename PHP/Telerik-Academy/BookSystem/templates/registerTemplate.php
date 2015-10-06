<?php
foreach ($data['errors'] as $error)
{
    ?> 
    <p class="text-error"><?= $error ?></p>
    <?php
}
?>

<form method="post">
    <div>Username:</div>
    <input type="text" name="username" />
    <div>Password:</div>
    <input type="password" name="password" />
    <br />
    <input class="btn btn-primary" type="submit" name="go" value="Register" />
</form>