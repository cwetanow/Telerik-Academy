function func(args){
  var result="";
  for (var i = 1; i <= +args[0]; i++) {
    result+=i.toString()+" ";
  }
console.log(result);
}
