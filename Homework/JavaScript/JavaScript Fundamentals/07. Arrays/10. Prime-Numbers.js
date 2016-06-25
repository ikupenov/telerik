function solve(args) {
    var N = +args[0],
        isPrime,
        i, j;

    for (i = N; i >= 0; i -= 1) {
        isPrime = true;

        for (j = 2; j <= Math.sqrt(i); j += 1) {
            if (i % j === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime === true) {
            return i;
        }
    }
}