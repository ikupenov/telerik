function solve(params) {
    "use strict";

    var s = params[0].split(' ').map(Number),
        peaks = [0],
        maxSum = -1;

    function isGreaterThanNeighbours(index, numbers) {
        return numbers[index] > numbers[index + 1] &&
            numbers[index] > numbers[index - 1];
    }

    for (let i = 1; i < s.length - 1; i += 1) {
        if (isGreaterThanNeighbours(i, s)) {
            peaks.push(i);
        }
    }
    peaks.push(s.length - 1);

    for (let i = 1; i < peaks.length; i += 1) {
        maxSum = Math.max(maxSum, peaks[i] - peaks[i - 1]);
    }

    console.log(maxSum);
}