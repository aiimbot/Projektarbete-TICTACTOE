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
            new Ruleset(length),
			new GravityRuleset(length),
			//VanishingRuleset: length är hur många i rad för vinst, 
			//length är även hur många märken som får finnas samtidigt.
			new VanishingRuleset(length, length)

        };

        int choice = prompt.AskNumber(
            "Välj spelläge 1 (klassisk), 2 (gravity), 3 (vanishing): ", 1, rulesets.Length);
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
	        new ThinkingPlayer(new ComputerPlayer(new[] { guess })),
	        new ThinkingPlayer(new ComputerPlayer(new[] { block, guess })),
	        new ThinkingPlayer(new ComputerPlayer(new[] { win, block, guess }))
	    };
	
	    int level = prompt.AskNumber(
	        "Välj svårighetsgrad: 1 (lätt), 2 (medel), 3 (svår): ", 1, 3);
	    return levels[level - 1];
	}
	
	public int ChooseSize()
    {
        return prompt.AskNumber("Välj brädstorlek (3-12): ", 3, 12);
    }
}

