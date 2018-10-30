using NLibrary.Util;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace NLibrary.Tests.Util
{
    public class RandomHelperTests : TestBase
    {
        public RandomHelperTests(ITestOutputHelper logger)
            : base(logger)
        {
        }

        [Fact]
        public void RandomIntegerTest()
        {
            const int maxValue = 999;
            for (int x = 0; x < 500; x++)
            {
                int randomNumber = RandomHelper.Next(maxValue);
                Assert.InRange(randomNumber, 0, maxValue);
            }
        }

        [Fact]
        public void RandomIntegerInRangeTest()
        {
            const int minValue = 250;
            const int maxValue = 500;
            for (int x = 0; x < 250; x++)
            {
                int randomNumber = RandomHelper.Next(minValue, maxValue);
                Assert.InRange(randomNumber, minValue, maxValue);
            }
        }

        [Fact]
        public void RandomDecimalTest()
        {
            const decimal maxValue = 999.999999999m;
            for (int x = 0; x < 500; x++)
            {
                decimal randomNumber = RandomHelper.NextDecimal(0, maxValue);
                Logger.WriteLine("Random Decimal: {0}", randomNumber);
                Assert.InRange(randomNumber, 0, maxValue);
            }
        }

        [Fact]
        public void RandomStringTest()
        {
            var stringRegex = new Regex("^[a-zA-Z0-9!@#$%^&*()_=+]*$");
            for (int i = 0; i < 50; i++)
            {
                string randomString = RandomHelper.NextString(12);
                Logger.WriteLine("Random String: {0}", randomString);
                bool result = stringRegex.IsMatch(randomString);
                Assert.True(result);
            }
        }

        [Fact]
        public void RandomAlphanumericTest()
        {
            var alphanumericRegex = new Regex("^[a-zA-Z0-9]*$");
            for (int i = 0; i < 50; i++)
            {
                string randomString = RandomHelper.NextAlphanumeric(12);
                Logger.WriteLine("Random Alphanumeric: {0}", randomString);
                bool result = alphanumericRegex.IsMatch(randomString);
                Assert.True(result);
            }
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void RandomNumericTest(int length)
        {
            var numericRegex = new Regex("^[0-9]*$");
            for (int i = 0; i < 10; i++)
            {
                string randomString = RandomHelper.NextNumeric(length);
                Logger.WriteLine("Random Numeric Length: {0}, Output: {1}", length, randomString);
                bool result = numericRegex.IsMatch(randomString);
                Assert.True(result);
            }
        }
    }
}
