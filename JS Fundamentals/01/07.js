function solve(args) {
    var n = +args[0];

    function CheckPrime(n) {
        if (n < 2) {
            return false;
        }
        for (var i = 2; i <= Math.abs(n) / 2; i++) {
            if (n % i == 0) {
                return false;
            }
        }
        return true;
    }
    console.log(CheckPrime(n));
}
solve(['0']);
solve(['1']);
