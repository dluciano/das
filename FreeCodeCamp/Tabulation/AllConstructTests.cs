using DSA.Tests.FreeCodeCamp.Tabulation.TestCasesData;
using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Tabulation;

/// <summary>
/// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
/// </summary>
public class AllConstructTests
{
    [Theory]
    [ClassData(typeof(AllConstructData))]
    public void AllConstructUnitTest(string target, string[] wordBank, string[][] expectedResult)
    {
        // act
        var act = () => AllCountConstruct(target, wordBank);

        // assert
        var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
        result.ShouldBe(expectedResult, ignoreOrder: true);
    }

    public static string[][] AllCountConstruct(string target, string[] wordBank)
    {
        var dp = new string[target.Length + 1][][];
        for (var i = 0; i < dp.Length; i++)
        {
            dp[i] = new string[0][];
        }

        dp[0] = new string[1][];
        dp[0][0] = new string[0];

        for (int i = 0; i <= target.Length; i++)
        {
            foreach (var word in wordBank)
            {
                if (word.Length <= target.Length - i && target.Substring(i, word.Length) == word)
                {
                    var newCombs = dp[i].Select(c => c.Append(word).ToArray()).ToArray();
                    dp[i + word.Length] = dp[i + word.Length].Concat(newCombs).ToArray();
                }
            }
        }

        return dp[target.Length];
    }
}
