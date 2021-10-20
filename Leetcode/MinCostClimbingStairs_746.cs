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
    public void TestStepsMemo(int[] arr, int expected)
    {
        // act
        var act = () => ShortestStepsMemo(arr, new());

        // assert
        var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData(new int[] { 3, 5 }, 3)]
    [InlineData(new int[] { 5, 3 }, 3)]
    [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    [InlineData(new int[] { 10, 15, 20 }, 15)]
    //[ClassData(typeof(MinCostClimbingStairsTestCasesData))] This would timeout
    public void TestStepsRecursiveTest(int[] arr, int expected)
    {
        // act
        var act = () => ShortestStepsRecursive(arr);

        // assert
        var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData(new int[] { 3, 5 }, 3)]
    [InlineData(new int[] { 5, 3 }, 3)]
    [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    [InlineData(new int[] { 10, 15, 20 }, 15)]
    [ClassData(typeof(MinCostClimbingStairsTestCasesData))]
    public void TestStepsBottomUp_Or_Tabulation(int[] arr, int expected)
    {
        // act
        var result = ShortestStepsTabulation(arr);

        // assert
        result.ShouldBe(expected);
    }

    public static int ShortestStepsTabulation(int[] cost)
    {
        for (var i = 2; i < cost.Length; i++)
        {
            cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
        }

        return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
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

    public static int ShortestStepsRecursive(int[] arr, int i = -1)
    {        
        if (i >= arr.Length)
            return 0;

        var left = ShortestStepsRecursive(arr, i + 1);
        var right = ShortestStepsRecursive(arr, i + 2);

        var cost = i < 0 ? 0 : arr[i];
        var min = Math.Min(left, right);
        var sum = cost + min;
        return sum;
    }
}