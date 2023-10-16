using Xunit;

namespace GameOfLife.Tests;

public class UniverseBuilderTest
{
    [Fact]
    public void BuildEmptyUniverse()
    {
        var universe = UniverseBuilder.Build("");
        Assert.Equal(0, universe.CellsLength);
    }

    [Fact]
    public void Build1X1UniverseWithAnAliveCell()
    {
        var universe = UniverseBuilder.Build("O");
        Assert.Equal(1, universe.CellsLength);
        Assert.True(universe.CellAt(0, 0).IsAlive());
    }
}
