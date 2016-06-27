function ar(args){
  var n=+args[0];
  var result="";
  for (var j = 1; j <= n; j++) {
    result="";
    for (var i = j; i < n+j; i++) {
      result+=i.toString()+" ";
    }
    console.log(result);
  }

}
ar([3]);
