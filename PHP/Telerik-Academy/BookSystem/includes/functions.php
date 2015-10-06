<?php
function render($data,$name){       
    // TODO: Check if file is valid
    include $name;       
}

function isLoggedIn()
{
    if (isset($_SESSION["isLoggedIn"]))
    {
        return true;
    }
    else
    {
        return false;
    }
}


