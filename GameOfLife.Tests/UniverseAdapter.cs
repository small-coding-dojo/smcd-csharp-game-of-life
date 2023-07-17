namespace GameOfLife.Tests;

public class UniverseAdapter : Universe
{
    public UniverseAdapter(int rows, int columns, bool cellsAliveAtInitialization)
        : base(rows, columns, cellsAliveAtInitialization) { }

    public int CellsLength => Cells.Length;

    public Cell CellAt(int row, int column) => Cells[row, column];

    public int GetLivingNeighbors(int row, int column) => CountLivingNeighbors(row, column);

    public void MakeAlive(int row, int column) => base.MakeAlive(row, column);
}
