function solve(args) {
    var a = parseFloat(args[0]);
    var b = parseFloat(args[1]);
    var h = parseFloat(args[2]);

    var area = ((a + b) / 2) * h;

    console.log(area.toFixed(7));
}