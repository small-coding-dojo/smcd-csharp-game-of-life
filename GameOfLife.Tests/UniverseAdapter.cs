namespace GameOfLife.Tests;

public class UniverseAdapter : Universe
{
    public UniverseAdapter(int rows, int columns, bool cellsAliveAtInitialization)
        : base(rows, columns, cellsAliveAtInitialization) { }
}
