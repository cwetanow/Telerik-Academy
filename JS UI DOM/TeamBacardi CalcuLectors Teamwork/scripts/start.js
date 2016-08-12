function Start() {

    'use strict';

    $('#gameScreen').show();
    $('#menu').hide();

    var hero = createHero(),
        numbers = [],
        sign,
        maxScore = 0;

    function mainLoop() {

        //draws background
        ctx.drawImage(backGroundImage, 0, 0, backGroundImage.width, backGroundImage.height, 0, 0, screenWidth, screenHeight);

        if (spawns === spawnTimesPerLevel) {
            if (gravitySpeed <= maxGravitySpeed) {
                gravitySpeed++;
            }
            spawns = 1;
        }

        if (timePassed === intervalOfSpawn) {
            numbers.push(createNumber());
            spawns++;
            timePassed = 1;
        }
        timePassed++;
        for (var i = 0; i < numbers.length; i += 1) {
            //draws
            numbers[i].render();
            numbers[i].gravity(gravitySpeed); //to do add falling speed
            numbers[i].spin(3);

            //calculate score
            if (hero.value > maxScore) {
                maxScore = hero.value;
            }
            $('.scoreValue').text(hero.value);
            $('.gravityValue').text(gravitySpeed);
            //game ends
            if (hero.value < 0) {
                $('#gameOver').show();
                $('#maxScore').text(maxScore);
                return;
            }
            //checks for collision
            var hasCollision;
            hasCollision = Collision(hero, numbers[i], sign);

            if (hasCollision) {
                sign = numbers[i].value;
                if (typeof sign !== "string") {
                    sign = "+";
                }
                numbers.splice(i, 1);
            }
        }

        hero.render();

        let audio = document.getElementById('walkingAudioMp3');
        if (moveLeft) {
            audio.play();
            hero.move({ left: true }, 5, 10);
        }
        if (moveRight) {
            audio.play();
            hero.move({ right: true }, 5, 10);
        }


        window.requestAnimationFrame(mainLoop);
    }


    window.addEventListener('keydown', function(el) {


        if (el.which === leftArrow) {
            moveLeft = true;
        } else if (el.which === rightArrow) {
            moveRight = true;

        }

    }, false);


    window.addEventListener('keyup', function(el) {
        if (el.which === leftArrow) {
            moveLeft = false;
        } else if (el.which === rightArrow) {
            moveRight = false;
        }


    }, false);

    mainLoop();
}