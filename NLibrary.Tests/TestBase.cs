using Xunit.Abstractions;

namespace NLibrary.Tests
{
    public abstract class TestBase
    {
        /// <summary>
        /// Gets or sets the logger to use for writing text to be captured in the test results.
        /// </summary>
        protected ITestOutputHelper Logger { get; set; }

        protected TestBase(ITestOutputHelper logger)
        {
            this.Logger = logger;
        }
    }
}
