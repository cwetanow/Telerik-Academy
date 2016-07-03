function solve(args) {
    var result = "",
        text = args[0],
        offset = +args[1],
        CONSTANTS = {
            ALPHABET: 'abcdefghijklmnopqrstuvwxyz'
        }
    var alpha = CONSTANTS.ALPHABET.substr(CONSTANTS.ALPHABET.length - offset);
    alpha += CONSTANTS.ALPHABET.substring(0, CONSTANTS.ALPHABET.length - offset);
    text = compress(text);
    text = encrypt(text, alpha);
    var product = product(text);
    var sum = sum(text);
    console.log(sum);
    console.log(product);


    function sum(str) {
        var result = 0;
        for (var i = 0; i < str.length; i += 1) {
            if (+str[i] % 2 === 0) {

                result += +str[i];
            }
        }
        return result;
    }

    function product(str) {
        var result = 1;
        for (var i = 0; i < str.length; i += 1) {
            if (+str[i] % 2 === 1) {

                result *= +str[i];
            }
        }
        return result;
    }

    function encrypt(satring, alphabet) {
        var result = "";
        for (var i = 0; i < satring.length; i += 1) {
            if (!isNaN(satring[i])) {

                result += satring[i];
            } else {
                var pos = satring[i].charCodeAt(0) - 97;
                result += satring[i].charCodeAt(0) ^ (alphabet[pos].charCodeAt(0));

            }
        }
        return result;
    }

    function compress(satring) {
        var result = "";
        var count = 1;
        for (var i = 1; i < satring.length; i += 1) {
            count = 1;
            while (true) {
                if (satring[i] != satring[i - 1]) {
                    break;
                }
                count += 1;
                i += 1;
            }

            if (count > 2) {
                result += count + "" + satring[i - 1];
            } else if (count === 2) {
                result += satring[i - 1];
                result += satring[i - 1];
            } else {
                result += satring[i - 1];
            }


        }
        return result;
    }
}

solve(['a',
    '3'
]);
