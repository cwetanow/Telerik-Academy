function solve(args) {
    var last = (+args[0]) % 10;
    var mid = Math.floor((+args[0]) / 10) % 10;
    var first = (Math.floor((+args[0]) / 100));
    var result = "";
    if (args[0].length == 1) {
        switch (last) {
            case 1:
                result = "One ";
                break;
            case 2:
                result = "Two ";
                break;
            case 3:
                result = "Three ";
                break;
            case 4:
                result = "Four ";
                break;
            case 5:
                result = "Five ";
                break;
            case 6:
                result = "Six ";
                break;
            case 7:
                result = "Seven ";
                break;
            case 8:
                result = "Eight ";
                break;
            case 9:
                result = "Nine ";
                break;
        }

    } else if (args[0].length == 2) {
        switch (mid) {

            case 2:
                result += "Twenty";
                break;
            case 3:
                result += "Thirty";
                break;
            case 4:
                result += "Fourty";
                break;
            case 5:
                result += "Fifty";
                break;
            case 6:
                result += "Sixty";
                break;
            case 7:
                result += "Seventy";
                break;
            case 8:
                result += "Eighty";
                break;
            case 9:
                result += "Ninety";
                break;
        }
        if (mid != 1) {
            result += " ";
            switch (last) {

                case 1:
                    result += ("one");
                    break;
                case 2:
                    result += ("two");
                    break;
                case 3:
                    result += ("three");
                    break;
                case 4:
                    result += ("four");
                    break;
                case 5:
                    result += ("five");
                    break;
                case 6:
                    result += ("six");
                    break;
                case 7:
                    result += ("seven");
                    break;
                case 8:
                    result += ("eight");
                    break;

                case 9:
                    result += ("nine");
            }
        }
    } else {
        switch (first) {
            case 1:
                result = "One ";
                break;
            case 2:
                result = "Two ";
                break;
            case 3:
                result = "Three ";
                break;
            case 4:
                result = "Four ";
                break;
            case 5:
                result = "Five ";
                break;
            case 6:
                result = "Six ";
                break;
            case 7:
                result = "Seven ";
                break;
            case 8:
                result = "Eight ";
                break;
            case 9:
                result = "Nine ";
                break;

        }
        result += "hundred"
        if (mid === 1) {
            switch (mid * 10 + last) {
                case 10:
                    result += "ten";
                    break;
                case 11:
                    result += " and eleven";
                    break;
                case 12:
                    result += " and twelve";
                    break;
                case 13:
                    result += " and thirteen";
                    break;
                case 14:
                    result += " and fourteen";
                    break;
                case 15:
                    result += " and fifteen";
                    break;
                case 16:
                    result += " and sixteen";
                    break;
                case 17:
                    result += " and seventeen";
                    break;
                case 18:
                    result += " and eighteen";
                    break;
                case 19:
                    result += " and nineteen";
                    break;
                default:

            }
        } else {
            switch (mid) {
                case 2:
                    result += " and twenty"
                    break;
                case 3:
                    result += " and thirty"
                    break;
                case 4:
                    result += " and fourty"
                    break;
                case 5:
                    result += " and fifty"
                    break;
                case 6:
                    result += " and sixty"
                    break;
                case 7:
                    result += " and seventy"
                    break;
                case 8:
                    result += " and eighty"
                    break;
                case 9:
                    result += " and ninety"
                    break;
                default:
                    if (last != 0) {
                        result += " and";
                    }
            }
            switch (last) {
              case 1:
                  result += " one";
                  break;
              case 2:
                  result += " two";
                  break;
              case 3:
                  result += " three";
                  break;
              case 4:
                  result += " four";
                  break;
              case 5:
                  result += " five";
                  break;
              case 6:
                  result += " six";
                  break;
              case 7:
                  result += " seven";
                  break;
              case 8:
                  result += " eight";
                  break;
              case 9:
                  result += " nine";
                  break;
              default:

            }
        }
    }
    if (args[0].length == 2) {
        switch (mid * 10 + last) {
            case 10:
                result = "Ten";
                break;
            case 11:
                result = "Eleven";
                break;
            case 12:
                result = "Twelve";
                break;
            case 13:
                result = "Thirteen";
                break;
            case 14:
                result = "Fourteen";
                break;
            case 15:
                result = "Fifteen";
                break;
            case 16:
                result = "Sixteen";
                break;
            case 17:
                result = "Seventeen";
                break;
            case 18:
                result = "Eighteen";
                break;
            case 19:
                result = "Nineteen";
                break;
            default:

        }
    }

    if (+args[0] === 0) {
        result = "Zero";
    }
    console.log(result);
}

solve([0]);
solve([9]);
solve([10]);
solve([12]);
solve([19]);
solve([25]);
solve([98]);
solve([273]);
solve([400]);
solve([501]);
solve([617]);
solve([711]);
solve([999]);
