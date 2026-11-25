class HumanPlayer : IPlayer
{
    private readonly string name;
    private Mark mark;
    public HumanPlayer(string name, Mark mark)
    {
        this.name = name;
        this.mark = mark;
    }
    public int ChooseCell(Board board)
    {
        while(true)
        {
            Console.WriteLine($"{name} välj ruta 1-9");
            String? input =Console.ReadLine();
            if (int.TryParse(input, out int number)
                    && number >= 1 && number <= 9)
                {
                    return number;
                }
            Console.WriteLine("Ogiltigt val, skriv ett tal mellan 1 och 9.");
        }
    }
}