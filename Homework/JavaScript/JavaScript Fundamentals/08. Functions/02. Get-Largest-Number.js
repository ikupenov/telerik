function GetMax(input) {
    var numbers = input[0].split(' ');
    return (Math.max(+numbers[0], Math.max(+numbers[1], +numbers[2])));
}