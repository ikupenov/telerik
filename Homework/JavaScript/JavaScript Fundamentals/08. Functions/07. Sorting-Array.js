function solve(args) {
    var input = args[0].split("\n"),
        n = +input[0],
        numbers = input[1].split(" ").map(Number),
        result = [],
        biggestNumber, i;

    for (i = 0; i < n; i += 1) {
        biggestNumber = findBiggestNumber(numbers);
        result.unshift(biggestNumber);

        var index = numbers.indexOf(biggestNumber);
        numbers[index] = -1;
    }

    return result.join(" ");

    function findBiggestNumber(arr) {
        var biggest = +arr[0],
            length = arr.length,
            i;

        for (i = 0; i < length; i += 1) {
            if (+arr[i] > biggest) {
                biggest = +arr[i];
            }
        }

        return biggest;
    }
}