class Board {

	private readonly Mark[] marks;

	public Board() {
		marks = new Mark[9];
	}


	public bool IsFree(int position) {
		return marks[position] == Mark.NULL;
	}

	public bool IsFull() {
    	return !marks.Contains(Mark.Empty);
	}

	//public bool IsFull()
	//public bool Holds(int position, Mark mark)
	//public void Place(int position, Mark mark)
	//public List<int> ListFreePositions()
	//public override string ToString()

}