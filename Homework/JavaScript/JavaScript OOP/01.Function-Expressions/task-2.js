function solve(start, end) {
    if (!start || !end) {
        throw 'Missing param';
    }

    if (isNaN(start) || isNaN(end)) {
        throw 'All arguments must be numbers';
    }

    var primeNumbers = [];
    var isPrime = false;

    for (var i = start; i < end; i += 1) {
        isPrime = false;

        for (var j = 2; j < i; j += 1) {
            if (i % j === 0) {
                isPrime = true;
                break;
            }
        }

        if (!isPrime) {
            primeNumbers.push(i);
        }
    }

    return primeNumbers;
}