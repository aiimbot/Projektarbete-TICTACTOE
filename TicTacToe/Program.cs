Random random = new Random();
Menu menu = new Menu(new Prompt(), random);
Display display = new Display(new Art());

menu.ShowWelcome();
int size = menu.ChooseSize();
Ruleset rules = menu.ChooseRuleset(size);
IPlayer opponent = menu.ChooseOpponent(rules);

Game game = new Game(new Board(size), rules, display,
    new[] { new HumanPlayer("Spelare 1"), opponent },
    new[] { Mark.X, Mark.O });
game.Play();