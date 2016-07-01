function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        table = [], currRow, currCol,
        toRow, toCol,
        i, j, move;

    //Fill Reversed
    for (i = rows - 1, j = 0;
        i >= 0;
        i -= 1, j += 1) {
        table[i] = params[j + 2].split('');
    }

    //Check if other figures are in the way
    function moveFigure(currRow, currCol, toRow, toCol) {
        var deltaX = currRow > toRow ? -1 : 1,
            deltaY = currCol > toCol ? -1 : 1,
            tempRow, tempCol;

        if (currRow === toRow) {
            for (tempCol = currCol + deltaY; tempCol !== toCol; tempCol += deltaY) {
                if (table[currRow][tempCol] !== '-') {
                    return 'no';
                }
            }
            return 'yes';
        }
        else if (currCol === toCol) {
            for (tempRow = currRow + deltaX; tempRow !== toRow; tempRow += deltaX) {
                if (table[tempRow][currCol] !== '-') {
                    return 'no';
                }
            }
            return 'yes';
        }
        else {
            if (Math.abs(currRow - toRow) !== Math.abs(currCol - toCol)) {
                return 'no';
            }
            for (tempRow = currRow + deltaX,
                tempCol = currCol + deltaY;
                tempRow !== toRow &&
                tempCol != toCol;
                tempRow += deltaX,
                tempCol += deltaY) {
                if (table[tempRow][tempCol] !== '-') {
                    return 'no';
                }
            }
            return 'yes';
        }
    }

    //Check if valid, if valid - call moveFigure
    function isValid(currRow, currCol, toRow, toCol) {
        if (table[toRow][toCol] !== '-') {
            return 'no';
        }
        switch (table[currRow][currCol]) {
            case 'R': return currRow != toRow && currCol != toCol ? 'no' : moveFigure(currRow, currCol, toRow, toCol);
            case 'B': return currRow == toRow || currCol === toCol ? 'no' : moveFigure(currRow, currCol, toRow, toCol);
            case 'Q': return moveFigure(currRow, currCol, toRow, toCol);
            default: return 'no';
        }
    }

    //StartUp
    for (i = 0; i < tests; i++) {
        move = params[rows + 3 + i];

        currRow = +move[1] - 1;
        currCol = +(move[0].charCodeAt(0) - 'a'.charCodeAt(0));

        toRow = +move[4] - 1;
        toCol = +(move[3].charCodeAt(0) - 'a'.charCodeAt(0));

        console.log(isValid(currRow, currCol, toRow, toCol));
    }
}