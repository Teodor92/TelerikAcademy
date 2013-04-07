function Solve(args) {
    var n = parseInt(args[0]);
    var endNumber = 0;

    for (var i = 0; i < n; i++) {
        var index = i + 1;
        var number = parseInt(args[index]);
        endNumber ^= number;
    }

    return endNumber;
}