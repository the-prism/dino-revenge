// This game has been inspired by an online tutorial at : https://gamedevacademy.org/platformer-tutorial-with-phaser-and-tiled/

var Phaser = Phaser || {};
var Platformer = Platformer || {};

var game = new Phaser.Game("100%", "100%", Phaser.CANVAS, "canvas");
game.state.add("BootState", new Platformer.BootState());
game.state.add("LoadingState", new Platformer.LoadingState());
game.state.add("StartMenuState", new Platformer.StartMenuState());
game.state.add("GameState", new Platformer.TiledState());
game.state.start("BootState", true, false, "assets/levels/level1.json");
