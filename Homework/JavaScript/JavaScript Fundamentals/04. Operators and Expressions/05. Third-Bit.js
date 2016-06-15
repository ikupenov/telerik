function solve(args) {
    var number = args[0] | 0;

    var mask = 1 << 3;
    var nAndMask = number & mask;
    var result = nAndMask >> 3;

    console.log(result);
}