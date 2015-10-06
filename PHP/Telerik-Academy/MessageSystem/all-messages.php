<?php
$pageTitle = "Messages";
include './includes/header.php';
IsLogged();
?>

<table class="table table-bordered table-striped">
    <thead>
        <tr>
            <th>Message</th>
            <th>From</th>
            <th>Date</th>
        </tr>
    </thead>
    <tbody>
        <?php
        $get = mysqli_query($dbConect, "SELECT * FROM messages ORDER BY post_date");
        if ($get)
        {
            while ($row = $get->fetch_assoc())
            {
                ?>
                <tr>
                    <td><?php echo $row['content']; ?></td>
                    <td><?php echo $row['author']; ?></td>
                    <td><?php echo $row['post_date']; ?></td>
                </tr>
                <?php
            }
        }
        ?>
    </tbody>
</table>

<a class="btn btn-success" href="add-message.php">Add new message.</a>

<?php include './includes/footer.php'; ?>