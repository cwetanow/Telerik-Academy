function solve(args) {
    var temp = args[0].split('\n');
    var searched = +temp[2];
    temp = temp[1].split(' ');
    for (var i = 0; i < temp.length; i++) {
        temp[i] = +temp[i];
    }
    var cont = 0;
    for (var i = 0; i < temp.length; i++) {
        if (temp[i] === searched) {
            cont += 1;
        }
    }
    console.log(cont);

}
