using NLibrary.Util;
using Xunit;

namespace NLibrary.Tests.Util
{
    public class StringHelperTests
    {
       
        [Fact]
        public void TrimStartTest()
        {
            Assert.Equal("abc-_-", StringHelper.TrimStart("-_-abc-_-", "-_-"));
        }
       
        [Theory]
        [InlineData("fred", "Fred")]
        [InlineData("fRED", "FRED")]
        public void LowerFirstTest(string expected, string value)
        {
            Assert.Equal(expected, StringHelper.LowerFirst(value));
        }

        [Fact]
        public void UpperFirstTest()
        {
            Assert.Equal("Fred", StringHelper.UpperFirst("fred"));
        }

        [Fact]
        public void TitleCaseTest()
        {
            Assert.Equal("Fred Rush", StringHelper.TitleCase("fred rush"));
        }

        [Theory]
        [InlineData("biosseguranca-precaucao-de-contato", "Biossegurança: precaução de contato")]
        [InlineData("biosseguranca-precau", "Biossegurança: precaução de contato", 20)]
        public void SlugifyTest(string expected, string value, int maxLength = 0)
        {
            Assert.Equal(expected, StringHelper.Slugify(value, maxLength));
        }

        [Theory]
        [InlineData("hi-diddly-ho there, neighborin...", "hi-diddly-ho there, neighborino", 30, "...")]
        [InlineData("hi-diddly-ho th...", "hi-diddly-ho there, neighborino", 15, "...")]
        [InlineData("hi-diddly-ho there, neig [...]", "hi-diddly-ho there, neighborino", 24, " [...]")]
        public void TruncateTest(string expected, string value, int maxLength, string omission)
        {
            Assert.Equal(expected, StringHelper.Truncate(value, maxLength, omission));
        }

        [Theory]
        [InlineData("***", "*", 3)]
        [InlineData("abcabc", "abc", 2)]
        [InlineData("", "abc", 0)]
        public void RepeatTest(string expected, string value, int n)
        {
            Assert.Equal(expected, StringHelper.Repeat(value, n));
        }

        [Fact]
        public void SplitTest()
        {
            var arr = StringHelper.Split("a-b-c", "-");

            Assert.True(arr.Length == 3);
            Assert.Equal("[a,b,c]", string.Format("[{0}]", string.Join(",", arr)));
        }

        [Theory]
        [InlineData("FOO BAR", "foo bar")]
        [InlineData("FOO_BAR", "foo_bar")]
        public void UpperCaseTest(string expected, string value)
        {
            Assert.Equal(expected, StringHelper.UpperCase(value));
        }

        [Theory]
        [InlineData("foo bar", "Foo Bar")]
        [InlineData("foo bar", "FOO BAR")]
        public void LowerCaseTest(string expected, string value)
        {
            Assert.Equal(expected, StringHelper.LowerCase(value));
        }
    }
}
