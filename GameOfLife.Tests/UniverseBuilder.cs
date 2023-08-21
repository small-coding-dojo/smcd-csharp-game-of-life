namespace GameOfLife.Tests;

public class UniverseBuilder
{
    public Universe Build ( string s ) {
        if (s == "O")
        {
            return new Universe(1, 1, true);    
        }
        return new Universe(0, 0, false);
    }
}