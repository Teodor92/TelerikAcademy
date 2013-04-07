function Solve(args) {
    var N = parseFloat(args[0]);
    var M = parseFloat(args[1]);
    var P = parseFloat(args[2]);

    var result = (N * N + (1 / (M * P)) + 1337) / (N - 128.523123123 * P) + Math.sin(parseInt(M % 180));
    return result.toFixed(6)
}