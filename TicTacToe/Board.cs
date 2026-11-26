public class Board 
{

	private readonly Mark[] marks;
	private readonly int[][] Winlines =
	{
		new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
		new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
		new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
	};

	public Board() 
	{
		marks = new Mark[9];
	}

	//Är rutan ledig?
	public bool IsFree(int position) 
	{
		return marks[position] == Mark.Empty;
	}

	//Är brädet fullt?
	public bool IsFull() 
	{
    	foreach (Mark mark in marks) {
    		if (mark == Mark.Empty) 
    		{
    			return false;
    		}
    	}
    	return true;
	}
	//Har någon en vinstlinje?
	public bool HasWinLine(Mark mark)
	{
		foreach (int[] line in Winlines)
		{
			if (marks[line[0]] == mark && marks[line[1]] == mark
				&& marks[line[2]] == mark)
			{
				return true;
			}
		}

		return false;
	}

	//Innehåller rutan vad som efterfrågas?
	public bool Holds(int position, Mark mark) 
	{
		return marks[position] == mark;
	}

	//Lägg en mark i rutan
	public void Place(int position, Mark mark)
	{
		if (marks[position] != Mark.Empty)
		{
			throw new InvalidOperationException("Rutan är upptagen.");
		}

		marks[position] = mark;
	}

	//Lista lediga rutor
	public List<int> ListFreePositions()
	{
		List<int> freePositions = new List<int>();

		for (int i = 0; i < marks.Length; i++)
		{
			if (marks[i] == Mark.Empty) 
			{
				freePositions.Add(i);
			}
		}

		return freePositions;
	}

	// Bygger brädet som text i tre rader med tre rutor var, där tomma rutor visas som mellanslag.
	public string Render(Art art)
	{
	    string text = art.DrawBorder() + "\n";
	
	    for (int boardRow = 0; boardRow < 3; boardRow++)
	    {
	        for (int artRow = 0; artRow < art.CountRows(); artRow++)
	        {
	            text += "|";
	
	            for (int column = 0; column < 3; column++)
	            {
	                Mark mark = marks[boardRow * 3 + column];
	                text += art.ReadRow(mark, artRow) + "|";
	            }
	
	            text += "\n";
	        }
	
	        text += art.DrawBorder() + "\n";
	    }
	
	    return text;
	}

}