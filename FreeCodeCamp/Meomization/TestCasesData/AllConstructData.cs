using System.Collections;

namespace DSA.Tests.FreeCodeCamp.Meomization.TestCasesData
{
    internal class AllConstructData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "purple",
                new[] { "purp", "p", "ur", "le", "purpl" },
                new[] {
                    new[] { "purp", "le" },
                    new[]{ "p", "ur","p", "le"}
                }
            };
            yield return new object[]
            {
                "hello",
                new string[] { "cat", "dog", "mouse" },
                new string[] { }
            };
            yield return new object[]
            {
                string.Empty,
                new string[] { "cat", "dog", "mouse" },
                new [] { new string[0] }
            };
            yield return new object[] {
                "abcdef",
                new[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" },
                new[] {
                    new[]{"ab", "cd", "ef" },
                    new[]{"ab", "c", "def" },
                    new[]{"abc", "def" },
                    new[]{"abcd", "ef" }
                }
            };
            yield return new object[] {
                "skateboard",
                new[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" },
                new string[][] {  }
            };
            yield return new object[] {
                "enterapotentpot",
                new[] { "a", "p", "ent", "enter", "ot", "o", "t" },
                new string[][] {
                        new []{"enter", "a", "p", "ot", "ent", "p", "ot" },
                        new []{"enter", "a", "p", "ot", "ent", "p", "o", "t"},
                        new []{"enter", "a", "p", "o", "t", "ent", "p", "ot"},
                        new []{"enter", "a", "p", "o", "t", "ent", "p", "o", "t"}
                    }
            };
            yield return new object[] {
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" },
                new string[][] {  }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
