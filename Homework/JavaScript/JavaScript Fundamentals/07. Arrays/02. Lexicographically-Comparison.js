function solve(args) {
    var arr = args[0].split("\n");
        firstArr = arr[0],
        secondArr = arr[1];

    if (firstArr > secondArr) {
        console.log(">");
    } 
    else if (secondArr > firstArr) {
        console.log("<");
    } 
    else {
        console.log("=");
    }
}