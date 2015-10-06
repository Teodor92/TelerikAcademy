<?php
mb_internal_encoding('UTF-8');
$pageTitle = "Add Cost Category";
include './includes/header.php';

if (isset($_POST['categoryName']))
{
    $categoryName = $_POST['categoryName'];
    if (mb_strlen($categoryName) > 3 && mb_strlen($categoryName) < 100)
    {
        if (file_exists('data/categories.txt'))
        {
            $storeData = htmlspecialchars(trim($categoryName))."\n";
            file_put_contents('data/categories.txt', $storeData, FILE_APPEND);
        }
    }
    else
    {
        echo '<p class="text-error">Invalid category name!</p>';
    }
}
?>

<a href="index.php" class="btn btn-info">Show all costs</a>

<form class="form-horizontal" action="#" method="POST">
    <label for="cat-name">Category Name</label>
    <input id="cat-name" name="categoryName" type="text" />
    
    <input class="btn" type="submit" value="Add Category">
</form>

<?php 
include './includes/footer.php';
?>
