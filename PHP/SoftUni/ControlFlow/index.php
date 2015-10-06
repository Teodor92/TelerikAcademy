<?php
include './point.php';
include './helpers.php';
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Control Flow</title>
        <link rel="stylesheet" href="styles/bootstrap.min.css"/>
        <link rel="stylesheet" href="styles/bootstrap-theme.min.css"/>
        <link rel="stylesheet" href="styles/style.css"/>
    </head>
    <body>
        <div class="container">
            <header>
                <h1>Control Flow</h1>
                <hr />
            </header>
            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 1. Exchange value</h2>
                </header>
                <section class="panel-body">

                    <?php
                    $firstValue = 10;
                    $secondValue = 5;

                    if ($firstValue > $secondValue) {
                        $oldValue = $firstValue;
                        $firstValue = $secondValue;
                        $secondValue = $oldValue;

                        echo 'Switched!';
                    }

                    echo $firstValue;
                    echo $secondValue;
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 2. Show sign</h2>
                </header>
                <section class="panel-body">
                    <?php
                    $firstSignedVariable = 10;
                    $secondSignedVariable = -10;
                    $thirdSignedVaribale = -10;
                    $signCounter = 0;
                    $zeroFound = false;

                    if ($firstSignedVariable == 0 || $secondSignedVariable == 0 || $thirdSignedVaribale == 0) {
                        $zeroFound = true;
                    }

                    if ($zeroFound) {
                        echo 'The product is zero';
                    } else {
                        if ($firstSignedVariable > 0) {
                            $signCounter++;
                        } else {
                            $signCounter--;
                        }

                        if ($secondSignedVariable > 0) {
                            $signCounter++;
                        } else {
                            $signCounter--;
                        }

                        if ($thirdSignedVaribale > 0) {
                            $signCounter++;
                        } else {
                            $signCounter--;
                        }

                        if ($signCounter % 2 == 0) {
                            echo 'The product is negative!';
                        } else {
                            echo 'The product is positive!';
                        }
                    }
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 3. Sort numbers</h2>
                </header>
                <section class="panel-body">
                    <?php
                    $myNumbers = array(33.2, 313, 11);
                    sort($myNumbers);

                    foreach ($myNumbers as $number) {
                        echo $number . ' ';
                    }
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 4. Point in a Circle</h2>
                </header>
                <section class="panel-body">
                    <?php
                    $myPoint = new Point(2, 2);

                    if (checkIfPointIsInCircle($myPoint, 2)) {
                        echo 'Point with coords [' . $myPoint->getX() . ',' . $myPoint->getY() . '] is in the circle';
                    } else {
                        echo 'Point with coords [' . $myPoint->getX() . ',' . $myPoint->getY() . '] is NOT in the circle';
                    }
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 5. Matrix of Numbers</h2>
                </header>
                <section class="panel-body">
                    <table class="table table-bordered table-striped table-hover">
                        <?php
                        $n = 7;
                        for ($i = 1; $i < $n + 1; $i++) {
                            echo '<tr>';
                            for ($j = $i; $j < $i + $n; $j++) {
                                echo '<td>' . $j . '</td>';
                            }

                            echo '</tr>';
                        }
                        ?>
                    </table>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 6. Odd and Even Product</h2>
                </header>
                <section class="panel-body">
                    <?php
                    $rawInput = "3 10 4 6 5 1";
                    $numbers = explode(" ", $rawInput);
                    $oddSum = 1;
                    $evenSum = 1;

                    for ($index = 0; $index < count($numbers); $index++) {
                        if (($index + 1) % 2 == 0) {
                            $evenSum *= $numbers[$index];
                        } else {
                            $oddSum *= $numbers[$index];
                        }
                    }

                    if ($oddSum == $evenSum) {
                        echo 'yes <br />';
                        echo 'product = ' . $oddSum;
                    } else {
                        echo 'no <br />';
                        echo 'odd_product = ' . $oddSum . '<br />';
                        echo 'even_product = ' . $evenSum . '<br />';
                    }
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 7. TOTO</h2>
                </header>
                <section class="panel-body">
                    <?php
                    echo 'Read comment in code.';
                    // The total of 6/49 combinations is HUGE - if you run this it will be VERY slow
//                    for ($i1 = 1; $i1 <= 44; $i1++) {
//                        for ($i2 = $i1 + 1; i2 <= 45; $i2++) {
//                            for ($i3 = $i2 + 1; $i3 <= 46; $i3++) {
//                                for ($i4 = $i3 + 1; $i4 <= 47; $i4++) {
//                                    for ($i5 = $i4 + 1; $i5 <= 48; $i5++) {
//                                        for ($i6 = $i5 + 1; $i6 <= 49; $i6++) {
//                                            echo $i1 . ' ' . $i2 . ' ' . $i3 . ' ' . $i4 . ' ' . $i4 . ' ' . $i5 . ' ' . $i6 . '<br />';
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 8. Print Prime Numbers</h2>
                </header>
                <section class="panel-body">
                    <?php
                    $endNumber = 150;

                    for ($j = 2; $j <= $endNumber; $j++) {
                        for ($k = 2; $k < $j; $k++) {
                            if ($j % $k == 0) {
                                break;
                            }
                        }
                        if ($k == $j) {
                            echo 'Prime: ', $j, '<br>';
                        }
                    }
                    ?>
                </section>
            </section>

            <section class="panel panel-info">
                <header class="panel-heading">
                    <h2>Problem 9. Extract words</h2>
                </header>
                <section class="panel-body">
<?php
$rawWords = array(
    "Nakov",
    "Svetlin",
    "Nakov",
    "Pesho",
    "Mario",
    "Dimityr",
    "Georgi",
    "Mario"
);

$uniqeWords = getUniqeWords($rawWords);

foreach ($uniqeWords as $word) {
    echo $word . '<br />';
}
?>
                </section>
            </section>
        </div>
    </body>
</html>
