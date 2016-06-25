function solve(args) {
    var input = args[0].split("\n"),
        n = +input[0],
        numbers = input[1].split(" ").map(Number),
        i;

    for (i = 1, n -= 1; i < n; i += 1) {
        if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]) {
            return i;
        }
    }

    return -1;
}