Console.WriteLine("Hello, World!");
Console.WriteLine("Testar");
Console.WriteLine("Testar3");
Console.WriteLine("Testar");
Console.WriteLine("3 i rad eller 5 i rad?");

Board board = new Board();
board.Place(4, Mark.X);

Display display = new Display(new Art());
display.DrawBoard(board);

HumanPlayer player = new HumanPlayer("Gustaf", Mark.O);
player.PlayTurn(board);

display.DrawBoard(board);