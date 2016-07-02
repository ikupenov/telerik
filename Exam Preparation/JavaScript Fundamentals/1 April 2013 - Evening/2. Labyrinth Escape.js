function solve(params) {
    var size = params[0].split(' ').map(Number),
        rows = +size[0], cols = +size[1],
        startPos = params[1].split(' ').map(Number),
        currRow = +startPos[0], currCol = +startPos[1],
        field = [], i;

    for (i = 0; i < rows; i += 1) {
        field[i] = params[2 + i].split('');
    }

    function getPoints(currRow, currCol) {
        return (currRow * cols) + (currCol + 1);
    }

    var result = 0, 
        moves = 0,
        tempRow, tempCol;

    while (true) {
        if (currRow >= rows || currRow < 0 || currCol >= cols || currCol < 0) {
            console.log('out ' + result);
            break;
        }
        if (field[currRow][currCol] === 'v') {
            console.log('lost ' + moves);
            break;
        }

        result += getPoints(currRow, currCol);
        tempRow = currRow;
        tempCol = currCol;

        switch (field[currRow][currCol]) {
            case 'u': currRow -= 1; break;
            case 'l': currCol -= 1; break;
            case 'd': currRow += 1; break;
            case 'r': currCol += 1; break;
        }

        field[tempRow][tempCol] = 'v';
        moves += 1;
    }
}