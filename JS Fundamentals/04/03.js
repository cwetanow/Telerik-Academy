function solve(args) {
    var temp = args[0].split("\n");
    var currentMax = 1;
    var max = 1;

    for (var i = 0; i < temp.length - 1; i++) {

        if (temp[i] == temp[i + 1]) {
            currentMax++;
            if (currentMax > max) {
                max = currentMax;
            }
        } else {
            currentMax = 1;
        }
    }
    console.log(max);
}
