function solve(args) {
    var n = +args[0];
    var output = 1;

    for (var i = 2; i <= n; i++) {
        output += " " + i;
    }

    console.log(output);
}