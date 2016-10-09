function solve(args) {
    let types = JSON.parse(args[0]);;
    
    let result = args[1];
    for (var property in types) {
        var regex = new RegExp("#\{" + property + "\}", "g");
        result = result.replace(regex, types[property]);
    }
    console.log(result);
}
let test = [
    '{ "name": "John" }',
    "Hello, there! Are you #{name}?"
];
let test2 = [
    '{ "name": "John", "age": 13 }',
    "My name is #{name} and I am #{age}-years-old"
];
solve(test);
solve(test2);
