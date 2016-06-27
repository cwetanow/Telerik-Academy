function solve(args) {
    var n = +args[0];
    for (var i = n; i>3; i-=1) {
      if (chechPrime(i)) {
        console.log(i);
        break;
      }
    }


    function chechPrime(a) {
        for (var i = 2; i <= Math.sqrt(a); i++) {
            if (a % i === 0) {
                return false;
            }
        }
        return true;
    }
}
