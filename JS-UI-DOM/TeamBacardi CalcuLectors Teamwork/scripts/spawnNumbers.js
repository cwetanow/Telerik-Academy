function createNumber() {
  var isPositive = Random() || false,
    imgNum,
    imgSrc,
    imgValue;

  if (isPositive) {
    imgNum = Random(fallingNumberProperties.positive.length - 1);
    imgSrc = fallingNumberProperties.positive[imgNum];
    imgValue = fallingNumberProperties.values[imgNum];
  } else {
    imgNum = Random(fallingNumberProperties.negative.length - 1);
    imgSrc = fallingNumberProperties.negative[imgNum];
    if (typeof fallingNumberProperties.values[imgNum] === "string") {
      imgValue = fallingNumberProperties.values[imgNum];
    } else {
      imgValue = -fallingNumberProperties.values[imgNum];
    }
  }

  var image = new Image();
  image.src = imgSrc;

  var delta = 50;
  var randomNumber = Random(screenWidth);

  if (randomNumber < delta) {
    randomNumber = delta;
  } else if (randomNumber > screenWidth - delta) {
    randomNumber = screenWidth - delta;
  }

  var spawnX = randomNumber;

  var number = new spriteModule.fallingSprite({
    context: ctx,
    image: image, // random *
    startingFrame_X: 0, // const
    startingFrame_Y: 0, // const
    frameWidth: 150,    // const
    frameHeight: 202,   //const
    sprite_X: spawnX, // random
    sprite_Y: 0,        // const
    spriteWidth: 30,    // const
    spriteHeight: 40,   // const
    deltaX: 1,
    deltaY: 1,
    value: imgValue
  });





  return number;
}
