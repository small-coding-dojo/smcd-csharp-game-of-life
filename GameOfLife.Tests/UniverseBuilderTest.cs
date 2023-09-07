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
    public void Build1X1Universe()
    {
        var universe = UniverseBuilder.Build("O");
        Assert.Equal(1, universe.CellsLength);
    }
}
