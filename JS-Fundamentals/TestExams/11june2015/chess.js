function solve(args) {

    let rows = +args[0];
    let cols = +args[1];
    let table = [];
    for (let i = 2; i < 2 + rows; i += 1) {
        table[i - 2] = args[i].split('');
    }

    let moves = [];
    let movesCount = +args[2 + rows];
    for (let i = 0; i < movesCount; i += 1) {
        moves[i] = args[i + 3 + rows].split(' ');
    }
    //works to here
    for (var i = 0; i < movesCount; i += 1) {
        for (var j = 0; j < moves[i].length; j += 1) {
            let temp = moves[i][j].charCodeAt(0) - 97;
            moves[i][j] = moves[i][j].split("");
            moves[i][j][0] = rows - (+moves[i][j][1]);
            moves[i][j][1] = temp;
        }
    }
    //still works
    let result = [];

    for (var i = 0; i < movesCount; i += 1) {
        let nRow = moves[i][0][0];
        let nCol = moves[i][0][1];
        let goRow = moves[i][1][0];
        let goCol = moves[i][1][1];
        if (table[goRow][goCol] != "-") {
            result[i] = "no";
        } else if (table[nRow][nCol] === "-") {
            result[i] = "no";
        } else if (table[nRow][nCol] === "K") {
            result[i] = checkKnight(nRow, nCol, goRow, goCol, table);
        } else {

            if ((goRow === nRow && goCol != nCol) || (goRow != nRow && goCol === nCol)) {

                result[i] = checkQueenStraight(nRow, nCol, goRow, goCol, table);
            } else if (Math.abs(nRow-goRow )===Math.abs(nCol-goCol)) {
                result[i] = checkQueenDiagonal(nRow, nCol, goRow, goCol, table);
            } else {
              result[i]="no";
            }
        }

    }
    for (var i = 0; i < result.length; i += 1) {
        console.log(result[i]);
    }

    function checkKnight(nowr, nowc, grow, gcol, tab) {
        if ((Math.abs(nowr - grow) === 2 && Math.abs(nowc - gcol) === 1) || (Math.abs(nowr - grow) === 1 && Math.abs(nowc - gcol) === 2)) {
            return "yes";
        }
        return "no";
    }

    function checkQueenStraight(nowr, nowc, grow, gcol, tab) {
        if (nowr === grow) {
            for (let i = Math.min(nowc, gcol) + 1; i < Math.max(nowc, gcol); i += 1) {
                if (tab[nowr][i] != "-") {
                    return "no";
                }
            }
            return "yes";
        } else {
            for (let i = Math.min(nowr, grow) + 1; i < Math.max(nowr, grow); i += 1) {
                if (tab[i][nowc] != "-") {
                    return "no";
                }
            }
            return "yes";
        }
    }

    function checkQueenDiagonal(nowr, nowc, grow, gcol, tab) {
        if (nowr < grow) {
            if (nowc < gcol) {
                for (var i = 1; i < Math.abs(nowr - grow); i += 1) {
                    if (tab[nowr + i][nowc + i] != "-") {
                        return "no";
                    }
                }
            } else {
                for (var i = 1; i < Math.abs(nowr - grow); i += 1) {
                    if (tab[nowr + i][nowc - i] != "-") {
                        return "no";
                    }
                }
            }
        } else {
            if (nowc < gcol) {
                for (var i = 1; i < Math.abs(nowr - grow); i += 1) {
                    if (tab[nowr - i][nowc + i] != "-") {
                        return "no";
                    }
                }
            } else {
                for (var i = 1; i < Math.abs(nowr - grow); i += 1) {
                    if (tab[nowr - i][nowc - i] != "-") {
                        return "no";
                    }
                }
            }
        }
        return "yes";
    }


}
let test = [
    '3',
    '4',
    '--K-',
    'K--K',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 c1',
    'd2 b1',
    'b1 b2',
    'c3 a3',
    'a2 a3',
    'd1 d3'
];
solve(test);
