function solve(args) {
    var input = args[0].split("\n"),
        N = +input.shift(),
        maxCounter = 1,
        counter,
        mostFreq,
        i, j;

    for (i = 0; i < N; i += 1) {
        counter = 1;

        if (+input[i] !== -1) {
            for (j = i + 1; j < N; j += 1) {
                if (+input[j] === +input[i]) {
                    counter += 1;
                    input[j] = -1;
                }
            }

            if (counter >= maxCounter) {
                maxCounter = counter;
                mostFreq = +input[i];
            }
        }
    }

    console.log(mostFreq + " (" + maxCounter + " times)");
}