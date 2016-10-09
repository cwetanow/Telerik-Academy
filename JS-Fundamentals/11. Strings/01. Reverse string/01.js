function solve(args) {
    var b = "";
    for (var i = args[0].length - 1; i > -1; i -= 1) {
        b+=args[0][i];
    }
    console.log(b);
}
solve(["sample"])
