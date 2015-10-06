<?php
include 'includes/connection.php';
include './includes/functions.php';
if ($_GET) {
    $authorId = (int) $_GET['author_id'];
    $sql = 'SELECT books.book_id, books.book_title, authors.author_name, authors.author_id FROM books 
            LEFT JOIN books_authors ba ON ba.book_id = books.book_id
            LEFT JOIN authors ON ba.author_id = authors.author_id
            LEFT JOIN books_authors ba2 ON ba2.book_id = books.book_id
            WHERE ba2.author_id = "' . $authorId . '"';
    $query = mysqli_query($connection, $sql);
    if (!$query) {
        echo 'Connection problem';
        echo mysqli_error($connection);
        exit;
    }
    
    $data = array();
    while ($row = mysqli_fetch_assoc($query)) {
        $data['books'][$row['book_id']]['title'] = $row['book_title'];
        $data['books'][$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
    }
}

$data['title'] = 'Books by author';
$data['content'] = 'templates/bookByAuthorTemplate.php';
render($data, 'templates/layouts/normalLayout.php');