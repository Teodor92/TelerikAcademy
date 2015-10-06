<?php

include 'includes/connection.php';
include './includes/functions.php';

$data = array();
$data['errors'] = array();

if ($_GET)
{
    $data['bookId'] = (int) mysqli_real_escape_string($connection, $_GET['book_id']);

    if ($_POST)
    {
        $commentContent = mysqli_real_escape_string($connection, htmlspecialchars(trim($_POST['content'])));
        $commentDatet = date('Y-m-d H:i:s');
        ;
        $bookId = $data['bookId'];
        $userId = $_SESSION['user_id'];

        $sql = "INSERT INTO `comments`(`content`, `comment_date`, `author_id`, `book_id`) VALUES ('$commentContent','$commentDatet','$userId','$bookId')";
        $query = mysqli_query($connection, $sql);
        if (!$query)
        {
            echo 'Connection problem';
            echo mysqli_error($connection);
            exit;
        }
        else
        {
            $data['messages']['success'] = "Comment added!";
        }
    }

    $sql = 'SELECT comments.comment_id, comments.content, comments.comment_date, us.username
            FROM comments
            LEFT JOIN users us ON us.user_id = comments.author_id
            WHERE comments.book_id = "' . $data['bookId'] . '" ORDER BY comments.comment_date';
    $query = mysqli_query($connection, $sql);
    if (!$query)
    {
        echo 'Connection problem';
        echo mysqli_error($connection);
        exit;
    }

    while ($row = mysqli_fetch_assoc($query))
    {
        $data['comments'][$row['comment_id']]['username'] = $row['username'];
        $data['comments'][$row['comment_id']]['content'] = $row['content'];
        $data['comments'][$row['comment_id']]['comment_date'] = $row['comment_date'];
    }
}

$data['title'] = 'Book details';
$data['content'] = 'templates/bookDetailsTemplate.php';
if (isLoggedIn())
{
    render($data, 'templates/layouts/normalLayout.php');
}
else
{
    render($data, 'templates/layouts/publicLayout.php');
}
