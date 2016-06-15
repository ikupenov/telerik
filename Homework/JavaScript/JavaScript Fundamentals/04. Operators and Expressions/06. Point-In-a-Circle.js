function solve(args) {
    var pointX = parseFloat(args[0]);
    var pointY = parseFloat(args[1]);

    var r = 2;
    var d = r * 2;

    //Center = K{0,0}
    var distance = Math.sqrt(Math.pow(pointX, 2) + Math.pow(pointY, 2));

    if (distance == r, distance < r) {
        console.log("yes " + distance.toFixed(2));
    }
    else {
        console.log("no " + distance.toFixed(2));
    }
}