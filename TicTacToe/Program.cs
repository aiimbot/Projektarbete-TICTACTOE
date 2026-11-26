Display display = new Display(new Art());
IPlayer human = new HumanPlayer("Gustaf");
IPlayer computer = new ThinkingPlayer(new RandomPlayer(new Random()), 1500);

Game game = new Game(new Board(3, 3), new ClassicRuleset(), display,
    human, computer);
game.Play();