public class Display
{
	private readonly Art art;

	public Display(Art art)
	{
		this.art = art;
	}

	public void DrawBoard(Board board)
	{
		Console.Clear();
		Console.Write(board.Render(art));
	}
	
	public void ShowResult(bool hasWinner, Mark mark)
	{
		if (hasWinner)
		{
			Console.WriteLine($"{mark} vann!");
		}
		else
		{
			Console.WriteLine("Oavgjort!");
		}
	}
}