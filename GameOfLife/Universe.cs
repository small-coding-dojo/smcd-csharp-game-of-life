using System.Collections.Generic;

namespace GameOfLife;

public class Universe
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly Cell[,] _cells;

    // csharpier-ignore
    private readonly List<(int, int)> _relativeCoordinateOfNeighbor = new ()
    {
        (-1, -1), (-1, 0), (-1, 1),
        ( 0, -1),          ( 0, 1),
        ( 1, -1), ( 1, 0), ( 1, 1)
    };

    public Universe(int rows, int columns, bool cellsAliveAtInitialization)
    {
        _rows = rows;
        _columns = columns;
        _cells = new Cell[_rows, _columns];
        for (var row = 0; row < _rows; row++)
        {
            for (var column = 0; column < _columns; column++)
            {
                _cells[row, column] = new Cell(cellsAliveAtInitialization);
            }
        }
    }

    public int CellsLength => _cells.Length;

    public void Iterate()
    {
        for (var row = 0; row < _rows; row++)
        {
            for (var column = 0; column < _columns; column++)
            {
                var nextState = _cells[row, column].WillBeAliveInNextIncarnation(
                    CountLivingNeighbors(row, column)
                );
                _cells[row, column] = new Cell(nextState);
            }
        }
    }

    private int CountLivingNeighbors(int row, int column)
    {
        var counter = 0;

        foreach (var (rowNeighbor, columnNeighbor) in _relativeCoordinateOfNeighbor)
        {
            var rowToCheck = row + rowNeighbor;
            var columnToCheck = column + columnNeighbor;

            if (IsCellInUniverse(rowToCheck, columnToCheck))
            {
                counter += _cells[rowToCheck, columnToCheck].IsAlive() ? 1 : 0;
            }
        }

        return counter;
    }

    private bool IsCellInUniverse(int rowToCheck, int columnToCheck)
    {
        return rowToCheck >= 0
            && columnToCheck >= 0
            && rowToCheck < _cells.GetLength(0)
            && columnToCheck < _cells.GetLength(1);
    }

    public void MakeAlive(int row, int column)
    {
        _cells[row, column] = new Cell(true);
    }

    public Cell CellAt(int row, int column) => _cells[row, column];

    public int GetLivingNeighbors(int row, int column) => CountLivingNeighbors(row, column);
}
