function solve(args) {
    var govno = args[0].split("\n");
    var search = +govno[govno.length - 1];
    var array = [1];
    for (var i = 1; i < govno.length - 1; i++) {
        array[i - 1] = +govno[i];
    }
    var upperBound = array.length;
    var lowerBound = 1;
var govno=false;
    var midpoint = Math.floor(upperBound / 2);
    for (var i = 0; i < array.length; i += 1) {
        if (search < array[midpoint]) {
            upperBound = midpoint;
            midpoint = Math.floor(upperBound / 2);
        } else if (search > array[midpoint]) {
            lowerBound = midpoint;
            midpoint = Math.floor((lowerBound + upperBound) / 2);
        } else if (search === array[midpoint]) {
            //  midpoint = midpoint - 1;
            console.log(midpoint);

            break;
        }
    }
    if (!(search===array[midpoint])) {
        console.log('-1');
    }
}
solve(["10\n1\n2\n4\n8\n16\n31\n32\n64\n77\n99\n33"])
