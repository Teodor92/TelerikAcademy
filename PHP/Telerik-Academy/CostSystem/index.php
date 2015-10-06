<?php
mb_internal_encoding('UTF-8');
$pageTitle = "Home";
require './includes/helper-funcs.php';
include './includes/header.php';

$myvar="Parametar edno";
$myvar2=" parametar dve";
$myvar3=$myvar.$myvar2;
echo $myvar3;
?>

<h1>Welcome home</h1>
<a href="add-form.php" class="btn btn-info">Add cost</a>
<a href="add-cost-category-form.php" class="btn btn-info">Add cost category</a>
<form class="filter form-inline" action="#" method="GET">
    <select name="filter">
        <?php
        if (file_exists('data/categories.txt'))
        {
            $categories = file('data/categories.txt');
            foreach ($categories as $key => $value)
            {
                echo '<option value="' . $key . '">' . $value .
                '</option>';
            }
        }
        ?>
    </select>

    <input class="btn btn-info" type="submit" value="Filter" />
    <a href="index.php" class="btn btn-danger">Clear Filter</a>
</form>

<table class="table table-bordered table-striped">
    <thead>
        <tr>
            <th>Id</th>
            <th>Cost Name</th>
            <th>Cost</th>
            <th>Cost Type</th>
            <th>Cost Time</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
        <?php
        $sum = 0;

        if (file_exists("data/costs.txt"))
        {
            $allCosts = file("data/costs.txt");
            $categories = file("data/categories.txt");

            foreach ($allCosts as $value)
            {
                $cols = explode('|', $value);

                if (!isset($cols[1]))
                {
                    continue;
                }

                if (isset($_GET['filter']))
                {
                    echo $cols[3];
                    if ($cols[3] == $_GET['filter'])
                    {
                        $sum = $sum + (double) $cols[2];

                        echo generateCostView($cols, $categories);
                    }
                }
                else
                {
                    $sum = $sum + (double) $cols[2];

                    echo generateCostView($cols, $categories);
                }
            }
        }

        echo '<tr class="info"><td><strong>Total Sum:</strong></td><td colspan="5" class="text-right">' . $sum . '</td></tr>';
        ?>
    </tbody>
</table>

<?php
include './includes/footer.php';
?>
