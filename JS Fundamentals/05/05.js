function solve(args) {
    var temp = args[0].split('\n');
    temp = temp[1].split(' ');
    for (var i = 0; i < temp.length; i++) {
        temp[i] = +temp[i];
    }
    var cont = 0;
    for (var i = 1; i < temp.length-1; i++) {
        if (temp[i] >temp[i-1] && temp[i]>temp[i+1]) {
            cont += 1;
        }
    }
    console.log(cont);

}
