function Solve(args) {
    var number1 = parseInt(args[0]);
    var number2 = parseInt(args[1]);
    var number3 = parseInt(args[2]);
    var number4 = parseInt(args[3]);
    var number5 = parseInt(args[4]);

    var max = 970200;
    var i = 0;

    for (i = 1; i <= max; i++) {
        if ((i % number1 == 0 && i % number2 == 0 && i % number3 == 0) ||
            (i % number1 == 0 && i % number2 == 0 && i % number4 == 0) ||
            (i % number1 == 0 && i % number2 == 0 && i % number5 == 0) ||
            (i % number1 == 0 && i % number3 == 0 && i % number4 == 0) ||
            (i % number1 == 0 && i % number3 == 0 && i % number5 == 0) ||
            (i % number1 == 0 && i % number4 == 0 && i % number5 == 0) ||
            (i % number2 == 0 && i % number3 == 0 && i % number4 == 0) ||
            (i % number2 == 0 && i % number3 == 0 && i % number5 == 0) ||
            (i % number2 == 0 && i % number4 == 0 && i % number5 == 0) ||
            (i % number3 == 0 && i % number4 == 0 && i % number5 == 0)) {
            return i;
        }
    }
}