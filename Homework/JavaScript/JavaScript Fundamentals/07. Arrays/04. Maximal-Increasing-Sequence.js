function solve(args) {
    var input = args[0].split("\n"),
        N = +input[0],
        maxCounter = 1,
        counter = 1,
        i;

    for (i = 1; i < N; i += 1) {
        if (+input[i] < +input[i + 1]) {
            counter += 1;
        }
        else {
            counter = 1;
        }

        if (counter > maxCounter) {
            maxCounter = counter;
        }
    }

    console.log(maxCounter);
}