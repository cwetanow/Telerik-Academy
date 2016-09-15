function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];
    var d= b*b-4*a*c;

    if (d<0) {
      console.log('no real roots');
    } else if (d===0) {
      var x=(-b/(2*a));
      console.log("x1=x2="+x.toFixed(2));
    } else {
      var x1=(-b+Math.sqrt(d))/(2*a);
      var x2=(-b-Math.sqrt(d))/(2*a);
      console.log("x1="+x2.toFixed(2)+"; x2="+x1.toFixed(2));
    }
}
