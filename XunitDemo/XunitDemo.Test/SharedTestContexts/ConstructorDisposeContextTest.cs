using FluentAssertions;

namespace XunitDemo.Test.SharedTestContexts
{
    /// <summary>
    /// All tests are executed with fresh Stack object with intially 1 element.
    /// Use this pattern when you want a clean test context for every test (sharing the setup and cleanup code, without sharing the object instance). 
    /// </summary>
    public class ConstructorDisposeContextTest : IDisposable
    {
        private readonly Stack<int> _stack;
        
        public ConstructorDisposeContextTest()
        {
            _stack = new Stack<int>();
            _stack.Push(0);
        }

        public void Dispose()
        {
            // Dispose anything required to be disposed
        }

        [Fact]
        public void NumbersShouldHaveCount1()
        {
            _stack.Push(1);
            _stack.Count.Should().Be(2);
        }

        [Fact]
        public void NumbersShouldHaveCount0()
        {
            _stack.Count.Should().Be(1);
        }

        [Fact]
        public void NumbersShouldHaveCount2()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Count.Should().Be(3);
        }
    }
}
