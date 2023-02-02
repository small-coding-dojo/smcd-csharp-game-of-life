using System.Linq;
using Xunit;

namespace GameOfLife.Tests;

public class UniverseTest
{
    private class UniverseAdapter : Universe
    {

        public UniverseAdapter(int rows, int cols, bool initialCellState) : base(rows, cols, initialCellState) { }

        public int Cells => _cells.Length;

        public Cell cellAt00 => _cells[0, 0];
    }

    [Fact]
    public void CreatesUniverseWithOneAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);

        Assert.Equal(1, universe.Cells);
        Assert.Equal(true, universe.cellAt00 is Cell);
        Assert.Equal(true, universe.cellAt00.IsAlive());
    }

    [Fact]
    public void CreatesUniverseWithOneDeadCell()
    {
        var universe = new UniverseAdapter(1, 1, false);
        Assert.Equal(false, universe.cellAt00.IsAlive());
    }
}