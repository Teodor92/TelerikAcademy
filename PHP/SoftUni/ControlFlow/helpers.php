<?php

function checkIfPointIsInCircle($point, $radius) {
    $distanceFormCenter = sqrt(pow($point->getX(), 2) + pow($point->getY(), 2));

    if ($distanceFormCenter <= $radius) {
        return true;
    } else {
        return false;
    }
}

function getUniqeWords($words) {
    $uniqeWords = array();
    $counter = 0;

    foreach ($words as $word) {
        if (!in_array($word, $uniqeWords)) {
            $uniqeWords[$counter] = $word;
            $counter++;
        }
    }
    
    return $uniqeWords;
}
