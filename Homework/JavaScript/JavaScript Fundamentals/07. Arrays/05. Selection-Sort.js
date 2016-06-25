function solve(args) {
    var input = args[0].split("\n"),
        N = +input.shift(),
        smallestNumber,
        temp, pos, i, j;

    for (i = 0; i < N; i += 1) {
        smallestNumber = +input[i];
        pos = i;
        for (j = i + 1; j < N; j += 1) {
            if (+input[j] < smallestNumber) {
                smallestNumber = +input[j];
                pos = j;
            }
        }
        temp = +input[i];
        input[i] = smallestNumber;
        input[pos] = temp;
    }

    return input.join("\n");
}