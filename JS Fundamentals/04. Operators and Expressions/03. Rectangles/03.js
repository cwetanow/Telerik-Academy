  function solve(args){
    var a=+args[0];
  
    var b=+args[1];
    function Area(a,b){
      return a*b;
    }
    function Perimeter(a,b){
      return 2*(a+b);
    }
    console.log(Area(a,b).toFixed(2)+' '+Perimeter(a,b).toFixed(2));
  }
solve([2.5,3])
solve([5,5]);
solve([3,4]);
