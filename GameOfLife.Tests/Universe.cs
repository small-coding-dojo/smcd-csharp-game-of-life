namespace GameOfLife.Tests
{
    internal static class Universe
    {
        public static Cell GetNextIncarnation(Cell cell, int numberOfAliveNeighbors)
        {
            return new Cell(false);
        }
    }
}