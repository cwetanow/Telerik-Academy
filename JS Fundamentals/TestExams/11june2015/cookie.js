function solve(args) {


    for (let i = 0; i < args.length; i += 1) {
        args[i] = args[i].replace(/:\s\s+/g, ": ");
        args[i] = args[i].replace(/{/g, " {");
    }
    let result = [args[0]];
    console.log(result);

    let k = 1;
    let property = result[0].replace(/{/,"");
    let oldProperty = "";
    for (let i = 1; i < args.length; i += 1) {

        if (args[i].includes("{")) {
            oldProperty = property;
            property = args[i].replace("{", "");
            result[k] = "}";
            k += 1;
            result[k] = oldProperty + property+"{";
            k += 1;
            continue;
        }
        if (result[k-1]==="}") {
          continue;
        }
        result[k] = args[i];
        k += 1;
    }
    console.log("");
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
