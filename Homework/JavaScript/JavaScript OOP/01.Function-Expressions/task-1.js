function sum(arr) {
    if (!arr) {
        throw 'Parameter is not passed';
    } else if (!arr.length) {
        return null;
    } else {
        var isNonNumber = arr.some((el) => isNaN(el));

        if (isNonNumber) {
            throw 'All arguments must be numbers';
        }
    }

    var sum = arr.map(Number).reduce((a, b) => a + b, 0);

    return sum;
}