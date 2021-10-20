using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Tabulation
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(6, 8)]
        [InlineData(50, 12586269025)]
        public void FibTest(long n, long expectedResult)
        {
            // act
            var act = () => Fib(n);

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(9, 34)]
        [InlineData(10, 55)]
        [InlineData(50, 12586269025)]
        public void FibTab2Test(long n, long expectedResult)
        {
            // act
            var act = () => FibShort(n);

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        public long Fib(long n)
        {
            var dp = new long[n + 1];
            dp[1] = 1;
            for (int i = 0; i < dp.Length - 2; i++)
            {
                dp[i + 1] += dp[i];
                dp[i + 2] += dp[i];
            }
            dp[dp.Length - 1] += dp[dp.Length - 2];
            return dp[n];
        }

        public long FibShort(long n)
        {
            long a = 0;
            long b = 1;
            long c = a + b;
            for (long i = 0; i < n - 1; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}
