public class Board
{
	private readonly Mark[] marks;
	private readonly int size;
	private readonly List<int> history = new List<int>();

	private readonly int[][] directions =
	{
		new[] { 0, 1 }, new[] { 1, 0 }, new[] { 1, 1 }, new[] { 1, -1 }
	};

	public Board(int size)
	{
		this.size = size;
		marks = new Mark[size * size];
	}

	// Är brädet fullt?
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

	// Har någon en vinstlinje?
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

	// Lägg en mark i rutan
	public void Place(int position, Mark mark)
	{
		if (marks[position] != Mark.Empty)
		{
			throw new InvalidOperationException("Rutan är upptagen.");
		}

		marks[position] = mark;
		history.Add(position);
	}

	// Lista lediga rutor
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

	// Bygger brädet som text med en figur per ruta
	public string Render(Art art)
	{
		string text = art.DrawBorder(size, 0) + "\n";
		for (int boardRow = 0; boardRow < size; boardRow++)
		{
			for (int artRow = 0; artRow < art.CountRows(); artRow++)
			{
				text += "│";

				for (int column = 0; column < size; column++)
				{
					int position = boardRow * size + column;
					text += art.ReadRow(marks[position], artRow, position) + "│";
				}

				text += "\n";
			}

			text += art.DrawBorder(size, boardRow + 1) + "\n";
		}

		return text;
	}

	// Gör en riktig kopia av brädet.
	// Det är en riktig kopia med en egen array. När LineCompletion provar ett drag på kopian påverkas därför inte det riktiga brädet.
	public Board Copy()
	{
		Board copy = new Board(size);
		Array.Copy(marks, copy.marks, marks.Length);
		copy.history.AddRange(history);
		return copy;
	}

	// Lista över lediga kolumner.
	public List<int> ListFreeColumns()
	{
		List<int> columns = new List<int>();

		for (int column = 0; column < size; column++)
		{
			if (marks[column] == Mark.Empty)
			{
				columns.Add(column);
			}
		}

		return columns;
	}

	// Hittar ledig ruta så långt ner i columnen som möjligt.
	public int FindLowestFree(int column)
	{
		int cell = column + (size - 1) * size;

		while (marks[cell] != Mark.Empty)
		{
			cell -= size;
		}

		return cell;
	}

	// Räknar märken.
	public int CountMarks(Mark mark)
	{
		return marks.Count(m => m == mark);
	}

	// Tar bort det äldsta räknade märket.
	public void RemoveOldest(Mark mark)
	{
		foreach (int position in history)
		{
			if (marks[position] == mark)
			{
				marks[position] = Mark.Empty;
				history.Remove(position);
				return;
			}
		}
	}
}