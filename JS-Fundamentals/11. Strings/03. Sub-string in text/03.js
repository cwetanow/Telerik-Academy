function thing(things) {
  var searched=things[0].toLowerCase();
  var input=things[1].toLowerCase();
  let k=0;
  let index=input.indexOf(searched);
  while (index>=0) {
    index=input.indexOf(searched,index+1);
    k+=1;
  }
  console.log(k);
}
let test=[
    'in',
    'We are living in an yellow submarine.'
];
thing(test);
