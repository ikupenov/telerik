function solve(args) {
    var text = args[0],
        len = text.length,
        counter = 0;

    for (var i = 0; i < len; i += 1) {
        if (text[i] == '(') {
            counter += 1;
        }
        else if (text[i] == ')') {
            counter -= 1;
        }
    }

    if (counter === 0) {
        console.log("Correct");
    }
    else {
        console.log("Incorrect");
    }
}