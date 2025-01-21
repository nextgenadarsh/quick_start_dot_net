
using FluentAssertions;

namespace XunitDemo.Test.SharedTestContexts
{
    public class DatabaseFixture : IDisposable
    {
        public static List<string> Logs { get; private set; }

        static DatabaseFixture() {
            Logs = new List<string>();
        }
        public DatabaseFixture()
        {
            // Initialize database context
            Logs.Add("Initializing DbContext");
        }
        public void Dispose()
        {
            // Dispose
        }
    }

    /// <summary>
    /// When to use: when you want to create a single test context and share it among tests in several test classes, and have it cleaned up after all the tests in the test classes have finished. 
    /// </summary>
    [CollectionDefinition("GlobalNames Collection")]
    public class GobalNamesCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("GlobalNames Collection")]
    public class CollectionFixtureContextTest
    {
        private readonly DatabaseFixture _databaseFixture;

        public CollectionFixtureContextTest(DatabaseFixture databaseFixture)
        {
            this._databaseFixture = databaseFixture;
        }

        [Fact]
        public void OnlyOnlyDbContextShouldBeInitialized1()
        {
            DatabaseFixture.Logs.Count.Should().Be(1);
        }

        [Fact]
        public void OnlyOnlyDbContextShouldBeInitialized2()
        {
            DatabaseFixture.Logs.Count.Should().Be(1);
        }
    }

    [Collection("GlobalNames Collection")]
    public class CollectionFixtureContextTestDuplicate
    {
        private readonly DatabaseFixture _databaseFixture;

        public CollectionFixtureContextTestDuplicate(DatabaseFixture databaseFixture)
        {
            this._databaseFixture = databaseFixture;
        }

        [Fact]
        public void OnlyOnlyDbContextShouldBeInitialized1()
        {
            DatabaseFixture.Logs.Count.Should().Be(1);
        }

        [Fact]
        public void OnlyOnlyDbContextShouldBeInitialized2()
        {
            DatabaseFixture.Logs.Count.Should().Be(1);
        }
    }
}
