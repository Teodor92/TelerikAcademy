<h2>Add book</h2>
<p class="text-success"><?= isset($data['messages']['success']) ? $data['messages']['success'] : '' ?></p>
<p class="text-error"><?= isset($data['errors']['record']) ? $data['errors']['record'] : '' ?></p>
<p class="text-error"><?= isset($data['errors']['length']) ? $data['errors']['length'] : '' ?></p>
<form action="addBook.php" method="POST">
    <div>
        <label for="bookTitle">Title:</label>
        <input name="bookTitle" value="<?= isset($data['bookTitle']) ? $data['bookTitle'] : '' ?>" />
    </div>
    <div>
        <lable for="authors">Author:</lable></br>
        <select name="authors[]" multiple="multiple" id="authors">
            <?php 
            
            foreach ($data['authors'] as $key => $value)
            { ?>
                <option value="<?= $key ?>" <?= in_array($key, $data['selectedAuthors']) ? 'selected=selected' : '' ?>>
                    <?= $value ?></option>
            <?php } ?>            
        </select>
    </div>
    <div>
        <input type="submit" value="Add" class="btn btn-success" />
    </div>
</form>
