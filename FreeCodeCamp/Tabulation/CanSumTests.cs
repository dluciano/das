using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Tabulation;

/// <summary>
/// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
/// </summary>
public class CanSumTests
{
    [Theory]
    [InlineData(0, new[] { 3, 5 }, true)]
    [InlineData(4, new[] { 3, 5 }, false)]
    [InlineData(7, new[] { 5, 3, 4, 7 }, true)]
    [InlineData(8, new[] { 2, 3, 5 }, true)]
    [InlineData(8, new[] { 1, 4, 5 }, true)]
    [InlineData(100, new[] { 1, 2, 5, 25 }, true)]
    public void CanSumUnitTest(int targetSum, int[] numbers, bool expectedResult)
    {
        // act
        var act = () => CanSum(targetSum, numbers);

        // assert
        var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
        result.ShouldBe(expectedResult);
    }

    public static bool CanSum(int targetSum, int[] numbers)
    {
        var dp = new bool[targetSum + 1];
        dp[0] = true;
        for (int i = 0; i < dp.Length; i++)
        {
            var current = dp[i];
            if (!current)
                continue;

            foreach (var number in numbers)
            {
                var cIndex = i + number;
                if (cIndex < dp.Length)
                    dp[cIndex] = true;
            }
        }
        return dp[targetSum];
    }
}
