public class Display
{
	private readonly Art art;

	public Display(Art art)
	{
		this.art = art;
	}

	public void DrawBoard(Board board)
	{
		Console.Write(board.Render(art));
	}
}