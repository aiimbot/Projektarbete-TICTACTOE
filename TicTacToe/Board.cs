public class Board 
{
	private readonly Mark[] marks;
	private readonly int size;

	private readonly int[][] directions =
	{
		new[] { 0, 1 }, new[] { 1, 0 }, new[] { 1, 1 }, new[] { 1, -1 }
	};

	public Board(int size)
	{
		this.size = size;
		marks = new Mark[size * size];
	}

	//Är brädet fullt?
	public bool IsFull() 
	{
		foreach (Mark mark in marks)
		{
			if (mark == Mark.Empty) 
			{
				return false;
			}
		}
		return true;
	}

	//Har någon en vinstlinje?
	public bool HasLine(Mark mark, int length)
	{
		for (int start = 0; start < marks.Length; start++)
		{
			foreach (int[] step in directions)
			{
				int count = 0;
				int row = start / size;
				int column = start % size;
				while (row < size && column >= 0 && column < size
					&& marks[row * size + column] == mark && count < length)
				{
					count++;
					row += step[0];
					column += step[1];
				}
				if (count == length)
				{
					return true;
				}
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

	//Bygger brädet som text med en figur per ruta
	public string Render(Art art)
	{
		string text = art.DrawBorder(size) + "\n";
	
		for (int boardRow = 0; boardRow < size; boardRow++)
		{
			for (int artRow = 0; artRow < art.CountRows(); artRow++)
			{
				text += "|";
	
				for (int column = 0; column < size; column++)
				{
					Mark mark = marks[boardRow * size + column];
					text += art.ReadRow(mark, artRow) + "|";
				}
	
				text += "\n";
			}
	
			text += art.DrawBorder(size) + "\n";
		}
	
		return text;
	}
}