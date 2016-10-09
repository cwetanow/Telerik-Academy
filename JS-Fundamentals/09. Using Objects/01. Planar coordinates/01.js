function solve(args) {
    var temp = args.map(Number);
    var point1x = temp[2] - temp[0];
    var point1y = temp[3] - temp[1];
    var point2x = temp[6] - temp[4];
    var point2y = temp[7] - temp[5];
    var point3x = temp[10] - temp[8];
    var point3y = temp[11] - temp[9];
    var line1 = Math.sqrt(Math.pow(point1x, 2) + Math.pow(point1y, 2));
    var line2 = Math.sqrt(Math.pow(point2x, 2) + Math.pow(point2y, 2));
    var line3 = Math.sqrt(Math.pow(point3x, 2) + Math.pow(point3y, 2));
    console.log(line1.toFixed(2));
    console.log(line2.toFixed(2));
    console.log(line3.toFixed(2));
    if ((line1 + line2 > line3) && (line1 + line3 > line2) && (line3 + line2 > line1)) {
        console.log("Triangle can be built");
    } else {
      console.log("Triangle can not be built");
    }
}
var test = [
    '5', '6', '7', '8',
    '1', '2', '3', '4',
    '9', '10', '11', '12'
];
solve(test);
