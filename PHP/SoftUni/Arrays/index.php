<?php

define('PHP_INT_MIN', ~PHP_INT_MAX);

include "helpers.php";
?>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Arrays</title>
    <link rel="stylesheet" href="styles/bootstrap.min.css"/>
    <link rel="stylesheet" href="styles/bootstrap-theme.min.css"/>
    <link rel="stylesheet" href="styles/style.css"/>
</head>
<body>
<div class="container">
    <header>
        <h1>Arrays</h1>
    </header>
    <section class="panel panel-info top-buffer">
        <header class="panel-heading">
            <h2>Problem 1. Print array</h2>
        </header>
        <section class="panel-body">
            <?php
            $iniArray = array();

            for($i = 0; $i < 20; $i++){

                $iniArray[$i] = $i * 5;
            }

            foreach ($iniArray as $value) {
                echo $value.' ';
            }

            ?>
        </section>
    </section>

    <section class="panel panel-info top-buffer">
        <header class="panel-heading">
            <h2>Problem 2. Largest Sequence of Equal Strings</h2>
        </header>
        <section class="panel-body">
            <?php

            $rawInput = "1 2 3 4 5 6 7 8 9";
            echo getLargestSequenceOfEqualStrings($rawInput);

            ?>
        </section>
    </section>

    <section class="panel panel-info top-buffer">
        <header class="panel-heading">
            <h2>Problem 3. Longest Increasing Sequence</h2>
        </header>
        <section class="panel-body">
            <?php

            $input = "1 2 3 4 5 6 7 8 9";
            echo getLongestIncreasingSequence($input);
            ?>
        </section>
    </section>

    <section class="panel panel-info top-buffer">
        <header class="panel-heading">
            <h2>Problem 4. Selection Sort</h2>
        </header>
        <section class="panel-body">
            <?php

            echo join(" ", selectionSort(array(1, 13, 33, 44, 56, 1, 2, 312, 1, 123123)));

            ?>
        </section>
    </section>

    <section class="panel panel-info top-buffer">
        <header class="panel-heading">
            <h2>Problem 5.	Binary Search </h2>
        </header>
        <section class="panel-body">
            <?php

            echo join(" ", selectionSort(array(1, 13, 33, 44, 56, 1, 2, 312, 1, 123123)));

            ?>
        </section>
    </section>

    <section class="panel panel-info top-buffer">
        <header class="panel-heading">
            <h2>Problem 6.	**Simple calculator</h2>
        </header>
        <section class="panel-body">
            <?php
            ?>
        </section>
    </section>
</div>
</body>
</html>
