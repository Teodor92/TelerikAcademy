<h2>All books</h2>
<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th>Book</th>
            <th>Author</th>
        </tr>
    </thead>
    <tbody>
        <?php
        if (count($data['books']) > 0)
        {
            ?>

            <?php
            foreach ($data['books'] as $bookId => $book)
            {
                ?>
                <tr>
                    <td><a href="bookDetails.php?book_id=<?= $bookId ?>"><?= $book['title'] ?></a></td>
                    <td>
                        <?php
                        foreach ($book['authors'] as $authorId => $authorName)
                        {
                            ?>
                            <a href="allAuthorBooks.php?author_id=<?= $authorId ?>"><?= $authorName ?></a> 
                        <?php } ?>
                    </td>
                </tr>
            <?php } ?>
            <?php
        }
        else
        {
            ?>
            <tr><td colspan="2">No book data yet.</td></tr>
            <?php
        }
        ?>
    </tbody>
</table>