var Platformer = Platformer || {};

Platformer.Player = function (game_state, position, properties) {
    "use strict";
    Platformer.Prefab.call(this, game_state, position, properties);

    this.walking_speed = +properties.walking_speed;
    this.jumping_speed = +properties.jumping_speed;
    this.bouncing = +properties.bouncing;
    this.score = +localStorage.player_score || 0;
    this.lives = +localStorage.player_lives || +properties.lives;

    this.game_state.game.physics.arcade.enable(this);
    this.body.collideWorldBounds = true;

    this.direction = "RIGHT";

    this.animations.add("walking", [0, 1, 2, 1], 6, true);

    this.frame = 3;

    this.anchor.setTo(0.5);

    this.cursors = this.game_state.game.input.keyboard.createCursorKeys();
};

Platformer.Player.prototype = Object.create(Platformer.Prefab.prototype);
Platformer.Player.prototype.constructor = Platformer.Player;

Platformer.Player.prototype.update = function () {
    "use strict";
    this.game_state.game.physics.arcade.collide(this, this.game_state.layers.collision);
    this.game_state.game.physics.arcade.overlap(this, this.game_state.groups.enemies, this.hit_enemy, null, this);

    if (this.cursors.right.isDown && this.body.velocity.x >= 0) {
        // move right
        this.body.velocity.x = this.walking_speed;
        this.direction = "RIGHT";
        this.animations.play("walking");
        this.scale.setTo(-1, 1);
    } else if (this.cursors.left.isDown && this.body.velocity.x <= 0) {
        // move left
        this.body.velocity.x = -this.walking_speed;
        this.direction = "LEFT";
        this.animations.play("walking");
        this.scale.setTo(1, 1);
    } else {
        // stop
        this.body.velocity.x = 0;
        this.animations.stop();
        this.frame = 3;
    }

    // jump only if touching a tile
    if (this.cursors.up.isDown && this.body.blocked.down) {
        this.body.velocity.y = -this.jumping_speed;
    }

    // dies if touches the end of the screen
    if (this.bottom >= this.game_state.game.world.height) {
        this.die();
    }

    if(!CapsLock.isOn()){
        if (this.cursors.left.isDown || this.cursors.right.isDown || this.cursors.down.isDown || !this.body.touching.down)
        {
            game.time.slowMotion = (Math.random() * 10) % 5;
            game.time.desiredFps = 30;
        }
        else
        {
            game.time.slowMotion = 1.0;
            game.time.desiredFps = 60;
        }
    } else {
        game.time.slowMotion = 1.0;
        game.time.desiredFps = 60;
    }
};

Platformer.Player.prototype.hit_enemy = function (player, enemy) {
    "use strict";
    // if the player is above the enemy, the enemy is killed, otherwise the player dies
    if (enemy.body.touching.up) {
        enemy.kill();
        player.y -= this.bouncing;
    } else {
        this.die();
    }
};

Platformer.Player.prototype.die = function () {
    "use strict";
    this.lives -= 1;
    if (this.lives > 0) {
        this.game_state.restart_level();
    } else {
        this.game_state.game_over();
    }
};
