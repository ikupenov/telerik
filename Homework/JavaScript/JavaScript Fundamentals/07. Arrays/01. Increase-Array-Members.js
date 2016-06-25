function solve(args) {
    var i, j,
        arrLength,
        arr = [],
        multiplier = 5,
        length = args[0];

    for (i = 0; i < length; i += 1) {
        arr[i] = i * multiplier;
    }

    for (j = 0, arrLength = arr.length; j < arrLength; j++) {
        console.log(arr[j]);
    }
}