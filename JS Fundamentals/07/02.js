function name(params) {
    var open = 0;
    var close = 0;
    var error = false;
    for (var i = 0; i < params[0].length; i += 1) {
        if (params[0][i] === "(") {
            open += 1;
        } else if (params[0][i] === ")") {
            close += 1;
        }
        if (close > open) {
            console.log("Incorrect");
            error = true;
            break;
        }
    }
    if (open === close) {
        console.log("Correct");
    } else if (!error) {
        console.log("Incorrect");
    }
}
