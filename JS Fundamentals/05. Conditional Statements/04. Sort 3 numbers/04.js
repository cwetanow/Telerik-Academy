function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];
    if (a > b) {
        if (b > c) {
            console.log(a, b, c);
        } else if (a > c) {
            console.log(a, c, b);
        } else {
            console.log(c, a, b);
        }
    } else {
        if (b > c) {
            if (c > a) {
                console.log(b, c, a);
            } else {
                console.log(b, a, c);
            }

        } else {
          console.log(c,b,a);
        }
    }

}
