class HumanPlayer : IPlayer
{
    private readonly string name;
    private Mark mark;
    public HumanPlayer(string name, Mark mark)
    {
        this.name = name;
        this.mark = mark;
    }
    public void PlayTurn(Board board)
    {
        while(true)
        {
            Console.WriteLine($"{name} välj ruta 1-9");
            String? input = Console.ReadLine();
            int.TryParse(input, out int number);
            number -= 1;
            if (number < 0 || number > 8)
            {
                Console.WriteLine("Ogiltigt val, skriv ett tal mellan 1 och 9.");
                continue;
            }
            if (!board.IsFree(number))
            {
                Console.WriteLine("Rutan är inte ledig, välj en annan.");
                continue;
            }

            board.Place(number, mark);
            break;
        }
    }
}