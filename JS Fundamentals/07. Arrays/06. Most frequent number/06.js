function solve(args) {
    var arr = args[0].split("\n");
    var n = +arr[0];
    var currentTimes = 0;
    var times = 1;
    var number = +arr[2];
    for (var i = 1; i < arr.length; i+=1) {
        for (var j = i; j < arr.length; j+=1) {
            if (arr[i] === arr[j]) {
                currentTimes+=1;
            }
        }
        if (currentTimes > times) {
            times = currentTimes;
            number = +arr[i];
        }
        currentTimes = 0;
    }
    console.log(number + " (" + times + " times)");
}
