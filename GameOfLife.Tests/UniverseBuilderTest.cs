using Xunit;

namespace GameOfLife.Tests;

public class UniverseBuilderTest
{
    [Fact]
    public void BuildEmptyUniverse()
    {
        var universeBuilder = new UniverseBuilder();
        var universe = universeBuilder.Build("");
        Assert.Equal(0, universe.CellsLength);
    }
    
    [Fact]
    public void Build1X1Universe()
    {
        var universeBuilder = new UniverseBuilder();
        var universe = universeBuilder.Build("O");
        Assert.Equal(1, universe.CellsLength);
    }
}
