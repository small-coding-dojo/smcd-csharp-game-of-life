using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTest
    {
        private static Cell _aliveCell;

        [Fact]
        public void TestThereIsACell()
        {
            // Given
            // nothing

            // When
            Cell cell = new Cell(true);

            // Then
            Assert.NotNull(cell);
        }

        [Fact]
        public void TestTheCellIsAlive()
        {
            // Given
            _aliveCell = new Cell(true);

            // When
            // always
        
            // Then
            Assert.True(_aliveCell.IsAlive());
        }
        
        [Fact]
        public void TestTheCellIsDead()
        {
            // Given
            Cell deadCell = new Cell(false);

            // When
            // always
        
            // Then
            Assert.False(deadCell.IsAlive());
        }
        
        [Fact]
        public void TestTheCellIsAliveByDefault()
        {
            // Given
            Cell aliveCell = new Cell(true);

            // When
            // always
        
            // Then
            Assert.True(aliveCell.IsAlive());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void RuleNumberOne(int numberOfAliveNeighbors)
        {
            // Given
            Cell aliveCell = new Cell(true);

            // When
            Cell actual = Universe.GetNextIncarnation(aliveCell, numberOfAliveNeighbors);
        
            // Then
            Assert.False(actual.IsAlive());
        }
        
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void RuleNumberTwo(int numberOfAliveNeighbors)
        {
            // Given
            Cell aliveCell = new Cell(true);

            // When
            Cell actual = Universe.GetNextIncarnation(aliveCell, numberOfAliveNeighbors);
        
            // Then
            Assert.False(actual.IsAlive());
        }
    }
}