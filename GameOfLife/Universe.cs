using System.Collections.Generic;
using System.Linq;

namespace GameOfLife;

public class Universe
{
    protected readonly Cell[,] Cells;

    // csharpier-ignore
    private List<(int, int)> relativeCoordinateOfNeighbor = new ()
    {
        (-1, -1), (-1, 0), (-1, 1),
        ( 0, -1),          ( 0, 1),
        ( 1, -1), ( 1, 0), ( 1, 1)
    };

    public Universe(int rows, int columns, bool cellsAliveAtInitialization)
    {
        Cells = new Cell[rows, columns];
        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                Cells[row, column] = new Cell(cellsAliveAtInitialization);
            }
        }
    }

    public void Iterate()
    {
        bool nextState = Cells[0, 0].WillBeAliveInNextIncarnation(CountLivingNeighbors(0, 0));
        Cells[0, 0] = new Cell(nextState);
    }

    protected int CountLivingNeighbors(int row, int column)
    {
        var counter = 0;

        foreach (var (rowNeighbor, columnNeighbor) in relativeCoordinateOfNeighbor)
        {
            var rowToCheck = row + rowNeighbor;
            var columnToCheck = column + columnNeighbor;

            if (
                rowToCheck >= 0
                && columnToCheck >= 0
                && rowToCheck < Cells.GetLength(0)
                && columnToCheck < Cells.GetLength(1)
            )
            {
                counter += Cells[rowToCheck, columnToCheck].IsAlive() ? 1 : 0;
            }
        }

        return counter;
    }

    protected void MakeAlive(int row, int column)
    {
        Cells[row, column] = new Cell(true);
    }
}
