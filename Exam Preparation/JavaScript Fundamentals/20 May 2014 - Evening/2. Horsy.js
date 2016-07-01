function solve(params) {
    var size = params[0].split(' ').map(Number),
        rows = +size[0], 
        cols = +size[1],
        currRow = rows - 1,
        currCol = cols - 1,
        field = [],
        result = 0,
        moves = 0, i;

    //Fill
    for (i = 0; i < rows; i += 1) {
        field[i] = params[i + 1].split('').map(Number);
    }

    function getPoints(currRow, currCol) {
        return Math.pow(2, currRow) - currCol;
    }

    while (true) {
        result += getPoints(currRow, currCol);
        tempRow = currRow;
        tempCol = currCol;

        switch (field[currRow][currCol]) {
            case 1: currRow -= 2; currCol += 1; break;
            case 2: currRow -= 1; currCol += 2; break;
            case 3: currRow += 1; currCol += 2; break;
            case 4: currRow += 2; currCol += 1; break;
            case 5: currRow += 2; currCol -= 1; break;
            case 6: currRow += 1; currCol -= 2; break;
            case 7: currRow -= 1; currCol -= 2; break;
            case 8: currRow -= 2; currCol -= 1; break;
        }

        field[tempRow][tempCol] = 0;
        moves += 1;

        if (currRow >= rows || currRow < 0 || currCol >= cols || currCol < 0) {
            console.log('Go go Horsy! Collected ' + result + ' weeds');
            break;
        }
        if (field[currRow][currCol] === 0) {
            console.log('Sadly the horse is doomed in ' + moves + ' jumps');
            break;
        }
    }
}