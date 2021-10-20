using DSA.Tests.FreeCodeCamp.Meomization.TestCasesData;
using Shouldly;
using Xunit;

namespace DSA.Tests.FreeCodeCamp.Meomization
{
    /// <summary>
    /// @see https://www.youtube.com/watch?v=oBt53YbR9Kk&t=4260s
    /// </summary>
    public class AllConstructTest
    {
        [Theory]
        [ClassData(typeof(AllConstructData))]
        public void AllConstructUnitTest(string target, string[] wordBank, string[][] expectedResult)
        {
            // act
            var act = () => AllCountConstruct(target, wordBank, new());

            // assert
            var result = Should.CompleteIn(act, TimeSpan.FromMilliseconds(400));
            result.ShouldBe(expectedResult);
        }

        public static string[][] AllCountConstruct(string target, string[] wordBank, Dictionary<string, string[][]> memo)
        {
            if (memo.ContainsKey(target)) return memo[target];
            if (target == "") return new string[][] { Array.Empty<string>() };

            var result = new List<string[]>();
            foreach (var word in wordBank)
            {
                if (target.IndexOf(word) == 0)
                {
                    var newTarget = target[word.Length..];
                    var suffixWays = AllCountConstruct(newTarget, wordBank, memo);
                    var targetWays = suffixWays.Select(way => way.Prepend(word).ToArray()).ToArray();
                    result.AddRange(targetWays);
                }
            }
            var r = result.ToArray();
            memo[target] = r;
            return r;
        }
    }
}
