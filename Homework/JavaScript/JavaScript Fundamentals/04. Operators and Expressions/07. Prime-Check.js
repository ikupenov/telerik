function solve(args) {
    var number = args[0] | 0;
    var isPrime = true;

    if (number <= 0 || number === 1) {
        isPrime = false;
    }
    else {
        for (var i = 2; i <= Math.sqrt(number); i++) {
            if (number % i === 0) {
                isPrime = false;
                break;
            }
        }
    }

    console.log(isPrime);
}