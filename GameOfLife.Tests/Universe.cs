namespace GameOfLife.Tests
{
    internal static class Universe
    {
        public static Cell GetNextIncarnation(Cell cell, int numberOfAliveNeighbors)
        {
            if ( numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3) 
                return new Cell(true);
            return new Cell(false);
        }
    }
}