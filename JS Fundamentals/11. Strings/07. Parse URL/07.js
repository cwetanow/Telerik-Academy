function solve(args){
  let protocol=args[0].match(/[a-z]+:\/\//)[0].replace("://","");
  let server=args[0].match(/\/[a-z]+.[a-z]+\//)[0].replace(/\//g,"");
  let resource=args[0].replace(protocol,"").replace(server,"").replace("://","");
  console.log("protocol: "+protocol);
  console.log("server: "+server);
  console.log("resource: "+resource);
}
solve([ 'http://telerikacademy.com/Courses/Courses/Details/239' ]);
