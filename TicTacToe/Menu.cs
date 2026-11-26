public class Menu
{

	private readonly Prompt prompt;
	private readonly Random random;

	public Menu(Prompt prompt, Random random) 
	{
		this.prompt = prompt;
		this.random = random;
	}

	public void ShowWelcome()
    {
        Console.Clear();
        Console.WriteLine("=== I RAD ===");
        Console.WriteLine("Få flest märken i rad för att vinna!");
        Console.WriteLine();
    }

	public Ruleset ChooseRuleset(int size)
    {
        int length = prompt.AskNumber(
            $"Hur många i rad för att vinna? (3-{size}): ", 3, size);

        Ruleset[] rulesets =
        {
            new Ruleset(size)

        };

        int choice = prompt.AskNumber(
            "Spelläge: 1 Klassisk, 2 Gravity: ", 1, rulesets.Length);
        return rulesets[choice - 1];
    }

	public IPlayer ChooseOpponent(Ruleset rules)
	{
	    int kind = prompt.AskNumber(
	        "Välj motståndare: 1 (människa), 2 (dator): ", 1, 2);
	
	    if (kind == 1)
	    {
	        return new HumanPlayer(prompt.AskText("Namn på spelare 2: "));
	    }
	
	    IStrategy win = new LineCompletion(rules, Mark.O);
	    IStrategy block = new LineCompletion(rules, Mark.X);
	    IStrategy guess = new RandomChoice(random);
	
	    IPlayer[] levels =
	    {
	        new ComputerPlayer(new[] { guess }),
	        new ComputerPlayer(new[] { block, guess }),
	        new ComputerPlayer(new[] { win, block, guess })
	    };
	
	    int level = prompt.AskNumber(
	        "Välj svårighetsgrad: 1 (lätt), 2 (medel), 3 (svår): ", 1, 3);
	    return levels[level - 1];
	}

	public Board ChooseBoard()
	{
		int size = prompt.AskNumber("Välj brädstorlek (minst 3, högst 12): ", 3, 12);
		return new Board(size);
	}
	public int ChooseSize()
    {
        return prompt.AskNumber("Välj brädstorlek (3-12): ", 3, 12);
    }
}

