using System;
using GraphTraversal;
using Xunit;

namespace Tests
{
    public class NumberOfTrips_Tests : IClassFixture<GraphFixture>
    {
        GraphFixture _graphFixture;

        public NumberOfTrips_Tests(GraphFixture graphFixture)
        {
            _graphFixture = graphFixture;
        }

        [Fact]
        public void VerifyNumberOfTrips_CtoC_WithMax3Stops()
        {
            // Question 6: # of trips starting at C and ending at C with <= 3 stops
            Assert.Equal(2, _graphFixture.graph.NumberOfTripsBetweenVerticiesLessThanStops('C', 'C', 3));
        }

        [Fact]
        public void VerifyNumberOfTrips_AtoC_WithExactly4Stops()
        {
            // Question 7: # of trips starting at A and ending at C with <= 4 stops
            Assert.Equal(3, _graphFixture.graph.NumberOfTripsBetweenVerticiesWithExactStops('A', 'C', 4));
        }
    }
}
