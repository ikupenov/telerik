function solves(args) {
    var number = ((args[0] / 100) | 0) % 10;

    if (number === 7) {
        console.log("true");
    }
    else {
        console.log("false " + number);
    }
}