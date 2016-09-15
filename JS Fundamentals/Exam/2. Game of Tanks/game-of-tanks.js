function solve(args) {
    let dim = args[0].split(" ").map(Number);
    let rows = dim[0];
    let cols = dim[1];
    let field = [];
    let bombs = args[1].split(";");
    let koceto = 4;
    let cuki = 4;
    for (var i = 0; i < bombs.length; i += 1) {
        bombs[i] = bombs[i].split(" ").map(Number);
    }
    for (var i = 0; i < rows; i += 1) {
        field[i] = [];
        for (let j = 0; j < cols; j += 1) {

            for (let m = 0; m < bombs.length; m += 1) {
                if (i === bombs[m][0] && j === bombs[m][1]) {
                    field[i][j] = "b";
                }
            }
            if (field[i][j] != "b") {
                field[i][j] = "-";
            }

        }
    }
    for (var i = 0; i < 4; i += 1) {
        field[0][i] = i + "";
    }
    for (var i = 0; i < 4; i += 1) {
        field[rows - 1][cols - 1 - i] = i + 4 + "";
    }
    let deltas = [
            [-1, 0],
            [1, 0],
            [0, -1],
            [0, 1],
        ]
        //field populated, works to here

    for (var k = 3; k < args.length; k += 1) {
        let command = splitCommand(args[k]);
        //gets teh command, works to here
        let x = findTank(command[1], field, rows, cols)[0];
        let y = findTank(command[1], field, rows, cols)[1];
        if (command[0] === "mv") {
            let index = getIndex(command[3]);
            for (var l = 0; l < +command[2]; l += 1) {

                if (field[x + deltas[index][0]][y + deltas[index][1]] != "-") {
                    break;
                } else {
                    field[x + deltas[index][0]][y + deltas[index][1]] = command[1];
                    field[x][y] = "-";
                    x += deltas[index][0];
                    y += deltas[index][1];
                }
            }
        } else {
            let index = getIndex(command[2]);
            switch (index) {
                case 0:
                    for (var q = x - 1; q > -1; q -= 1) {
                        let pole = field[q][y];
                        if (pole != "-") {
                            if (pole != "b") {
                                if (+pole < 4) {
                                    koceto -= 1;
                                } else {
                                    cuki -= 1;
                                }
                                console.log("Tank " + pole + " is gg");
                            }
                            field[q][y] = "-";
                            break;
                        }
                    }
                    break;
                case 1:
                    for (var q = x + 1; q < rows; q += 1) {
                        let pole = field[q][y];
                        if (pole != "-") {
                            if (pole != "b") {
                                if (+pole < 4) {
                                    koceto -= 1;
                                } else {
                                    cuki -= 1;
                                }
                                console.log("Tank " + pole + " is gg");
                            }
                            field[q][y] = "-";
                            break;
                        }
                    }
                    break;
                case 2:
                    for (var q = y - 1; q > -1; q -= 1) {
                        let pole = field[x][q];
                        if (pole != "-") {
                            if (pole != "b") {
                                if (+pole < 4) {
                                    koceto -= 1;
                                } else {
                                    cuki -= 1;
                                }
                                console.log("Tank " + pole + " is gg");
                            }
                            field[x][q] = "-";
                            break;
                        }
                    }
                    break;
                default:
                    for (var q = y + 1; q < cols; q += 1) {
                        let pole = field[x][q];
                        if (pole != "-") {
                            if (pole != "b") {
                                if (+pole < 4) {

                                    koceto -= 1;

                                } else {

                                    cuki -= 1;

                                }
                                console.log("Tank " + pole + " is gg");
                            }
                            field[x][q] = "-";
                            break;
                        }
                    }
                    break;
            }


        }

    }
    if (koceto === 0) {
        console.log("Koceto is gg");
    } else if (cuki === 0) {
        console.log("Cuki is gg");
    }

    function getIndex(stringa) {
        switch (stringa) {
            case "u":
                return 0;
            case "d":
                return 1;
            case "l":
                return 2;
            default:
                return 3;
        }
    }

    function findTank(index, fld, r, c) {
        for (var i = 0; i < r; i += 1) {
            for (let j = 0; j < c; j += 1) {
                if (index === fld[i][j]) {
                    return [i, j];

                }
            }
        }
    }

    function splitCommand(stringa) {
        return stringa.split(" ");
    }



}
solve([
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 8 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
])
