using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Tabulation;

/// <summary>
/// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
/// </summary>
public class CanConstructTests
{
    [Theory]
    [InlineData("", new string[] { "cat", "dog", "mouse" }, true)]
    [InlineData("abcdef", new[] { "ab", "abc", "cd", "def", "abcd" }, true)]
    [InlineData("skateboard", new[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, false)]
    [InlineData("enterapotentpot", new[] { "a", "p", "ent", "enter", "ot", "o", "t" }, true)]
    [InlineData("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, false)]
    public void CanConstructUnitTest(string target, string[] wordBank, bool expectedResult)
    {
        // act
        var act = () => CanConstruct(target, wordBank);

        // assert
        var result = act();// Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
        result.ShouldBe(expectedResult);
    }

    public static bool CanConstruct(string target, string[] wordBank)
    {
        var dp = new bool[target.Length + 1];
        dp[0] = true;

        for (var i = 0; i < target.Length + 1; i++)
        {
            var current = dp[i];
            if (current)
            {
                for (int j = 0; j < wordBank.Length; j++)
                {
                    var word = wordBank[j];
                    if (word.Length <= target.Length - i && target.Substring(i, word.Length) == word)
                    {
                        if (i + word.Length < dp.Length)
                            dp[i + word.Length] = true;
                    }
                }
            }
        }

        return dp[target.Length];
    }
}
