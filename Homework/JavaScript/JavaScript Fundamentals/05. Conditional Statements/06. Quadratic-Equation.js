function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2];

    var D = Math.pow(b, 2) - (4 * a * c);

    if (D < 0) {
        console.log("no real roots");
    }
    else {
        D = Math.sqrt(D);
        var x1 = (-b + D) / (2 * a);
        var x2 = (-b - D) / (2 * a);

        if (x1 === x2) {
            console.log("x1=x2=" + x1.toFixed(2));
        }
        else {
            console.log("x1=" + x2.toFixed(2) + "; x2=" + x1.toFixed(2));
        }
    }
}