
function createHero() {

        var hero = new spriteModule.heroSprite({
            context: ctx,
            image: heroProperties.image,
            startingFrame_X: heroProperties.startingFrame_X,
            startingFrame_Y: heroProperties.startingFrame_Y,
            frameWidth: heroProperties.frameWidth,
            frameHeight: heroProperties.frameHeight,
            sprite_X: heroProperties.x,
            sprite_Y: heroProperties.y,
            spriteWidth: heroProperties.frameWidth,
            spriteHeight: heroProperties.frameHeight,
            value : 0

        }, heroProperties);

        return hero;

}