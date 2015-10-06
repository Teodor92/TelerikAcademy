<?php

function getLargestSequenceOfEqualStrings($input){
    $elementsArray = explode(" ", $input);
    $numberOfOccurrences = 1;
    $bestElement = "";
    $bestOccurrences = PHP_INT_MIN;
    $iterationCount = count($elementsArray) - 1;

    for ($i = 0; $i < $iterationCount; $i++) {
        if($elementsArray[$i] == $elementsArray[$i + 1]) {
            $numberOfOccurrences++;
        } else {
            if($numberOfOccurrences > $bestOccurrences) {
                $bestOccurrences = $numberOfOccurrences;
                $bestElement = $elementsArray[$i];
            }

            $numberOfOccurrences = 1;
        }
    }

    if($numberOfOccurrences > $bestOccurrences) {
        $bestOccurrences = $numberOfOccurrences;
        $bestElement = $elementsArray[$iterationCount];
    }

    return join(" ", array_fill(0, $bestOccurrences, $bestElement));
}

function getLongestIncreasingSequence ($input) {

    $output = "";
    $elements = explode(" ", $input);
    $iterationCount = count($elements) - 1;
    $longestCount = 1;
    $bestSequenceCount = PHP_INT_MIN;
    $bestSequence = "";
    $longestSequence = array_values($elements)[0];

    for ($i = 0; $i < $iterationCount; $i++) {
        if ($elements[$i] < $elements[$i + 1]) {
            $longestCount++;
            $longestSequence .= ' '.$elements[$i];
            $output = $output.' '.$elements[$i];
        } else {
            if ($longestCount > $bestSequenceCount) {
                $bestSequenceCount = $longestCount;
                $bestSequence = $longestSequence;
            }

            $longestCount = 1;
            $longestSequence = "";
            $output = $output.' '.$elements[$i];
            $output = $output.'<br />';
        }
    }

    if ($elements[$iterationCount - 1] < $elements[$iterationCount]) {
        $longestSequence .= ' '.$elements[$iterationCount];
        $output = $output.' '.$elements[$iterationCount];
    } else {
        if ($longestCount > $bestSequenceCount) {
            $bestSequence = $longestSequence;
        }

        $output = $output.' '.$elements[$iterationCount];
    }

    $output .= '<br />Longest: '.$bestSequence;

    return $output;
}

function selectionSort(array $arr) {
    $arrayCount = count($arr);

    for ($i = 0; $i < $arrayCount; ++$i) {
        $min = null;
        $minKey = null;
        for($j = $i; $j < $arrayCount; ++$j) {
            if (null === $min || $arr[$j] < $min) {
                $minKey = $j;
                $min = $arr[$j];
            }
        }

        $arr[$minKey] = $arr[$i];
        $arr[$i] = $min;
    }

    return $arr;
}