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
        int length = prompt.AskNumber($"Hur många i rad för att vinna? (3-{size}): ", 3, size);

        Ruleset[] rulesets =
        {
        new Ruleset(length),
            new GravityRuleset(length),
			//VanishingRuleset: length är hur många i rad för vinst, 
			//length är även hur många märken som får finnas samtidigt.
			new VanishingRuleset(length, length)

    };

        int choice = prompt.AskNumber("Välj spelläge 1 (klassisk), 2 (gravity), 3 (vanishing): ", 1, rulesets.Length);
        return rulesets[choice - 1];
    }

    public IPlayer ChoosePlayer(Ruleset rules, Mark own, Mark other)
    {
        int choice = prompt.AskNumber($"Spelare {own}: 1 (människa), "
            + "2 (dator lätt), 3 (dator medel), 4 (dator svår): ", 1, 4);
        if (choice == 1)
        {
            string name = prompt.AskText($"Namn på spelare {own}: ");
            return new HumanPlayer(name, prompt);
        }
        IStrategy win = new LineCompletion(rules, own);
        IStrategy block = new LineCompletion(rules, other);
        IStrategy guess = new RandomChoice(random);
        IPlayer[] computers =
        {
            new ComputerPlayer(new[] { guess }),
            new ComputerPlayer(new[] { block, guess }),
            new ComputerPlayer(new[] { win, block, guess })
        };
        IPlayer computer = computers[choice - 2];
        int pause = prompt.AskNumber("Ska datorn ta tänkpaus? 1 (ja), 2 (nej): ", 1, 2);
        return pause == 1 ? new ThinkingPlayer(computer) : computer;
    }

    public int ChooseSize()
    {
        return prompt.AskNumber("Välj brädstorlek (3-12): ", 3, 12);
    }

}
