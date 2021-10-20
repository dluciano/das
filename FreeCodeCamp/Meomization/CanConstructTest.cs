using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Meomization
{
    /// <summary>
    /// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
    /// </summary>
    public class CanConstructTest
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
            var act = () => CanConstruct(target, wordBank, new());

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        public static bool CanConstruct(string target, string[] wordBank, Dictionary<string, bool> memo)
        {
            if (memo.ContainsKey(target)) return memo[target];
            if (target == "") return true;

            foreach (var word in wordBank)
            {
                if (target.IndexOf(word) == 0)
                {
                    var newTarget = target[word.Length..];
                    var canConstruct = CanConstruct(newTarget, wordBank, memo);

                    if (canConstruct)
                    {
                        memo[target] = true;
                        return true;
                    }
                }
            }

            memo[target] = false;
            return false;
        }
    }
}
