using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Tabulation
{
    /// <summary>
    /// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
    /// </summary>
    public class CountConstructTests
    {
        [Theory]
        [InlineData("purple", new[] { "purp", "p", "ur", "le", "purpl" }, 2)]
        [InlineData("", new string[] { "cat", "dog", "mouse" }, 1)]
        [InlineData("abcdef", new[] { "ab", "abc", "cd", "def", "abcd" }, 1)]
        [InlineData("skateboard", new[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, 0)]
        [InlineData("enterapotentpot", new[] { "a", "p", "ent", "enter", "ot", "o", "t" }, 4)]
        [InlineData("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, 0)]
        public void CountConstructUnitTest(string target, string[] wordBank, int expectedResult)
        {
            // act
            var act = () => CountConstruct(target, wordBank);

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        public static int CountConstruct(string target, string[] wordBank)
        {
            var dp = new int[target.Length + 1];
            dp[0] = 1;

            for (var i = 0; i < target.Length + 1; i++)
            {
                for (int j = 0; j < wordBank.Length; j++)
                {
                    var word = wordBank[j];
                    if (word.Length <= target.Length - i && target.Substring(i, word.Length) == word)
                    {
                        if (i + word.Length < dp.Length)
                            dp[i + word.Length] += dp[i];
                    }
                }
            }

            return dp[target.Length];
        }
    }
}
