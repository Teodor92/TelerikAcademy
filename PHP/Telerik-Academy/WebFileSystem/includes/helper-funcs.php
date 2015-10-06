<?php

function downloadFile($file)
{ // $file = include path
    if (file_exists($file))
    {
        header('Content-Description: File Transfer');
        header('Content-Type: application/octet-stream');
        header('Content-Disposition: attachment; filename=' . basename($file));
        header('Content-Transfer-Encoding: binary');
        header('Expires: 0');
        header('Cache-Control: must-revalidate, post-check=0, pre-check=0');
        header('Pragma: public');
        header('Content-Length: ' . filesize($file));
        ob_clean();
        flush();
        readfile($file);
        exit;
    }
}

function generateDirectoryFileTable($path)
{
    $allFiles = scandir($path);
    $output = "";
    for ($index = 2; $index < count($allFiles); $index++)
    {
        $output =
                $output .
                '<tr><td>' .
                $allFiles[$index] .
                '</td><td>' .
                filesize($path . DIRECTORY_SEPARATOR . $allFiles[$index]) .
                ' bytes</td><td><a href="files.php?id=' . $allFiles[$index] . '">Download</a></td></tr>';
    }

    return $output;
}

function checkIfLoggedIn()
{
    if ($_SESSION && isset($_SESSION['isLoggedIn']))
    {
        if (!$_SESSION['isLoggedIn'])
        {
            header('Location: index.php');
            exit;
        }
        else
        {
            return true;
        }
    }
    else
    {
        header('Location: index.php');
        exit;
    }
}

function isLoggedIn()
{
    if ($_SESSION && isset($_SESSION['isLoggedIn']))
    {
        if ($_SESSION['isLoggedIn'] == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
}
?>
