function solve(args) {
    let heights = args[0].split(' ').map(Number);

    function isGreaterThanNeighbours(index, numbers) {
        return numbers[index] > numbers[index + 1] &&
            numbers[index] > numbers[index - 1];
    }

    let peaks = [0];
    for (let i = 1; i < heights.length - 1; i += 1) {
        if (isGreaterThanNeighbours(i, heights)) {
            peaks.push(i);
        }
    }
    peaks.push(heights.length - 1);

    let currSum = 0;
    let maxSum = heights[0];

    for (let i = 0; i < peaks.length - 1; i += 1) {
        currSum = 0;
        
        for (let j = peaks[i]; j <= peaks[i + 1]; j += 1) {
            currSum += heights[j];
        }

        if (currSum > maxSum) {
            maxSum = currSum;
        }
    }

    console.log(maxSum);
}