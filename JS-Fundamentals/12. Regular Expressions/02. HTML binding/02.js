function solve(args) {
    let types = JSON.parse(args[0]);
    let html = JSON.parse(args[1]);;
    for (var variable in hem) {
        console.log(variable);
        console.log(types[variable]);
    }
    let result = args[1];
    for (var property in types) {

        var regex = new RegExp(" >");
        result = result.replace(regex, types[property]);
    }
    console.log(result);

}
solve([
    '{ "name": "Steven" }',
    '<div data-bind-content="name"></div>'
]);
