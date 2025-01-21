//[assembly: AssemblyFixture(typeof(SqlDatabaseFixture))]
namespace XunitDemo.Test.SharedTestContexts
{
    public class SqlDatabaseFixture : IDisposable
    {
        public SqlDatabaseFixture()
        {
            // Initialize data in the test database
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }

        //public SqlConnection Db { get; private set; }
    }

    /// <summary>
    /// When to use: when you want to create a single test context and share it among all the tests in your test assembly. 
    /// </summary>
    public class AssemblyFixtureContextTest
    {
        private readonly SqlDatabaseFixture fixture;

        public AssemblyFixtureContextTest(SqlDatabaseFixture fixture)
        {
            this.fixture = fixture;
        }
    }

    public class AssemblyFixtureContextDuplicateTest
    {
        private readonly SqlDatabaseFixture fixture;

        public AssemblyFixtureContextDuplicateTest(SqlDatabaseFixture fixture)
        {
            this.fixture = fixture;
        }
    }
}
