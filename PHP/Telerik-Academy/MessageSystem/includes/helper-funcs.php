<?php
function IsLogged()
{
    if (!isset($_SESSION["isLogged"]))
    {
        header("Location: index.php");
    }
}

function generateErrorMessage($error)
{
    return '<p class="text-error">'.$error.'</p>';
}
?>
