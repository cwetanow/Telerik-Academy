function solve(args) {
    var result="";
    var min = Infinity;
    for (var i = 2; i < args.length; i += 3) {
        if (min > +args[i]) {
            min = +args[i];
            result=args[i-2]+" "+args[i-1]
        }
    }
    console.log(result);
}
solve([
    'Gosho', 'Petrov', '32',
    'Bay', 'Ivan', '81',
    'John', 'Doe', '42'
]);
