function fucn(args){
  var max=-Infinity;
  var min=Infinity;
  var sum=0;
  for (var i = 0; i < args.length; i++) {
    if (max<+args[i]) {
      max=+args[i];
    }
    if (min>+args[i]) {
      min=+args[i];
    }
    sum+=+args[i];

  }
  var avg=sum/args.length;
  console.log("min="+min.toFixed(2));
  console.log("max="+max.toFixed(2));
  console.log("sum="+sum.toFixed(2));
  console.log("avg="+avg.toFixed(2));
}
