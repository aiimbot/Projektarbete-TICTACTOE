Display display = new Display(new Art());
IPlayer human = new HumanPlayer("Gustaf");
IPlayer computer = new ThinkingPlayer(new RandomPlayer(new Random()), 1500);

Game game = new Game(new Board(5, 5), new Ruleset(5), display,
    human, computer);
game.Play();