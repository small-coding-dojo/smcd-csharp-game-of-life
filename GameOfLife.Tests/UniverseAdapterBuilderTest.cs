using Xunit;

namespace GameOfLife.Tests;

public class UniverseAdapterBuilderTest
{
    [Fact]
    public void BuildEmptyUniverseAdapter()
    {
        var universeAdapterBuilder = new UniverseAdapterBuilder();
        var universeAdapter = universeAdapterBuilder.Build("");
        Assert.Equal(0, universeAdapter.CellsLength);
    }
    
    [Fact]
    public void Build1X1UniverseAdapter()
    {
        var universeAdapterBuilder = new UniverseAdapterBuilder();
        var universeAdapter = universeAdapterBuilder.Build("O");
        Assert.Equal(1, universeAdapter.CellsLength);
    }
}
