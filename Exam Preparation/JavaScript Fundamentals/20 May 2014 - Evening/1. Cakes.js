function solve(args) {
    var s = +args[0],
        c1 = +args[1],
        c2 = +args[2],
        c3 = +args[3],
        maxSum = 0,
        tempSum,
        i,
        j,
        k;

    for (i = 0; i < s / c1 + 1; i += 1) {
        for (j = 0; j < s / c2 + 1; j += 1) {
            for (k = 0; k < s / c3 + 1; k += 1) {

                tempSum = (c1 * i) + (c2 * j) + (c3 * k);

                if (tempSum > maxSum && tempSum <= s) {
                    maxSum = tempSum;
                }

                if (tempSum > s) {
                    break;
                }
            }
        }
    }

    console.log(maxSum);
}