import Sprite from './Sprite.js'

let checkJson = JSON.parse(localStorage.getItem("json"));

const canvas = document.querySelector('canvas');

// Canvas' dimension.
canvas.width = 350;
canvas.height = 376;
const gravity = 1;

class Fighter extends Sprite {
    constructor({ name, position, offset, imageSrc, scale, maxFrames, holdFrames, offsetFrame = { x: 0, y: 0 }, sprites, keys, attackTime }) {
        super({ position, imageSrc, scale, maxFrames, holdFrames, offsetFrame });
        this.name = name;
        this.height = 150;
        this.width = 50;
        this.velocity = { x: 0, y: 0 } // Initial velocity is 0 in both axis.
        this.moveFactor = 6;    // Determinates how fast this sprite can move due to user input.
        this.lastKey;           // Last key pressed by this sprite.
        this.inTheAir = false;  // Avoid the sprite jump if it's already in the air.
        this.isAttacking = false;
        this.health = 100;
        this.attackBox = {
            position: {
                x: this.position.x,
                y: this.position.y
            },
            offSet: offset, // AttackBox's offset.
            width: 150,
            height: 150
        };  // End attack box.
        this.sprites = sprites;
        for (const sprite in this.sprites) {
            sprites[sprite].image = new Image();
            sprites[sprite].image.src = sprites[sprite].imageSrc;
        }
        this.keys = keys;
        this.attackTime = attackTime;   // ms to perform his attack animation.
        this.attackCooldown = true; // Fighter can only attack when his cooldown is up.
        this.isTakingHit = false;   // Fighter is taking a hit from another fighter.
    }

    attack(antagonistFighter) {
        if (this.isAttacking && this.health > 0 && this.attackCooldown) {
            this.attackCooldown = false;
            setTimeout(() => { this.attackCooldown = true }, 1000)
            this.switchSprite('attack')
            if (this.isHitting(antagonistFighter)) {
                antagonistFighter.health -= 10;
                gsap.to('#' + antagonistFighter.name + 'Health', { width: antagonistFighter.health + '%' });
                antagonistFighter.switchSprite('takehit');
                antagonistFighter.isTakingHit = true;
            }
        }
    }

    isHitting(antagonistFighter) {
        return true;
    }

    movement() {
        // This determinates if the player moves to the left or to the right. It wont let the player leave the canvas at the sides.
        let running = false;    // Determinate if player is running or not.
        if (this.health > 0) {
            if (Object.values(this.keys)[0].pressed && (this.lastKey === 'a' || this.lastKey === 'ArrowLeft') && this.position.x >= 0) {
                this.velocity.x = -this.moveFactor; // 'a' is pressed and it's the last pressed key, then move to the left.
                this.switchSprite('run')
                running = true;
            } else if (Object.values(this.keys)[1].pressed && (this.lastKey === 'd' || this.lastKey === 'ArrowRight') && this.position.x <= (canvas.width - this.width)) {
                this.velocity.x = this.moveFactor;  // 'd' is pressed and it's the last pressed key, then move to the right.
                this.switchSprite('run')
                running = true;
            }
        }
        return running;
    }

    // Update the sprite every frame.
    update() {
        super.update();
        this.attackBox.position.x = this.position.x + this.attackBox.offSet.x;    // Update attack box position to follow the sprite.
        this.attackBox.position.y = this.position.y;    // Update attack box position to follow the sprite.
        this.position.y += this.velocity.y;     // Move the sprite in 'y' direction his 'y' velocity.
        this.position.x += this.velocity.x;    // Move the sprite in 'x' direction his 'x' velocity.

        // If the sprite is in the air, then it gets affected by gravity.
        if (this.position.y + this.height + this.velocity.y >= canvas.height - 95) { // Sprite reach the bottom of the canvas.
            this.velocity.y = 0;
            this.inTheAir = false;  // Sprite touch the bottom of the canvas, is not in the air and can jump again.
        } else {    // Sprite is in the air, gets affected by gravity.
            this.velocity.y += gravity; // Add gravity speed to the sprite every frame to slow it down.
            if (this.velocity.y > 0) {  // Sprite's y velocity is positive, it's falling.
                this.switchSprite('fall');
            } else {    // Sprite is still going up.
                this.inTheAir = true;   // Sprite is in the air and can't jump againg.
                this.switchSprite('jump');
            }
        }
    }

    switchSprite(sprite) {
        switch (sprite) {
            case 'idle':
                if (this.image !== this.sprites.idle.image && !this.inTheAir && this.health > 0) {
                    //console.log("idle")
                    this.image = this.sprites.idle.image;
                    this.maxFrames = this.sprites.idle.maxFrames;
                    this.currentFrame = 0;  // To avoid flickering when changing between different sprites.
                }
                break;
            case 'run':
                if (!this.isAttacking && !this.isTakingHit) {   // Can only run if is not attacking or taking a hit
                    //console.log("correr")
                    this.image = this.sprites.run.image;
                    this.maxFrames = this.sprites.run.maxFrames;
                }
                break;
            case 'jump':
                if (this.image !== this.sprites.attack1.image) {
                    //console.log("saltar")
                    this.image = this.sprites.jump.image;
                    this.maxFrames = this.sprites.jump.maxFrames;
                    this.currentFrame = 0;
                }
                break;
            case 'fall':
                if (this.image !== this.sprites.attack1.image) {    // Show attack anim while falling.
                    //console.log("caer")
                    this.image = this.sprites.fall.image;
                    this.maxFrames = this.sprites.fall.maxFrames;
                    this.currentFrame = 0;
                }
                break;
            case 'death':   //TODO: Hacer que el fighter caiga al suelo al morir.
                //console.log("morir");
                this.image = this.sprites.death.image;
                this.maxFrames = this.sprites.death.maxFrames;
                this.currentFrame = 0;
                break;
            case 'attack':
                //console.log("attack")
                this.image = this.sprites.attack1.image;
                this.maxFrames = this.sprites.attack1.maxFrames;
                this.currentFrame = 0;
                setTimeout(() => { this.isAttacking = false }, this.attackTime)
                break;
            case 'takehit':
                //console.log("take hit");
                this.image = this.sprites.takeHit.image;
                this.maxFrames = this.sprites.takeHit.maxFrames;
                this.currentFrame = 0;
                setTimeout(() => { this.isTakingHit = false }, 500);
                break;
        }
    }
}

// Detect whenever the attackBox of this fighter hits another fighter while attacking.


// Create player sprite.
export const player = new Fighter({
    name: "player",
    position: {
        x: 75,
        y: 0
    },
    offset: {
        x: 75,
        y: 0
    },
    imageSrc: checkJson.sprites.player.idle,
    scale: 2.5,
    maxFrames: checkJson.sprites.player.idleMaxFrames,
    holdFrames: 4,
    offsetFrame: { x: 215, y: 154 },
    sprites: {
        idle: {
            imageSrc: checkJson.sprites.player.idle,
            maxFrames: checkJson.sprites.player.idleMaxFrames,
        },
        fall: {
            imageSrc: checkJson.sprites.player.idle,
            maxFrames: checkJson.sprites.player.idleMaxFrames,
        },
        death: {
            imageSrc: checkJson.sprites.player.death,
            maxFrames: checkJson.sprites.player.deathMaxFrames,
        },
        attack1: {
            imageSrc: checkJson.sprites.player.attack,
            maxFrames: checkJson.sprites.player.attackMaxFrames,
        },
        takeHit: {
            imageSrc: checkJson.sprites.player.damage,
            maxFrames: checkJson.sprites.player.damageMaxFrames,
        }

    },
    keys: {
        'a': {
            pressed: false
        },
        'd': {
            pressed: false
        },
        'w': {
            pressed: false
        },
        ' ': {
            pressed: false
        }
    },
    attackTime: 400
})

export const antagonist = new Fighter({
    name: "antagonist",
    position: {
        x: 260,
        y: 0
    },
    offset: {
        x: 0,
        y: 0
    },
    imageSrc: checkJson.sprites.antagonist.idle,
    scale: 2.5,
    maxFrames: checkJson.sprites.antagonist.idleMaxframes,
    holdFrames: 6,
    offsetFrame: { x: 215, y: 172 },
    sprites: {
        idle: {
            imageSrc: checkJson.sprites.antagonist.idle,
            maxFrames: checkJson.sprites.antagonist.idleMaxFrames,
        },
        fall: {
            imageSrc: checkJson.sprites.antagonist.idle,
            maxFrames: checkJson.sprites.antagonist.idleMaxFrames,
        },
        death: {
            imageSrc: checkJson.sprites.antagonist.death,
            maxFrames: checkJson.sprites.antagonist.deathMaxFrames,
        },
        attack1: {
            imageSrc: checkJson.sprites.antagonist.attack,
            maxFrames: checkJson.sprites.antagonist.attackMaxFrames,
        },
        takeHit: {
            imageSrc: checkJson.sprites.antagonist.damage,
            maxFrames: checkJson.sprites.antagonist.damageMaxFrames,
        }
    },
    keys: {
        'ArrowLeft': {
            pressed: false
        },
        'ArrowRight': {
            pressed: false
        },
        'ArrowUp': {
            pressed: false
        },
        'Control': {
            pressed: false
        }
    },
    attackTime: 400
});

export default Fighter;