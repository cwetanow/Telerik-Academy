function solve(args) {
  var temp=args;

  var remove = args[0];

  var result=[];
  var k=0;
  for (var i = 0; i < temp.length; i++) {
    if (temp[i]!=remove) {
      result[k]=temp[i];
      k+=1;
    }
  }
  console.log(result.join("\n"));
}
solve([ '1', '2', '3', '2', '1', '2', '3', '2' ]);
