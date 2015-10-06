<?php
include './helpers.php';
include './point.php';
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Introduction to PHP</title>
        <link rel="stylesheet" href="styles/bootstrap.min.css"/>
        <link rel="stylesheet" href="styles/bootstrap-theme.min.css"/>
        <link rel="stylesheet" href="styles/style.css"/>
    </head>
    <body>
        <div class="container">
            <header>
                <h1>Introduction to PHP</h1>
                <hr />
            </header>
            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 1. Print current date</h2>
                </header>
                <div class="panel-body">
                    <?php
                    echo date("d M Y");
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 2. Type of variable</h2>
                </header>
                <div class="panel-body">

                    <?php
                    $simpleNumber = 11;
                    $simpleFolat = 11.5;
                    $simpleBoolean = true;
                    $simpleString = "I'm a string!";
                    $simpleArray = array("Lol", "I'm", "An", "array!");
                    $simpleObject = new ArrayObject();
                    ?>

                    <ul>
                        <li><?= gettype($simpleNumber) ?></li>
                        <li><?= gettype($simpleFolat) ?></li>
                        <li><?= gettype($simpleBoolean) ?></li>
                        <li><?= gettype($simpleString) ?></li>
                        <li><?= gettype($simpleArray) ?></li>
                        <li><?= gettype(null) ?></li>
                        <li><?= gettype($simpleObject) ?></li>
                    </ul>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 3. Rectangle Area</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $firstSide = 12;
                    $secondSide = 13;
                    $rectangleArea = $firstSide * $secondSide;
                    echo 'Rectangle area: ' . $rectangleArea;
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 4. Triangle Area</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $pointA = new Point(-5, 10);
                    $pointB = new Point(25, 30);
                    $pointC = new Point(60, 15);

                    $area = abs((
                            $pointA->getX() * ($pointB->getY() - $pointC->getY()) +
                            $pointB->getX() * ($pointC->getY() - $pointA->getY()) +
                            $pointC->getX() * ($pointA->getY() - $pointB->getY())) / 2);
                    echo 'The area is: ' . $area;
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 5. Boolean Variable</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $isFemale = false;
                    echo "I'm female? - " . getBooleanDisplayValue($isFemale);
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 6. Quotes in Strings</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $escapedQuotes = "I asked a girl out and she said – \"I don't know\". Does she mean yes or no?";
                    echo $escapedQuotes;
                    echo '</br>';
                    $quotedQuotes = 'I asked a girl out and she said – "I doDoes she mean yes or no?';
                    echo $quotedQuotes;
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 7. Type Casting</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $floatToCast = 123.56;
                    echo (int) $floatToCast;
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 8. Print Html</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $displayText = '<p>I love Software University<p>';
                    echo htmlspecialchars($displayText);
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 9. *Divide by 2 and 9</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $checkiingNumber = 72;
                    $isDividable = $checkiingNumber % 18 == 0; // if dividable on 18 it will be dividable on 2 and 9

                    echo 'The number is dividable by 2 and 9: ' . getBooleanDisplayValue($isDividable);
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 10. *Third Digit is 7?</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $targetNumber = 737;
                    $thirdDigitIsSeven = (($targetNumber / 100) % 10) == 7;
                    echo 'The third digit is 7: ' . getBooleanDisplayValue($thirdDigitIsSeven);
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 11. **Numbers from 1 to n</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $endNumber = 10;
                    for ($i = 1; $i < $endNumber + 1; $i++) {
                        printf("%d ", $i);
                    }
                    ?>
                </div>
            </section>

            <section class="panel panel-info top-buffer">
                <header class="panel-heading">
                    <h2>Problem 12. ***Fibonacci Numbers</h2>
                </header>
                <div class="panel-body">
                    <?php
                    $amountToFind = 20;
                    $firstNumber = 0;
                    $secondNumber = 1;

                    echo $secondNumber . ' ';

                    for ($index = 0; $index < $amountToFind; $index++) {
                        $newValue = $firstNumber + $secondNumber;
                        $firstNumber = $secondNumber;
                        $secondNumber = $newValue;
                        printf('%d ', $newValue);
                    }
                    ?>
                </div>
            </section>
        </div>
    </body>
</html>
