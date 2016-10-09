function solve(args) {
    var hex = args[0];
    var dec = 0;
    var result=0;
    for (var i = hex.length-1; i>-1; i-=1) {
      result+=Convert(hex[i])*Math.pow(16,hex.length-1-i);
  
    }
    console.log(result);
    function Convert(a) {
        switch (a) {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
                return +a;
            case "A":
                return 10;
            case "B":
                return 11;
            case "C":
                return 12;
            case "D":
                return 13;
            case "E":
                return 14;
            default:
            return 15;

        }
    }
}
solve(["1AE3"]);
