function solve(params) {
    let size = params[0].split(' ').map(Number),
        debrisCoords = params[1].split(';'),
        n = +params[2],
        field = [],
        tanks = {};

    let rows = size[0], 
        cols = size[1];
        
    let counter = 0;

    function changeDirection(direction) {
        let deltaX, deltaY;
        switch (direction) {
            case 'u': deltaX = -1; deltaY = 0; break;
            case 'r': deltaX = 0; deltaY = 1; break;
            case 'd': deltaX = 1; deltaY = 0; break;
            case 'l': deltaX = 0; deltaY = -1; break;
        }

        return {
            deltaRow: deltaX,
            deltaCow: deltaY
        };
    }

    //SHOOT
    function shoot(field, tankID, direction, playersTanks) {
        let delta = changeDirection(direction);
        let deltaX = delta.deltaRow;
        let deltaY = delta.deltaCow;

        let currBulletRow = tanks[tankID].currRow,
            currBulletCol = tanks[tankID].currCol;

        while (true) {
            currBulletRow += deltaX;
            currBulletCol += deltaY;

            if (currBulletRow >= rows || currBulletRow < 0 ||
                currBulletCol >= cols || currBulletCol < 0) {
                break;
            }
            else if (field[currBulletRow][currBulletCol] === 'D') {
                field[currBulletRow][currBulletCol] = '-';
                break;
            }
            else if (field[currBulletRow][currBulletCol] !== '-') {
                let tankToDestroyID = field[currBulletRow][currBulletCol];

                if (parseInt(tankToDestroyID) >= 0 && parseInt(tankToDestroyID) <= 3) {
                    playersTanks[1] -= 1;
                }
                else if (parseInt(tankToDestroyID) >= 4 && parseInt(tankToDestroyID) <= 7) {
                    playersTanks[0] -= 1;
                }

                field[currBulletRow][currBulletCol] = '-';
                console.log('Tank ' + tankToDestroyID + ' is gg');
                break;
            }
        }
    }
    //---SHOOT

    //MOVE
    function moveTank(field, tankID, direction, numberOfMoves) {
        let delta = changeDirection(direction);

        let deltaX = delta.deltaRow,
            deltaY = delta.deltaCow;

        let currTankRow = tanks[tankID].currRow,
            currTankCol = tanks[tankID].currCol;

        for (let i = 0; i < numberOfMoves; i += 1) {
            if (field[currTankRow + deltaX][currTankCol + deltaY] !== '-' ||
                currTankRow + deltaX >= rows || currTankRow + deltaX < 0 ||
                currTankCol + deltaY >= cols || currTankCol + deltaY < 0) {
                break;
            }

            currTankRow += deltaX;
            currTankCol += deltaY;
        }

        tanks[tankID].currRow = currTankRow;
        tanks[tankID].currCol = currTankCol;
    }
    //---MOVE

    //Initializing Array
    //Koceto's tanks
    for (let i = 0; i < rows; i += 1) {
        field[i] = [];
        for (let j = 0; j < cols; j += 1) {
            if (i === 0 && j < 4) {
                field[i][j] = counter.toString();

                tanks[counter.toString()] = {
                    id: counter.toString(),
                    currRow: i,
                    currCol: j
                };
                counter += 1;
            }
            else {
                field[i][j] = '-';
            }
        }
    }
    //Cuki's tanks
    for (let j = cols - 1; counter < 8; j -= 1) {
        field[rows - 1][j] = counter.toString();

        tanks[counter.toString()] = {
            id: counter.toString(),
            currRow: rows - 1,
            currCol: j
        };
        counter += 1;
    }

    for (let i = 0; i < debrisCoords.length; i += 1) {
        let debrisSplit = debrisCoords[i].split(' ');
        field[+debrisSplit[0]][+debrisSplit[1]] = 'D';
    }
    //---Initializing Array

    //COMMANDS
    let playersTanks = [4, 4];
    let command, tankAction, tankID, direction, tankMoves;

    for (let i = 0; i <= n; i += 1) {
        command = params[3 + i].split(' ');

        tankAction = command[0];
        tankID = command[1];

        if (tankAction === 'mv') {
            tankMoves = +command[2];
            direction = command[3];

            let currTankRow = tanks[tankID].currRow;
            let currTankCol = tanks[tankID].currCol;
            field[currTankRow][currTankCol] = '-';

            moveTank(field, tankID, direction, tankMoves);

            let newTankRow = tanks[tankID].currRow;
            let newTankCol = tanks[tankID].currCol;
            field[newTankRow][newTankCol] = tanks[tankID].id;
        }
        else if (tankAction === 'x') {
            tankMoves = 'none';
            direction = command[2];

            shoot(field, tankID, direction, playersTanks);
        }

        if (playersTanks[0] === 0) {
            console.log('Cuki is gg');
            break;
        }
        else if (playersTanks[1] === 0) {
            console.log('Koceto is gg');
            break;
        }
    }
}