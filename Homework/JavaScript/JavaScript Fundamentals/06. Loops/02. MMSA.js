function solve(args) {
    var min = args[0],
        max = args[0],
        sum = 0,
        counter = 0,
        i;

    for (i = 0; !isNaN(args[i]); i += 1) {
        sum += +args[i];

        if (+args[i] > max) {
            max = +args[i];
        }

        if (+args[i] < min) {
            min = +args[i];
        }

        counter += 1;
    }

    console.log("min=" + min.toFixed(2));
    console.log("max=" + max.toFixed(2));
    console.log("sum=" + sum.toFixed(2));
    console.log("avg=" + (sum / counter).toFixed(2));
}