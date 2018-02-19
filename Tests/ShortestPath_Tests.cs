using System;
using GraphTraversal;
using Xunit;

namespace Tests
{
    public class ShortestPath_Tests : IClassFixture<GraphFixture>
    {
        GraphFixture _graphFixture;

        public ShortestPath_Tests(GraphFixture graphFixture)
        {
            _graphFixture = graphFixture;
        }

        [Fact]
        public void VerifyShortestPathFrom_AtoA()
        {
            // Question 8: Shortest path from A-C
            Assert.Equal(9, _graphFixture.graph.ShortestPath('A', 'C'));
        }

        [Fact]
        public void VerifyShortestPathFrom_BtoB()
        {
            // Question 9: Shortest path from B-B
            Assert.Equal(9, _graphFixture.graph.ShortestPath('B', 'B'));
        }
    }
}
