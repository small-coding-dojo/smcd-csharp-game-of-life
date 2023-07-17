using Xunit;

namespace GameOfLife.Tests;

public class UniverseLifecycleTest
{
    [Fact]
    public void OneIterationWithSingleAliveCell()
    {
        var universe = new UniverseAdapter(1, 1, true);
        universe.Iterate();
        Assert.False(universe.CellAt(0, 0).IsAlive());
    }
}
