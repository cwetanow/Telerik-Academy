function solve(args) {
    var n = +args[0];
    var k = +args[1];
    var numbers = args[2].split(" ").map(Number);

    var results = [];
    var z = 0;

    for (var i = 0; i < n - k + 1; i += 1) {
        var temp = [];
        for (var j = 0; j < k; j += 1) {
            temp[j] = numbers[i + j];
        }
        results[z] = Math.max.apply(null, temp)+Math.min.apply(null, temp);
        z+=1;

    }
    console.log(results.join(", "));

}
solve(['4',
    '2',
    '1 3 1 8'
]);
//solve(['5',
//'3',
//'7 7 8 9 10'])
