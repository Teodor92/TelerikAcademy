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
$data['selectedAuthors'] = array();
$data['bookTitle'] = '';

if ($_POST) {
    $data['bookTitle'] = mysqli_escape_string($connection, trim($_POST['bookTitle']));
    $data['selectedAuthors'] = isset($_POST['authors']) ? $_POST['authors'] : array();
    
    if (mb_strlen($data['bookTitle'], 'UTF-8') >= 3 && count($data['selectedAuthors']) > 0) {
        
        $result = mysqli_query($connection, 'INSERT INTO books (book_title) VALUES ("' . $data['bookTitle'] . '")');
        $bookId = mysqli_insert_id($connection);
        $stmt = mysqli_prepare($connection, 'INSERT INTO books_authors (book_id,author_id) VALUES (?,?)');
        foreach ($data['selectedAuthors'] as $authorId) {
            mysqli_stmt_bind_param($stmt, 'ii', $bookId, $authorId);
            mysqli_stmt_execute($stmt);
        }
        if ($result) {
            $data['messages']['success'] = 'The book was added succesfully!';
            $data['bookTitle'] = '';
            $data['selectedAuthors'] = array();
        } else {
            $data['errors']['record'] = 'Save failed!';
        }
    } else {
        $data['errors']['length'] = 'Title must be atleast 3 charactes long and an author must be selescted!';
    }
}
$sql = 'SELECT authors.author_name, authors.author_id FROM authors';
$query = mysqli_query($connection, $sql);
$data['authors'] = array();
if (!$query) {
    echo 'Connection problem';
    echo mysqli_error($connection);
    exit;
}

while ($row = mysqli_fetch_assoc($query)) {
    $data['authors'][$row['author_id']] = $row['author_name'];
}

$data['title'] = 'Add book';
$data['content'] = 'templates/addBookTemplate.php';
render($data, 'templates/layouts/normalLayout.php');

