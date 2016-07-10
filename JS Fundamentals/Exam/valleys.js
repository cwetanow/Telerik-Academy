function solve(args) {
    let numbers = args[0].split(" ").map(Number);
    let current = 0;
    let max = 0;
    for (var i = 1; i < numbers.length; i += 1) {
        if (numbers[i - 1] > numbers[i] && numbers[i + 1] > numbers[i]) {
          current=numbers[i];
            for (var j = i; j > -1; j -= 1) {
                if (numbers[j] < numbers[j - 1]) {
                    current += numbers[j - 1];
                } else {
                    break;
                }
            }
            for (var j = i; j < numbers.length; j += 1) {
                if (numbers[j] < numbers[j + 1]) {
                    current += numbers[j + 1];
                } else {
                    break;
                }
            }
          

        } else {
            current = numbers[i];
        }
        if (current > max) {
            max = current;
        }
    }

    console.log(max);
}
solve([
    "5 1 7 4 8"
]);
