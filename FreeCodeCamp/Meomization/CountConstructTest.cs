using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Meomization
{
    /// <summary>
    /// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
    /// </summary>
    public class CountConstructTest
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
            var act = () => CountConstruct(target, wordBank, new());

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        public static int CountConstruct(string target, string[] wordBank, Dictionary<string, int> memo)
        {
            if (memo.ContainsKey(target)) return memo[target];
            if (target == "") return 1;
            var sum = 0;

            foreach (var word in wordBank)
            {
                if (target.IndexOf(word) == 0)
                {
                    var newTarget = target[word.Length..];
                    sum += CountConstruct(newTarget, wordBank, memo);
                }
            }

            memo[target] = sum;
            return sum;
        }
    }
}
