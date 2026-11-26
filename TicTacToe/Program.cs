Display display = new Display(new Art());
IPlayer human = new HumanPlayer("Gustaf");
IPlayer computer = new ThinkingPlayer(
    new SmartPlayer(new Random(), Mark.O), 1500);

Game game = new Game(new Board(3), new Ruleset(3), display,
    human, computer);
game.Play();