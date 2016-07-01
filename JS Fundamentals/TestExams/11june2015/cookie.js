function solve(args) {
    let result = [];
    let k=0;
    let property = '';
    let oldProperty="";
    for (let i = 0; i < args.length; i += 1) {
        args[i] = args[i].replace(/:\s\s+/g, ": ");
        args[i] = args[i].replace(/{/g, " {")
    }
    for (let i = 0; i < args.length; i += 1) {
        result[k] = args[i];
        k+=1;
        if (args[i].includes("{")) {
            oldProperty=property;
            property = args[i].replace("{", "");
        }
        console.log(property);
        console.log(oldProperty);
    }
    console.log("");
    console.log(result);
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
