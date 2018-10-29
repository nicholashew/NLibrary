using NLibrary.Util;
using Xunit;

namespace NLibrary.Tests.Util
{
    public class EncodeHelperTests
    {
        [Fact]
        public void EncodeDecodeBase64Test()
        {
            string original = "test1...";
            string encoded = EncodeHelper.EncodeBase64(original);
            string decoded = EncodeHelper.DecodeBase64(encoded);

            Assert.Equal(original, decoded);
        }


        [Fact]
        public void NUllEncodeDecodeBase64Test()
        {
            Assert.Equal("", EncodeHelper.EncodeBase64(null));
            Assert.Equal("", EncodeHelper.DecodeBase64(null));
        }

        [Theory]
        [InlineData("Zm9vOmJhcg==", "foo:bar")]
        [InlineData("", "")]
        [InlineData("", null)]
        public void EncodeBase64Test(string expected, string value)
        {
            Assert.Equal(expected, EncodeHelper.EncodeBase64(value));
        }
        
        [Theory]
        [InlineData("foo:bar", "Zm9vOmJhcg==")]
        [InlineData("username:password", "dXNlcm5hbWU6cGFzc3dvcmQ=")]
        [InlineData("", null)]
        public void DecodeBase64Test(string expected, string value)
        {
            Assert.Equal(expected, EncodeHelper.DecodeBase64(value));
        }
    }
}
