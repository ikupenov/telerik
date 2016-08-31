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

    // var sum = 0;

    // for (var i = 0; i < arr.length; i += 1) {
    //     arr[i] = +arr[i];

    //     if (typeof arr[i] !== 'number') {
    //         throw 'All elements must be numbers';
    //     } 

    //     sum += arr[i];
    // }

    return sum;
}