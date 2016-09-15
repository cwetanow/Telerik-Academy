function solve(args) {
    var x =+ args[0],
        y =+ args[1];

    function calculateDistane(x, y) {

        return Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));

    }
    var distance = calculateDistane(x, y);
    if (distance <= 2) {
        console.log('yes ' + distance.toFixed(2));
    } else {
        console.log('no ' + distance.toFixed(2));
    }
}
solve([-1,2]);
