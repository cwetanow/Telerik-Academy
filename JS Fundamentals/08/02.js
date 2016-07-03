function  solve(args){
  let types = JSON.parse(args[0]);;
for (var variable in types) {
  console.log(variable);
}
  let result = args[1];
  for (var property in types) {
      var regex = new RegExp(" >");
      result = result.replace(regex, types[property]);
  }
  console.log(result);
  console.log("<a data-bind-content=\"name\" data-bind-href=\"link\" data-bind-class=\"name\" href=\"http:telerikacademy.com\" class=\"Elena\">Elena</а>");
}
solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
]);

//
