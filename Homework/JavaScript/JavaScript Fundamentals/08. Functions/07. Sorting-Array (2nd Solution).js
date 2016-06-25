function sort(args) {
    var input = args[0].split('\n'),
    n = +input[0],
    numbers = input[1].split(' ').map(Number);
    
    numbers.sort(function(a, b) {
        return a - b;
    });

    return numbers.join(" ");
}