function solve(params) {
    var n = parseInt(params[0]),
        arr = [],
        maxSum = +(params[1]),
        currSum = +(params[1]),
        i, j;

    for (i = 1; i <= n; i += 1) {
        arr.push(+params[i]);
    }

    for (i = 0; i <= n; i += 1) {
        currSum = 0;

        for (j = i; j <= n; j += 1) {
            currSum += arr[j];

            if (currSum > maxSum) {
                maxSum = currSum;
            }
        }
    }

    return maxSum;
}