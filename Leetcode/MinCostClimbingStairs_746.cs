using DSA.Tests.Leetcode.TestCasesData;
using Shouldly;
using Xunit;

namespace DSA.Tests.Leetcode;
/// <summary>
/// @see: https://leetcode.com/problems/min-cost-climbing-stairs/
/// </summary>
public class MinCostClimbingStairs_746
{
    [Theory]
    [InlineData(new int[] { 3, 5 }, 3)]
    [InlineData(new int[] { 5, 3 }, 3)]
    [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    [InlineData(new int[] { 10, 15, 20 }, 15)]
    [ClassData(typeof(MinCostClimbingStairsTestCasesData))]
    public void TestSteps(int[] arr, int expected)
    {
        // act
        var result = ShortestStepsMemo(arr, new());

        // assert
        result.ShouldBe(expected);
    }

    public static int ShortestStepsMemo(int[] arr, Dictionary<int, int> memo, int i = -1)
    {
        if (memo.ContainsKey(i)) return memo[i];

        if (i >= arr.Length)
            return 0;

        var left = ShortestStepsMemo(arr, memo, i + 1);
        var right = ShortestStepsMemo(arr, memo, i + 2);

        var cost = i < 0 ? 0 : arr[i];
        var min = Math.Min(left, right);
        var sum = cost + min;
        memo[i] = sum;

        return sum;
    }

    public static int ShortestSteps(int[] arr, int i = -1)
    {
        if (arr.Length == 1)
            return arr[0];

        if (i >= arr.Length)
            return 0;

        var left = ShortestSteps(arr, i + 1);
        var right = ShortestSteps(arr, i + 2);

        var cost = i < 0 ? 0 : arr[i];
        var min = Math.Min(left, right);
        var sum = cost + min;
        return sum;
    }
}