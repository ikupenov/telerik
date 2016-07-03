function solve(params) {
    var n = parseInt(params[0]),
        k = parseInt(params[1]),
        numbers = params[2].split(' ').map(Number),
        result = [];

    for (var i = 0; i <= n - k; i += 1) {
        result.push(Math.min.apply(null, numbers.slice(i, i + k)) +
            Math.max.apply(null, numbers.slice(i, i + k)));
    }

    console.log(result.join(','));
}