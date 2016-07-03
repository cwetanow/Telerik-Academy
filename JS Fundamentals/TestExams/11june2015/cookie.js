function solve(args) {
    for (let i = 0; i < args.length; i += 1) {
        args[i] = args[i].replace(/:\s\s+/g, ": ");
        args[i] = args[i].replace(/{/g, " {");
    }
    let result = [args[0]];
    var brackets = 1;
    let k = 1;
    let property = result[0].replace(/{/, "");
    let oldProperty = "";
    let be = false;
    for (let i = 1; i < args.length; i += 1) {
        result[k] = "";
        if (args[i].includes("{")) {
            brackets += 1;
            oldProperty = property;
            property = args[i].replace("{", "");
            result[k] = "}";
            k += 1;
            if (brackets===1) {
              result[k] = property + "{";
              oldProperty="";
            } else {
              result[k] = oldProperty + property + "{";
            }

            k += 1;
            result[k - 1] = result[k - 1].replace(" $", "");
            be = true;
            continue;
        } else if (args[i].includes("}")) {
            brackets -= 1;
            continue;
        }
        if (result[k - 1] === "}") {
            continue;
        }
        for (var m = 0; m < brackets; m += 1) {
            result[k] = '  ';
        }
        if (be && args[i] === "}") {
            be = false;
            continue;
        }
        result[k] += args[i];
        k += 1;
    }
    result[k] = "}";
    console.log(result.join("\n"));
}
let test = ['#the-big-b{',
    'color:        big-yellow;',
    'size: big;',
    '.the-little-bs{',
    'color: yellow;',
    '}',
    '}',
    '.muppet{',
    'skin: fluffy;',
    '$.water-spirit{',
    'powers:all;',
    '}',
    '}'
];
solve(test);
