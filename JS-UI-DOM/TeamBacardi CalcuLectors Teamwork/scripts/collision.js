function Collision(hero, obj, sign = "+") {
  let positiveNumberAudio = document.getElementById("positiveNumberAudio"),
    negativeNumberAudio = document.getElementById("negativeAudio"),
    substractionAudio = document.getElementById("substractionAudio"),
    multiplicationAudio = document.getElementById("multiplicationAudio");

  if (hero.sprite_X < obj.sprite_X + obj.spriteWidth &&
    hero.sprite_X + hero.spriteWidth > obj.sprite_X &&
    hero.sprite_Y < obj.sprite_Y + obj.spriteHeight &&
    hero.spriteHeight + hero.sprite_Y > obj.sprite_Y) {

    if (obj.value === 0 && gravitySpeed > 1) {
      gravitySpeed--;
    } else if (typeof obj.value !== "string") {
      if (sign === "+") {
        if (obj.value > 0) {
          positiveNumberAudio.play();
        } else {
          negativeNumberAudio.play();
        }
        hero.value += obj.value;
      } else {
        if (sign === "/") {
          if (obj.value !== 0) {
            hero.value = Math.round(hero.value /= obj.value);
          }
          substractionAudio.play();
        } else if (sign === "*") {
          multiplicationAudio.play();
          hero.value *= obj.value;
        }
      }
    }
    obj.remove();
    return true;
  }
  return false;
}


