function solve(args) {
    var n = +args[0],
        counter = 1,
        rows,
        cols;

    var arr = [[]];

    for (rows = 0; rows < n; rows += 1) {
            counter = rows + 1;
            arr[rows] = [];
        for (cols = 0; cols < n; cols += 1) {
            arr[rows][cols] = counter;
            counter += 1;
        }
    }

    var output = '';

    for (rows = 0; rows < n; rows += 1) {
        output = arr[rows][0];
        for (cols = 1; cols < n; cols += 1) {
            output += " " + arr[rows][cols]
        }
        console.log(output);
    }
}