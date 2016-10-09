function solve(args) {
    //read input
    var rows = +args[0];
    var cols = +args[1];
    var table = [];
    for (var i = 0; i < rows; i += 1) {
        table[i] = args[2 + i].split('');
    }
    var instructions = +args[2 + rows];
    var moves = [];
    for (var i = 0; i < instructions; i += 1) {
        moves[i] = args[3 + rows + i].split(" ");
    }
    //change letters to numbers
    for (var i = 0; i < moves.length; i += 1) {
        moves[i][0] = (moves[i][0].charCodeAt(0) - 96) + moves[i][0][1];
        moves[i][1] = (moves[i][1].charCodeAt(0) - 96) + moves[i][1][1];
    }
    //works to here
    //do things
    var canHappen = [];
    for (var i = 0; i < instructions; i += 1) {
        var nowCol = (+moves[i][0][0]) - 1;
        var nowRow = rows - (+moves[i][0][1]);
        var goCol = (+moves[i][1][0]) - 1;
        var goRow = rows - (+moves[i][1][1]);
        if (table[goRow][goCol] != "-" || table[nowRow][nowCol] === "-") {
            canHappen[i] = 'no';

        } else if (table[nowRow][nowCol] === "R" && nowRow != goRow && nowCol != goCol) {

            canHappen[i] = "no";

        } else if (table[nowRow][nowCol] === "B" && (nowRow === goRow || nowCol == goCol)) {

            canHappen[i] = "no";

        } else {

            if (checkPath(nowRow, nowCol, goRow, goCol, table, table[nowRow][nowCol])) {
                canHappen[i] = "yes";
            } else {

                canHappen[i] = 'no';

            }

        }
    }

    function checkPath(isrow, iscol, goingr, goingc, array, peshka) {
        //this thing works
        if (peshka === "R") {
            if (isrow === goingr) {
                for (var i = Math.min(goingc, iscol) + 1; i < Math.max(goingc, iscol); i++) {
                    if (array[isrow][i] != "-") {
                        return false;
                    }
                }
            } else {
                for (var i = Math.min(isrow, goingr) + 1; i < Math.max(goingr, isrow); i++) {
                    if (array[i][iscol] != "-") {
                        return false;
                    }
                }
            }

        }
        //this no work :(
        if (peshka === "B") {
            //console.log(isrow,iscol,goingr,goingc);
            if (isrow > goingr) {

                if (iscol > goingc) {
                    for (var i = 1; i < iscol - goingc; i += 1) {
                        if (table[isrow - i][iscol - i] != "-") {
                            return false;
                        }
                    }
                } else {
                    for (var i = 1; i < goingc - iscol; i += 1) {
                        if (table[isrow - i][iscol + i] != "-") {
                            return false;
                        }
                    }
                }
            } else {

                if (iscol > goingc) {
                    for (var i = 1; i < iscol - goingc; i += 1) {
                        if (table[isrow + i][iscol - i] != "-") {
                            return false;
                        }
                    }
                } else {

                    for (var i = 1; i < goingc - iscol; i += 1) {

                        if (table[isrow + i][iscol + i] != "-") {
                            return false;
                        }
                    }
                }
            }

        }
        if (peshka === "Q") {
            //this also works
            if (isrow === goingr || iscol === goingc) {
                if (isrow === goingr) {

                    for (var i = Math.min(goingc, iscol) + 1; i < Math.max(goingc, iscol); i++) {
                        if (array[isrow][i] != "-") {

                            return false;
                        }
                    }
                } else {

                    for (var i = Math.min(isrow, goingr) + 1; i < Math.max(goingr, isrow); i++) {
                        if (array[i][iscol] != "-") {

                            return false;
                        }
                    }
                }
            } else {
                //this is fcked up :/
                if (isrow > goingr) {

                    if (iscol > goingc) {
                        for (var i = 1; i < iscol - goingc; i += 1) {
                            if (table[isrow - i][iscol - i] != "-") {
                                return false;
                            }
                        }
                    } else {
                        for (var i = 1; i < goingc - iscol; i += 1) {
                            if (table[isrow - i][iscol + i] != "-") {
                                return false;
                            }
                        }
                    }
                } else {

                    if (iscol > goingc) {
                        for (var i = 1; i < iscol - goingc; i += 1) {
                            if (table[isrow + i][iscol - i] != "-") {
                                return false;
                            }
                        }
                    } else {

                        for (var i = 1; i < goingc - iscol; i += 1) {

                            if (table[isrow + i][iscol + i] != "-") {
                                return false;
                            }
                        }
                    }
                }

            }

        }

        return true;
    }

    //print stuff
    console.log(canHappen.join("\n"));
}

var test = [
    '5',
    '5',
    'Q---Q',
    '-----',
    '-B---',
    '--R--',
    'Q---Q',
    '1',
    'b3 d1'

];
solve(test);
