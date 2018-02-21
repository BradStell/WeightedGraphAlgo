using System;
using GraphTraversal;
using Xunit;

namespace Tests
{
    public class DistanceOfRoute_Tests : IClassFixture<GraphFixture>
    {
        GraphFixture _graphFixture;

        public DistanceOfRoute_Tests(GraphFixture graphFixture)
        {
            _graphFixture = graphFixture;
        }

        [Fact]
        public void CalculateDistanceOfRoute_ABC()
        {
            // Question 1: The distance of the route A-B-C
            Assert.Equal("9", _graphFixture.graph.CalculatePathWeight(new char[] {'A', 'B', 'C'}));
        }

        [Fact]
        public void CalculateDistanceOfRoute_AD()
        {
            // Question 2: The distance of the route A-D
            Assert.Equal("5", _graphFixture.graph.CalculatePathWeight(new char[] {'A', 'D'}));
        }

        [Fact]
        public void CalculateDistanceOfRoute_ADC()
        {
            // Question 3: The distance of the route A-D-C
            Assert.Equal("13", _graphFixture.graph.CalculatePathWeight(new char[] {'A', 'D', 'C'}));
        }

        [Fact]
        public void CalculateDistanceOfRoute_AEBCD()
        {
            // Question 4: The distance of the route A-E-B-C-D
            Assert.Equal("22", _graphFixture.graph.CalculatePathWeight(new char[] {'A', 'E', 'B', 'C', 'D'}));
        }

        [Fact]
        public void CalculateDistanceOfRoute_AED()
        {
            // Question 5: The distance of the route A-E-D
            Assert.Equal("NO SUCH ROUTE", _graphFixture.graph.CalculatePathWeight(new char[] {'A', 'E', 'D'}));
        }
    }
}
