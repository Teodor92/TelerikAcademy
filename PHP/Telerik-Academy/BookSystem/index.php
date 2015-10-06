<?php
include 'includes/connection.php';
include './includes/functions.php';
$sql = 'SELECT books.book_id, books.book_title, authors.author_name, authors.author_id FROM books 
            LEFT JOIN books_authors ON books_authors.book_id = books.book_id
            LEFT JOIN authors ON books_authors.author_id = authors.author_id';
$query = mysqli_query($connection, $sql);
if (!$query)
{
    echo 'Connection problem';
    echo mysqli_error($connection);
    exit;
}
$data = array();
while ($row = mysqli_fetch_assoc($query))
{
    $data['books'][$row['book_id']]['title'] = $row['book_title'];
    $data['books'][$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
}

$data['title'] = 'All books';
$data['content'] = 'templates/indexPublic.php';
if (isLoggedIn())
{
    render($data, 'templates/layouts/normalLayout.php');
}
else
{
    render($data, 'templates/layouts/publicLayout.php');
}