function solve(args) {
    var number = args[0] | 0;

    if (number % 2 === 0) {
        console.log("even" + " " + number);
    }
    else {
        // console.log("odd" + " " + number);
        console.log(`odd ${number}`);
    }
}