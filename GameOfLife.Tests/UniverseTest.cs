using Xunit;

namespace GameOfLife.Tests;

public class UniverseTest
{
    private class UniverseAdapter : Universe
    {

        public UniverseAdapter(int rows, int cols, bool cellsAliveAtInitialization) : base(rows, cols, cellsAliveAtInitialization) { }

        public int CellsLength => Cells.Length;

        public Cell CellAt00 => Cells[0, 0];
    }

    [Fact]
    public void CreatesUniverseWithOneAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);

        Assert.Equal(1, universe.CellsLength);
        Assert.NotNull(universe.CellAt00);
        Assert.True(universe.CellAt00.IsAlive());
    }

    [Fact]
    public void CreatesUniverseWithOneDeadCell()
    {
        var universe = new UniverseAdapter(1, 1, false);
        Assert.False(universe.CellAt00.IsAlive());
    }
    
    [Fact]
    public void OneIterationWithSingleAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);
        universe.Iterate();
        Assert.False(universe.CellAt00.IsAlive());
    }
}