using NUnit.Framework;
using FluentAssertions;

namespace Abrahams.SnippetLibrary.Test
{
    [TestFixture]
    public class MainPageViewModel_UnitTest
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            answer.Should().Be(42, "Some useful error message");
        }
    }
}