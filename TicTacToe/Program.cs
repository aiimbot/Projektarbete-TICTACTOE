Display display = new Display(new Art());
IPlayer human = new HumanPlayer("Gustaf");
IPlayer computer = new RandomPlayer(new Random());

Game game = new Game(new Board(), new ClassicRuleset(), display,
    human, computer);
game.Play();