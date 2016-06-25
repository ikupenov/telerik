function appearanceCount(args) {
    var input = args[0].split("\n"),
        n = +input[0],
        numbers = input[1].split(" ").map(Number),
        x = +input[2],
        counter = 0,
        index;

    for (var i = 0; i < n; i += 1) {
        if (numbers[i] === x) {
            counter += 1;
        }
    }

    return counter;
}