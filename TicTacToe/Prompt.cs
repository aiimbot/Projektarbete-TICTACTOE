public class Prompt
{
    public int AskNumber(string text, int min, int max)
    {
    	Console.Write(text);
        while (true)
        {
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number)
                && number >= min && number <= max)
            {
                return number;
            }

            Console.Write($"Skriv ett tal mellan {min} och {max}: ");
        }
    }
}