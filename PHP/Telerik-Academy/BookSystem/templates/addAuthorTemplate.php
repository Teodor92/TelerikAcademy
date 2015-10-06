<h2>Add new author</h2>
<p class="text-success"><?= isset($data['messages']['success']) ? $data['messages']['success'] : '' ?></p>
<p class="text-error"><?= isset($data['errors']['record']) ? $data['errors']['record'] : '' ?></p>
<p class="text-error"><?= isset($data['errors']['duplicate']) ? $data['errors']['duplicate'] : '' ?></p>
<p class="text-error"><?= isset($data['errors']['length']) ? $data['errors']['length'] : '' ?></p>
<form action="addAuthor.php" method="POST">
    <p>
        <label for="authorName">Author name:</label>
        <input name="authorName" value="<?= isset($data['authorName']) ? $data['authorName'] : '' ?>" />
        <input type="submit" value="Add" class="btn btn-success"/>
    </p>
</form>

<table class="table table-bordered table-striped table-hover">
    <thead>
        <tr>
            <th>Authors</th>
        </tr>
    </thead>
    <tbody>
        <?php if (count($data['authors']) > 0)
        {
            ?>
            <?php foreach ($data['authors'] as $author_id => $author_name)
            {
                ?>
                <tr>
                    <td><a href="allAuthorBooks.php?author_id=<?= $author_id ?>"><?= $author_name ?></a> </td>
                </tr>
    <?php } ?>
    </table>
<?php
}
else
{
    ?>
    <tr><td colspan="2">No author data</td></tr>
    <?php
}
?>
</tbody>
</table>
