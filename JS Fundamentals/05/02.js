function solve(args) {
    var temp = args[0].split(" ");
  //b8a23c7cd4a1a75592  console.log(temp[0]);

    function GetMax(a, b) {
        return a > b ? a : b;
    }
    console.log(GetMax(+temp[0],GetMax(+temp[1],+temp[2])));
    }
