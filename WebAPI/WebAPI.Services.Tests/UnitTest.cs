using FluentAssertions;

namespace WebAPI.Services.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(20, 2, 22)]
        [InlineData(100, 22, 122)]
        [InlineData(-900,100,-800)]
        public void TestFunctionForCiCdPipeline(int x, int y, int expected)
        {
            var actualSum = x + y;
            actualSum.Should().NotBe(expected);
        }
    }
}