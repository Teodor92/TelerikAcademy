<?php if (count($data['books']) > 0)
{ ?>
    <h2>All books from this author</h2>
    <table class="table table-bordered table-hover table-striped">
        <thead>
            <tr>
                <th>Book</th>
                <th>Author</th>
            </tr>
        </thead>
    <?php foreach ($data['books'] as $book)
    { ?>
            <tr>
                <td><?= $book['title'] ?></td>
                <td>
                    <?php foreach ($book['authors'] as $authorId => $authorName)
                    { ?>
                        <a href="allAuthorBooks.php?author_id=<?= $authorId ?>"><?= $authorName ?></a> 
            <?php } ?>
                </td>
            </tr>
    <?php } ?>
    </table>
    <?php
}
else
{
    ?>
    <p>No books from this author!</p>
    <?php
}
