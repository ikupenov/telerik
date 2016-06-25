function solve(args) {
    var input = args[0].split("\n"),
        N = +input.shift(),
        X = +input.pop(),
        min = 0,
        max = N - 1,
        mid;

    while (true) {
        mid = ((min + max) / 2) | 0;

        if (max < min) {
            return -1;
        }
        else if (+input[mid] === X) {
            return mid;
        }
        else {
            if (+input[mid] < X) {
                min = mid + 1;
            }
            else if (+input[mid] > X) {
                max = mid - 1;
            }
        }
    }
}