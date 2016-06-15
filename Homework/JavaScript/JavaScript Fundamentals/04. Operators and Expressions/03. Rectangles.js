function solve(args) {
	var width = +args[0];
	var height = +args[1];
    
    var P = 2 * (width + height);
    var S = width * height;

    console.log(S.toFixed(2) + " " + P.toFixed(2));
}