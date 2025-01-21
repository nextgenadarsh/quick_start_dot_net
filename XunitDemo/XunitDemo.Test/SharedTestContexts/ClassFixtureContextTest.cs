
using FluentAssertions;

namespace XunitDemo.Test.SharedTestContexts
{
    /// <summary>
    /// When to use: when you want to create a single test context and share it among all the tests in the class, and have it cleaned up after all the tests in the class have finished. 
    /// </summary>
    public class GlobalNamesFixture : IDisposable
    {
        public static List<string> Logs { get; private set; }

        static GlobalNamesFixture()
        {
            Logs = [];
        }

        public GlobalNamesFixture()
        {
            Logs.Add("Constructor Initialized");
        }

        public void Dispose()
        {
            // Dispose
        }
    }

    public class ClassFixtureContextTest : IClassFixture<GlobalNamesFixture>
    {
        private readonly GlobalNamesFixture _databaseFixture;

        public ClassFixtureContextTest(GlobalNamesFixture databaseFixture)
        {
            this._databaseFixture = databaseFixture;
        }

        [Fact]
        public void TestFirst()
        {
            DatabaseFixture.Logs.Count.Should().Be(1);
        }

        [Fact]
        public void TestSecond()
        {
            DatabaseFixture.Logs.Count.Should().Be(1);
        }
    }
}
