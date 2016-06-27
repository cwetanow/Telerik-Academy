function solve(args) {
    var temp = args[0].split("\n");
    var result = [];
    var k = 0;
    var tempMin;

    for (var i = 1; i < temp.length; i++) {
        temp[i] = +temp[i];
    }
    for (var i = 1; i < temp.length; i += 1) {
        var min = Infinity;
        var n=-1;
        for (var j = 1; j < temp.length; j += 1) {
            if (temp[j] < min) {
                min = temp[j];
                n=j;
            }
        }
        result[k]=min;
        k+=1;
        temp[n]=Infinity;

    }
    var b=result.join("\n");
    console.log(b);

}
