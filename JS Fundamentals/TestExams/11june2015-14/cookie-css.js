function solve(letters){
  for (var i = 0; i < letters.length; i++) {
    letters[i]=letters[i].trim();
  }
  console.log(letters.join(""));
}
