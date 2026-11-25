public class Board 
{

	private readonly Mark[] marks;

	public Board() 
	{
		marks = new Mark[9];
	}

	//Är rutan ledig?
	public bool IsFree(int position) 
	{
		return marks[position] == Mark.Null;
	}

	//Är brädet fullt?
	public bool IsFull() 
	{
    	foreach (Mark mark in marks) {
    		if (mark == Mark.Null) 
    		{
    			return false;
    		}
    	}
    	return true;
	}

	//Innehåller rutan vad som efterfrågas?
	public bool Holds(int position, Mark mark) 
	{
		return marks[position] == mark;
	}

	//Lägg en mark i rutan
	public void Place(int position, Mark mark)
	{
		if (marks[position] != Mark.Null)
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
			if (marks[i] == Mark.Null) 
			{
				freePositions.Add(i);
			}
		}

		return freePositions;
	}

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


	// Bygger brädet som text i tre rader med tre rutor var, där tomma rutor visas som mellanslag.
	//public override string ToString()

}