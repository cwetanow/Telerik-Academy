function solve(args) {
    //read input
    var nk = args[0].split(" ").map(Number);
    var numbers = args[1].split(" ").map(Number);
    for (var j = 0; j < nk[1]; j += 1) {
        var temp = copyArray(numbers);
        for (var i = 0; i < numbers.length; i += 1) {

            //number == 0
            if (numbers[i] === 0) {
                if (i === 0) {
                    temp[i] = Math.abs(numbers[numbers.length - 1] - numbers[i + 1]);
                } else if (i === numbers.length - 1) {
                    temp[i] = Math.abs(numbers[i - 1] - numbers[0]);
                } else {
                    temp[i] = Math.abs(numbers[i - 1] - numbers[i + 1]);
                }
            }
            //number is even
            else if (numbers[i] % 2 === 0) {
                if (i === 0) {
                    temp[i] = Math.max(numbers[numbers.length - 1], numbers[i + 1]);
                } else if (i === numbers.length - 1) {
                    temp[i] = Math.max(numbers[i - 1], numbers[0]);
                } else {
                    temp[i] = Math.max(numbers[i - 1], numbers[i + 1]);
                }
            } else if (numbers[i] === 1) {
                if (i === 0) {
                    temp[i] = (numbers[numbers.length - 1] + numbers[i + 1]);
                } else if (i === numbers.length - 1) {
                    temp[i] = (numbers[i - 1] + numbers[0]);
                } else {
                    temp[i] = (numbers[i - 1] + numbers[i + 1]);
                }
            } else {
                if (i === 0) {
                    temp[i] = Math.min(numbers[numbers.length - 1], numbers[i + 1]);
                } else if (i === numbers.length - 1) {
                    temp[i] = Math.min(numbers[i - 1], numbers[0]);
                } else {
                    temp[i] = Math.min(numbers[i - 1], numbers[i + 1]);
                }
            }

        }
        numbers = temp;
    }

    console.log(numbers);
    //get the sum
    var sum = 0;
    for (var i = 0; i < numbers.length; i++) {
        sum += numbers[i];
    }
    console.log(sum);

    function copyArray(array) {
        var temp = [];
        for (var i = 0; i < array.length; i++) {
            temp[i] = array[i];
        }
        return temp;
    }
}
solve([
    '5 1',
    '9 0 2 4 1'
]);
