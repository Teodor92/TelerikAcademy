<?php

$first_num = htmlspecialchars(trim($_POST['first_num']));
$sign = htmlspecialchars(trim($_POST['sign']));
$second_num = htmlspecialchars(trim($_POST['second_num']));

if (is_numeric($first_num) && is_numeric($second_num)) {
    switch ($sign) {
        case '+': echo $first_num + $second_num;
            break;
        case '*': echo $first_num * $second_num;
            break;
        case '/': echo $first_num / $second_num;
            break;
        case '-': echo $first_num - $second_num;
            break;
        default: echo 'Wrong sign';
            break;
    }
}
?>
