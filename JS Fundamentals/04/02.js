function solve(args) {
    var a = args[0].split('\n')[0];
    var b = args[0].split('\n')[1];

    if (a.length === b.length && a === b) {
        console.log('=');
    }
    else if (a>b) {
      console.log(">");
    }else if (a<b) {
      console.log("<");
    }else if (a.length > b.length) {
        console.log(">");
    } else {
        console.log("<");
    }
}
