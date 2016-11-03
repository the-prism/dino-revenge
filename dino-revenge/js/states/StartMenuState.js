var Platformer = Platformer || {};

Platformer.StartMenuState = function () {
    "use strict";
    Phaser.State.call(this);
};

Platformer.prototype = Object.create(Phaser.State.prototype);
Platformer.prototype.constructor = Platformer.StartMenuState;

Platformer.StartMenuState.prototype.init = function (level_data) {
    "use strict";
    this.level_data = level_data;
};

Platformer.StartMenuState.prototype.preload = function () {
    "use strict";
    game.load.spritesheet('button', 'assets/images/button_sprite_sheet2.png', 193, 71);
};



var button;
Platformer.StartMenuState.prototype.create = function () {
    "use strict";
    button = game.add.button(game.world.centerX - 95, 400, 'button', this.actionOnClick, this, 1, 0, 2);
    button.onInputUp.add(this.up, this);
};

Platformer.StartMenuState.prototype.actionOnClick = function () {
    this.game.state.start("GameState", true, false, this.level_data);
};

Platformer.StartMenuState.prototype.up = function () {
    this.game.state.start("GameState", true, false, this.level_data);
};
