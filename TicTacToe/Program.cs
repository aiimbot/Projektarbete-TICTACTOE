Random random = new Random();
Ruleset rules = new Ruleset(3);
Display display = new Display(new Art());

IPlayer human = new HumanPlayer("Gustaf");
IPlayer computer = new ThinkingPlayer(new ComputerPlayer(new IStrategy[]
{
    new LineCompletion(rules, Mark.O),
    new LineCompletion(rules, Mark.X),
    new PreferredCells(new[] { 4, 0, 2, 6, 8 }),
    new RandomChoice(random)
}), 1500);

Game game = new Game(new Board(3), rules, display,
    new[] { human, computer }, new[] { Mark.X, Mark.O });
game.Play();