using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTest
    {
        private Cell _aliveCell;

        public CellTest () 
        {
            _aliveCell = new Cell(true);
        }

        [Fact]
        public void TheCellIsAlive()
        {
            Assert.True(_aliveCell.IsAlive());
        }
        
        [Fact]
        public void TheCellIsDead()
        {
            // Given
            Cell deadCell = new Cell(false);

            // When
            // always
        
            // Then
            Assert.False(deadCell.IsAlive());
        }

        [Theory(DisplayName = "Any live cell with fewer than two live neighbours dies, as if by underpopulation.")]
        [InlineData(0)]
        [InlineData(1)]
        public void Rule1_DiesWithFewerThanTwoAliveNeighbors(int numberOfAliveNeighbors)
        {
            Cell actual = Universe.GetNextIncarnation(_aliveCell, numberOfAliveNeighbors);
        
            // Then
            Assert.False(actual.IsAlive());
        }
        
        [Theory(DisplayName = "Any live cell with more than three live neighbours dies, as if by overpopulation.")]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Rule3_DiesWithMoreThanThreeNeighbors(int numberOfAliveNeighbors)
        {
            Cell actual = Universe.GetNextIncarnation(_aliveCell, numberOfAliveNeighbors);
        
            // Then
            Assert.False(actual.IsAlive());
        }
    }
}