function solve(params) {
    var n = parseInt(params[0]),
        k = parseInt(params[1]),
        numbers = params[2].split(' ').map(Number),
        result = [],        
        min, max;

    for (var i = 0; i <= n - k; i += 1) {
        min = numbers[i];
        max = numbers[i];
        
        for (var j = i; j < k + i; j += 1) {
            if (numbers[j] < min) {
                min = numbers[j];
            }
            if (numbers[j] > max) {
                max = numbers[j];
            }
        }

        result.push(min + max);
    }

    console.log(result.join(','));
}