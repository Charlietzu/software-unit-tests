using Xunit;

namespace Features.Tests
{
    [TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")]
    public class TestsOrder
    {
        public static bool Test1Called;
        public static bool Test2Called;
        public static bool Test3Called;
        public static bool Test4Called;

        [Fact(DisplayName = "Test 04"), TestPriority(3)]
        [Trait("Category", "Tests Order")]
        public void Test04()
        {
            Test4Called = true;

            Assert.True(Test3Called);
            Assert.True(Test1Called);
            Assert.False(Test2Called);
        }

        [Fact(DisplayName = "Test 01"), TestPriority(2)]
        [Trait("Category", "Tests Order")]
        public void Test01()
        {
            Test1Called = true;

            Assert.True(Test3Called);
            Assert.False(Test4Called);
            Assert.False(Test2Called);
        }

        [Fact(DisplayName = "Test 03"), TestPriority(1)]
        [Trait("Category", "Tests Order")]
        public void Test03()
        {
            Test3Called = true;

            Assert.False(Test1Called);
            Assert.False(Test2Called);
            Assert.False(Test4Called);
        }

        [Fact(DisplayName = "Test 02"), TestPriority(4)]
        [Trait("Category", "Tests Order")]
        public void Test02()
        {
            Test2Called = true;

            Assert.True(Test3Called);
            Assert.True(Test4Called);
            Assert.True(Test1Called);
        }
    }
}
