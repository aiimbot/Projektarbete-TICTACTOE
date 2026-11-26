/*
Display display = new Display(new Art());
IPlayer human = new HumanPlayer("Gustaf");
IPlayer computer = new ThinkingPlayer(
    new SmartPlayer(new Random(), Mark.O), 1500);

Game game = new Game(new Board(3), new Ruleset(3), display,
    human, computer);
game.Play();
*/


//Menu menu = new Menu(new Prompt(), new Random());
//menu.ShowWelcome();
//Ruleset rules = menu.ChooseRuleset();
//IPlayer opponent = menu.ChooseOpponent();
//Board board = menu.ChooseBoard();

Menu menu = new Menu(new Prompt(), new Random());

Ruleset rules = new ClassicRuleset(3);
IPlayer opponent = menu.ChooseOpponent(rules);
Board board = menu.ChooseBoard();

Display display = new Display(new Art());
IPlayer human = new HumanPlayer("Gustaf");

Game game = new Game(board, rules, display,
    new[] { human, opponent }, new[] { Mark.X, Mark.O });