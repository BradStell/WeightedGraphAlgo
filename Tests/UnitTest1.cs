using System;
using GraphTraversal;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IDirectedGraph<char> graph = new DirectedGraph<char>();

            Assert.True(5 == 5);
            Assert.False(5 == 4);
        }
    }
}
