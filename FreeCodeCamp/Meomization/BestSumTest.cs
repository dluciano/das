using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Meomization
{
    /// <summary>
    /// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
    /// </summary>
    public class BestSumTests
    {
        [Theory]
        [InlineData(4, new[] { 3, 5 }, null)]
        [InlineData(7, new[] { 5, 3, 4, 7 }, new int[] { 7 })]
        [InlineData(8, new[] { 2, 3, 5 }, new int[] { 3, 5 })]
        [InlineData(8, new[] { 1, 4, 5 }, new int[] { 4, 4 })]
        [InlineData(100, new[] { 1, 2, 5, 25 }, new int[] { 25, 25, 25, 25 })]
        public void BestSumUnitTest(int targetSum, int[] numbers, int[]? expectedResult)
        {
            // act
            var act = () => BestSum(targetSum, numbers, new());

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult, ignoreOrder: true);
        }

        public static int[]? BestSum(int targetSum, int[] numbers, Dictionary<int, int[]?> memo)
        {
            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;

            int[]? shortestComb = null;

            foreach (var num in numbers)
            {
                var remainder = targetSum - num;
                var result = BestSum(remainder, numbers, memo);
                if (result is not null)
                {
                    var comb = result.Append(num).ToArray();
                    if (shortestComb is null || comb.Length < shortestComb.Length)
                    {
                        shortestComb = comb;
                    }
                }
            }

            memo[targetSum] = shortestComb;
            return shortestComb;
        }
    }
}
