class ClassicRules
{
    public virtual bool IsValidMove(Board board, inte cell)
    {
        return board.IsFree(cell);
    }
    public virtual void Place(Board board, int cell, Mark mark)
    {
        
    }
    public bool IsWinner(Board board, Mark mark)
    {
        
    }
    public bool IsDraw(Board board)
    {
        return board.IsFull();
    }
}