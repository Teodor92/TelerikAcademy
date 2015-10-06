<?php

class Point {
    
    function __construct($pointX, $pointY) {
        $this->pointX = $pointX;
        $this->pointY = $pointY;
   }
    
    private $pointX;
    private $pointY;
    
    function getX() {
        return $this->pointX;
    }
    
    function getY() {
        return $this->pointY;
    }
}
