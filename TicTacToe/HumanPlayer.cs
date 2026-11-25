class HumanPlayer : IPlayer
{
    private readonly string name;
    private readonly Mark mark;
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

            if (!int.TryParse(input, out int number)
                || number < 1 || number > 9)
            {
                Console.WriteLine("Ogiltigt val, skriv 1-9.");
                continue;
            }
            
            number -= 1;

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