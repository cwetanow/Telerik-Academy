function solve(args){
  var reg=/<.*?>/ig;
  for (var i = 0; i < args.length; i++) {
    args[i]=args[i].replace(reg,"").trim();
  }
  var result=args.join("");
  console.log(result);
}
solve([
    '<html>',
    '  <head>',
    '    <title asd>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);
