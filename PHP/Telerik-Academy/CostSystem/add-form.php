<?php
mb_internal_encoding('UTF-8');
$pageTitle = "Add Cost";
include './includes/header.php';

if (isset($_POST["costValue"]) &&
        isset($_POST["costType"]))
{
    $error = false;

    $costValue = (float) trim($_POST["costValue"]);
    $costValue = str_replace('!', '', $costValue);
    $costValue = str_replace(',', '.', $costValue);
    $costValue = htmlspecialchars($costValue);

    $costName = trim($_POST['costName']);
    $costName = str_replace('!', '', $costName);
    $costName = htmlspecialchars($costName);

    $costType = (int) $_POST["costType"];

    if (!is_numeric($costValue))
    {
        $error = true;
        echo '<p class="text-error">Cost value is invalid!</p>';
    }

    if (mb_strlen($costName) < 3 || mb_strlen($costName) > 100)
    {
        $error = true;
        echo '<p class="text-error">Cost name is invalid!</p>';
    }

    if (file_exists("data/currentIndex.txt"))
    {
        $currentIndexRaw = file("data/currentIndex.txt");
        $currentIndex = (int) $currentIndexRaw[0];
    }
    else
    {
        $error = true;
        echo '<p class="text-error">Error occured while geting data!</p>';
    }

    if (!$error)
    {
        $result =
                $currentIndex . '|' .
                $costName . '|' .
                $costValue . '|' .
                $costType . '|' .
                date('D, d M Y H:i:s') .
                "\n";
        $currentIndex++;

        if (file_exists("data/currentIndex.txt"))
        {
            file_put_contents("data/currentIndex.txt", $currentIndex);
            echo '<p class="text-success">Cost added.</p>';
        }
        else
        {
            echo '<p class="text-error">Error occured while saving data!</p>';
        }

        if (file_exists("data/costs.txt"))
        {
            file_put_contents("data/costs.txt", $result, FILE_APPEND);
        }
        else
        {
            echo '<p class="text-error">Error occured while saving data!</p>';
        }
    }
}
?>

<h1>Add Cost Page</h1>
<a href="index.php" class="btn btn-info">Show all costs</a>
<form action="add-form.php" method="POST">
    <label for="cost-name">Cost name</label>
    <input id="cost-name" type="text" name="costName"/>

    <label for="cost-value">Cost value</label>
    <input id="cost-value" type="text" name="costValue"/>

    <label for="cost-type">Cost type</label>
    <select id="cost-type" name="costType">
        <?php
        if (file_exists('data/categories.txt'))
        {
            $categories = file('data/categories.txt');
            foreach ($categories as $key => $value)
            {
                echo '<option value="' . $key . '">' . trim($value) .
                '</option>';
            }
        }
        ?>
    </select><br />

    <input type="submit" value="Add Cost" class="btn btn-primary">
    <input type="hidden" name="isSubmit" />
</form>

<?php
include './includes/footer.php';
?>