function solve(args) {
    var lines = [],
        xA, xB, yA, yB,
        distance,
        i;

    for (i = 0; i < 3; i += 1) {
        xA = +args[i * 4];
        xB = +args[i * 4 + 2];
        yA = +args[i * 4 + 1];
        yB = +args[i * 4 + 3];

        distance = Math.sqrt(Math.pow((xA - xB), 2) + Math.pow((yA - yB), 2)).toFixed(2);

        lines[i] = distance;
        console.log(distance);
    }

    lines = lines.map(Number);

    if (lines[0] + lines[1] > lines[2] && lines[0] + lines[2] > lines[1] && lines[1] + lines[2] > lines[0]) {
        return "Triangle can be built";
    }
    else {
        return "Triangle can not be built";
    }
}