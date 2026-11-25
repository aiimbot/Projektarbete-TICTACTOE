Console.WriteLine("Hello, World!");
Console.WriteLine("Testar");
Console.WriteLine("Testar3");
Console.WriteLine("Testar");
Console.WriteLine("3 i rad eller 5 i rad?");

Board board = new Board();
board.Place(0, Mark.X);
board.Place(1, Mark.O);
board.Place(4, Mark.X);
board.Place(5, Mark.O);
board.Place(6, Mark.O);
board.Place(8, Mark.X);

Display display = new Display(new Art());
display.DrawBoard(board);