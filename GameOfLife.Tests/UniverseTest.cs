using Xunit;

namespace GameOfLife.Tests;

public class UniverseTest
{
    private class UniverseAdapter : Universe
    {
        public UniverseAdapter(int rows, int columns, bool cellsAliveAtInitialization) : base(rows, columns,
            cellsAliveAtInitialization)
        {
        }

        public int CellsLength => Cells.Length;

        public Cell CellAt(int row, int column) => Cells[row, column];
    }

    [Fact]
    public void CreatesUniverseWithOneAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);

        Assert.Equal(1, universe.CellsLength);
        Assert.NotNull(universe.CellAt(0, 0));
        Assert.True(universe.CellAt(0, 0).IsAlive());
    }

    [Fact]
    public void CreatesUniverseWithOneDeadCell()
    {
        var universe = new UniverseAdapter(1, 1, false);
        Assert.False(universe.CellAt(0, 0).IsAlive());
    }

    [Fact]
    public void OneIterationWithSingleAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);
        universe.Iterate();
        Assert.False(universe.CellAt(0, 0).IsAlive());
    }

    [Fact]
    public void UniverseHas2AliveCells()
    {
        var universe = new UniverseAdapter(2, 1, true);
        Assert.Equal(2, universe.CellsLength);
        Assert.True(universe.CellAt(0, 0).IsAlive());
        Assert.True(universe.CellAt(1, 0).IsAlive());
    }
    
    [Fact]
    public void UniverseHas2AliveCellsVertical()
    {
        var universe = new UniverseAdapter(1, 2, true);
        Assert.Equal(2, universe.CellsLength);
        Assert.True(universe.CellAt(0, 0).IsAlive());
        Assert.True(universe.CellAt(0, 1).IsAlive());
    }
}