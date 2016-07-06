function solve(args) {
    var xWord = args[0].toLowerCase(),
        text = args[1].toLowerCase(),
        index = text.indexOf(xWord),
        counter = 0;

    while (true) {
        if (index >= 0) {
            counter += 1;
        }
        else {
            break;
        }

        index = text.indexOf(xWord, index + 1);
    }

    console.log(counter);
}