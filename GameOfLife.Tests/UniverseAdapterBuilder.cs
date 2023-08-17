namespace GameOfLife.Tests;

public class UniverseAdapterBuilder
{
    public UniverseAdapter Build ( string s ) {
        if (s == "O")
        {
            return new UniverseAdapter(1, 1, true);    
        }
        return new UniverseAdapter(0, 0, false);
    }
}