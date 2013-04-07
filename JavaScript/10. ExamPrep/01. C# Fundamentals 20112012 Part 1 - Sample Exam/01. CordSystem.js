function Solve(args) {
    var x = parseInt(args[0]);
    var y = parseInt(args[1]);
    if (x > 0 && y > 0) {
        return 1;
    }
    else if (x < 0 && y > 0) {
        return 2;
    }
    else if (x < 0 && y < 0) {
        return 3;
    }
    else if (x > 0 && y < 0) {
        return 4;
    }
    else if (x == 0 && y != 0) {
        return 5;
    }
    else if (y == 0 && x != 0) {
        return 6;
    }
    else //if (x == 0 && y == 0)
    {
        return 0;
    }
}