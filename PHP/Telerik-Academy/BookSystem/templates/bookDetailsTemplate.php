<h2>Book Details</h2>
<p class="text-success"><?php isset($data['messages']['success']) ? $data['messages']['success'] : '' ?></p>
<section class="comments">
    <h3>Comments:</h3>
    <?php
    if (isset($data['comments']))
    {
        foreach ($data['comments'] as $comment)
        {
            ?>

            <div class="well">
                <p><?= $comment['username'] ?></p>
                <p><?= $comment['comment_date'] ?></p>
                <p><?= $comment['content'] ?></p>
            </div>

            <?php
        }
    }
    else
    {
        ?>
        <div class="well">
            No comments
        </div>
        <?php
    }
    ?>
</section>
<section>
    <?php
    if (isLoggedIn())
    {
        ?>
        <form action="bookDetails.php?book_id=<?= $data['bookId'] ?>" method="POST">
            <div>
                <textarea name="content" rows="6" cols="20" placeholder="Enter me ......"></textarea>
            </div>
            <div>
                <input class="btn btn-success" type="submit" value="Post" />    
            </div>
        </form>
        <?php
    }
    else
    {
        ?>
        <p class="text-warning">Login to comment</p>
        <?php
    }
    ?>
</section>

