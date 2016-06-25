function solve(args) {
    var input = args[0].split("\n"),
        n = +input[0],
        numbers = input[1].split(" ").map(Number),
        counter = 0,
        i;

    for (i = 1, n -= 1; i < n; i += 1) {
        if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]) {
            counter += 1;
            i += 1;
        }
    }

    return counter;
}