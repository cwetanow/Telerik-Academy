function func(args) {
    let array = args[0].split(" ").map(Number);
    let current = 0;
    let max = 0;
    for (var i = 1; i < array.length-1; i += 1) {
        if (array[i - 1] > array[i] && array[i] < array[i+1]) {

            for (let j = i; j > -1; j -= 1) {
                if (array[j] < array[j - 1]) {
                    current += 1;
                } else {
                    break;
                }
                //console.log(current);
            }
            for (let j = i; j < array.length; j += 1) {
                if (array[j] < array[j + 1]) {
                    current += 1;
                } else {
                    break;
                }
            }
            if (current > max) {
                max = current;
            }
        } else {
            current = 0;
        }

    }
    console.log(max);
}
func(["5 1 7 4 8"]);
func(["5 1 7 6 3 6 4 2 3 8"]);
