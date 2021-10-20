using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Tabulation
{
    public class GridTravellerTests
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 3)]
        [InlineData(3, 2, 3)]
        [InlineData(3, 3, 6)]
        [InlineData(18, 18, 2333606220)]
        public void GridTravelleTest(int m, int n, long expectedResult)
        {
            // act
            var act = () => GridTraveller(m, n);

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        public long GridTraveller(int m, int n)
        {
            var table = new long[m + 1, n + 1];
            table[1, 1] = 1;
            for (int i = 0; i <= m; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    var current = table[i, j];
                    if (j + 1 <= n) table[i, j + 1] += current;
                    if (i + 1 <= m) table[i + 1, j] += current;
                }
            }

            return table[m, n];
        }

    }
}
