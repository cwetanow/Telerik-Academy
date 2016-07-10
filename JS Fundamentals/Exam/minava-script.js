function solve(args) {
    for (var i = 0; i < args.length; i += 1) {
        args[i] = args[i].trim();
    }
    let temp = args.join(" ").replace(/} /g, "}\n").replace(/; /g, ";").split("\n");
    let len = temp.length;
    for (var i = 0; i < len; i += 1) {
        temp[i] = temp[i].split("; ");
        temp[i] = temp[i][0].split("{");
        temp[i][1] = temp[i][1].split(";");
        for (var j = 0; j < temp[i][1].length; j += 1) {
            temp[i][1][j] = temp[i][1][j].trim();
            if (temp[i][1][j].indexOf("@") != -1 && j > 0) {
                temp[i][1][j - 1] += " " + temp[i][1][j].replace(" }", "");

                temp[i][1].splice(j, 1);
            } else if (temp[i][1][j].indexOf("}") != -1) {
                temp[i][1].splice(j, 1);
            }
        }
    }
    for (var i = 0; i < len; i += 1) {
        for (var j = 0; j < temp[i][1].length; j += 1) {
            temp[i][1][j] = temp[i][1][j].trim();
            if (j > 0 && temp[i][1][j].indexOf(":") != -1) {
                temp[temp.length] = [temp[i][0], temp[i][1][j]];
                temp[i][1] = temp[i][1].splice(j - 1, 1);
            }
        }
    }
    //len = temp.length;
    for (var i = 0; i < temp.length; i += 1) {
        if (i < len) {
            temp[i][1] = temp[i][1][0].split(" ");
        } else {
            temp[i][1] = temp[i][1].split(" ");
        }
        temp[i][0] = temp[i][0].trim().split(" ");
    }
    //to here have all the props razdeleni one by one
    //and works!]
    let tag = "";
    let tagFat = "";
    let prop = "";
    let value = "";
    let fat = "";
    for (var i = 0; i < temp.length; i += 1) {
        if (temp[i][0].length > 1) {
            if (temp[i][0][0].indexOf("@") != -1) {
                tagFat = +(temp[i][0][0].replace("@", ""));
                tag = temp[i][0][1];
            } else {
                tagFat = +(temp[i][0][1].replace("@", ""));
                tag = temp[i][0][0];
            }
        } else {
            tag = temp[i][0][0];
        }
        if (temp[i][1].length > 2) {
            if (temp[i][1][0].indexOf("@") != -1) {
                fat = +temp[i][1][0].replace("@", "");
                prop = temp[i][1][1];
                value = temp[i][1][2];
            } else {
                fat = +temp[i][1][2].replace("@", "");
                prop = temp[i][1][0];
                value = temp[i][1][1];
            }
        }
        temp[i]={
          name:tag,
          tagfett:tagFat,
          prop:prop,
          val:value,
          fett:fat
        };
    }
    console.log(temp);

}
solve([
    'li {',
    '    font-size: 2px;',
    '    font-weight: bold;',
    '}',
    'div {',
    '    font-size: 20px; @5',
    '}',
    'div { @4',
    '    font-size: 17px;',
    '}',
    '@19',
    'li {',
    '    font-size: 42px;',
    '    color: red; @9',
    '}'
]);
