Random random = new Random();
Menu menu = new Menu(new Prompt(), random);
Display display = new Display(new Art());

menu.ShowWelcome();
int size = menu.ChooseSize();
Ruleset rules = menu.ChooseRuleset(size);
IPlayer[] players =
{
    menu.ChoosePlayer(rules, Mark.X, Mark.O),
    menu.ChoosePlayer(rules, Mark.O, Mark.X)
};
TurnOrder turnorder = new TurnOrder(players,
    new[] { Mark.X, Mark.O }, random);

Game game = new Game(new Board(size), rules, display, turnorder);
game.Play();