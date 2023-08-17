using System.Collections.Generic;

namespace GameOfLife;

public class Universe
{
    private readonly int _rows;
    private readonly int _columns;
    protected readonly Cell[,] Cells;

    // csharpier-ignore
    private readonly List<(int, int)> relativeCoordinateOfNeighbor = new ()
    {
        (-1, -1), (-1, 0), (-1, 1),
        ( 0, -1),          ( 0, 1),
        ( 1, -1), ( 1, 0), ( 1, 1)
    };

    public Universe(int rows, int columns, bool cellsAliveAtInitialization)
    {
        _rows = rows;
        _columns = columns;
        Cells = new Cell[_rows, _columns];
        for (var row = 0; row < _rows; row++)
        {
            for (var column = 0; column < _columns; column++)
            {
                Cells[row, column] = new Cell(cellsAliveAtInitialization);
            }
        }
    }

    public int CellsLength => Cells.Length;

    public void Iterate()
    {
        for (var row = 0; row < _rows; row++)
        {
            for (var column = 0; column < _columns; column++)
            {
                var nextState = Cells[row, column].WillBeAliveInNextIncarnation(
                    CountLivingNeighbors(row, column)
                );
                Cells[row, column] = new Cell(nextState);
            }
        }
    }

    protected int CountLivingNeighbors(int row, int column)
    {
        var counter = 0;

        foreach ((var rowNeighbor, var columnNeighbor) in relativeCoordinateOfNeighbor)
        {
            var rowToCheck = row + rowNeighbor;
            var columnToCheck = column + columnNeighbor;

            if (IsCellInUniverse(rowToCheck, columnToCheck))
            {
                counter += Cells[rowToCheck, columnToCheck].IsAlive() ? 1 : 0;
            }
        }

        return counter;
    }

    private bool IsCellInUniverse(int rowToCheck, int columnToCheck)
    {
        return rowToCheck >= 0
            && columnToCheck >= 0
            && rowToCheck < Cells.GetLength(0)
            && columnToCheck < Cells.GetLength(1);
    }

    public void MakeAlive(int row, int column)
    {
        Cells[row, column] = new Cell(true);
    }

    public Cell CellAt(int row, int column) => Cells[row, column];
    public int GetLivingNeighbors(int row, int column) => CountLivingNeighbors(row, column);
}
