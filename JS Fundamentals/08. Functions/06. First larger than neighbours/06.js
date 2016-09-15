function solve(args) {
    var temp = args[0].split('\n');
    temp = temp[1].split(' ').map(Number);
    for (var i = 1; i < temp.length - 1; i++) {
        if (temp[i] > temp[i - 1] && temp[i] > temp[i + 1]) {
            console.log(i);
            break;
        }
    }
  }
