<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title></title>
    <link href="css/style.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <!-- Exercise 2 -->
    <h2>Hello world script.</h2>
    <div id="content">
        <?php
        echo 'Hello World!';
        ?>
    </div>

    <!-- Exercise 3 -->

    <h2>Number that divide by 3 and 7.</h2>
    <table>
        
        <thead>
            <tr>
                <th colspan="5">
                    Gime da numbars!
                </th>
            </tr>
        </thead>
        <tr>
            <?php
            for ($index = 1; $index < 1000; $index++) {
                if ($index % 21 === 0) {
                    echo '<td>' . $index . '</td>';
                }
                if ($index % 100 === 0) {
                    echo '</tr><tr>';
                }
            }
            ?>
        </tr<>
    </table>

    <!-- Exercise 4 -->

    <h2>Number calculator.</h2>
    <form method="POST" action="number_calculator.php" name="myForm" onsubmit="return validateForm();">
        <label for="first_num">Enter the first number:</label>
        <input type="number" name="first_num" id="first_num"/></br>
        <label for="sign" >Enter a mathematical sign:</label>
        <input type="text" name="sign" id="sign"/></br>
        <label for="second_num">Enter the second number:</label>
        <input type="number" name="second_num" id="second_num"/></br>
        <input type="submit" value="Click me!"/></br>
    </form>
    
    <script type="text/javascript" src="js/validation.js">
    </script>
</body>
</html>
