namespace GameOfLife.Tests;

public class Universe
{
    protected Cell[,] _cells = new Cell[1, 1];
    public Universe(int rows, int cols, bool initialCellState)
    {
        _cells[0, 0] = new Cell(initialCellState);
    }
}