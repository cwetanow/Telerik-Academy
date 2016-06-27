function solve(args){
  var a=+args[0];
  a=Math.floor(a/100);

  if (a%10==7) {
      console.log(true);
  } else {
    console.log(false + ' '+a%10);
  }
}
