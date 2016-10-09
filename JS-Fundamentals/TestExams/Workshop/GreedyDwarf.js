  function solve(args) {
      var valley = args[0].split(",").map(Number);
      var patterns = +args[1];
      var pattern = [];
      for (var l = 0; l < patterns; l += 1) {
          pattern[l] = args[l + 2].split(', ').map(Number);
      }
      var max = 0;
      for (var i = 0; i < pattern.length; i += 1) {
          var coins = valley[0];
          var currentPos = 0;
          var temp = copyArray(valley);
          temp[currentPos] = true;
          var j = 0;
          while (true) {
              currentPos += pattern[i][j];
              if (checkInside(temp, currentPos)) {

                  break;
              } else {
                  coins += valley[currentPos];
                  temp[currentPos] = true;
              }
              j += 1;
              if (j==pattern[i].length) {
                j=0;
              }
              j %= pattern[i].length;

          }
          max=Math.max(coins,max);

      }
    console.log(max);

      function copyArray(array) {
          var temporary = [];
          for (var k = 0; k < array.length; k += 1) {
              temporary[k] = array[k];
          }
          return temporary;
      }

      function checkInside(array, index) {
          if (array[index] === true || index < 0 || index >= array.length) {
              return true;
          } else {
              return false;
          }
      }

  }
  var test = [
      '1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12',
      '3',
      '5, 1, -2',
      '1, 3 , 7',
      '1, -5'
  ];
  solve(test);
