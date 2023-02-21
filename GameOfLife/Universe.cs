using System.Runtime.Serialization;

namespace GameOfLife.Tests;

public class Universe
{
    protected Cell[,] _cells = new Cell[1, 1];
    public Universe(int rows, int cols, bool initialCellState)
    {
        _cells[0, 0] = new Cell(initialCellState);
    }

    public void Iterate()
    {
        bool nextState = _cells[0, 0].WillBeAliveInNextIncarnation(CountLivingNeighbors(0,0));
        _cells[0,0] = new Cell(nextState);
    }

    private int CountLivingNeighbors(int row, int col)
    {
        return 0;
    }
}