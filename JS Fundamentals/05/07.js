function solve(args) {
  console.log(args[1]);
    temp = args[1].split(" ").map(Number);
    var result = [];
    var k = 0;
    var tempMin;
    for (var i = 0; i < temp.length; i += 1) {
        var min = Infinity;
        var n = -1;
        for (var j = 0; j < temp.length; j += 1) {
            if (temp[j] < min) {
                min = temp[j];
                n = j;
            }
        }
        result[k] = min;
        k += 1;
        temp[n] = Infinity;
    }
    console.log(result.join(" "));
}
