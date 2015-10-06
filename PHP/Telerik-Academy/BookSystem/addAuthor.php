<?php

include 'includes/connection.php';
include './includes/functions.php';

if (!isLoggedIn())
{
    header("Location: index.php");
}

$data = array();
$data['errors'] = array();
$data['messages'] = array();

if ($_POST)
{
    $data['authorName'] = mysqli_escape_string($connection, trim($_POST['authorName']));

    if (mb_strlen($data['authorName'], 'UTF-8') >= 3)
    {
        $query = mysqli_query($connection, 'SELECT author_name FROM authors WHERE author_name = "' . $data['authorName'] . '"');
        if ($query && mysqli_num_rows($query) == 0)
        {
            $result = mysqli_query($connection, 'INSERT INTO authors (author_name) VALUES ("' . $data['authorName'] . '")');
            if ($result)
            {
                $data['messages']['success'] = 'Author added!';
                $data['authorName'] = '';
            }
            else
            {
                $data['errors']['record'] = 'Save failed!';
            }
        }
        else
        {
            $data['errors']['duplicate'] = 'Author name exists!';
        }
    }
    else
    {
        $data['errors']['length'] = 'Author name must be atleast 3 characters long!';
    }
}
$sql = 'SELECT authors.author_name, authors.author_id FROM authors';
$query = mysqli_query($connection, $sql);
$data['authors'] = array();
if (!$query)
{
    echo 'Connection problem';
    echo mysqli_error($connection);
    exit;
}
while ($row = mysqli_fetch_assoc($query))
{
    $data['authors'][$row['author_id']] = $row['author_name'];
}

$data['title'] = 'Add author';
$data['content'] = 'templates/addAuthorTemplate.php';
render($data, 'templates/layouts/normalLayout.php');