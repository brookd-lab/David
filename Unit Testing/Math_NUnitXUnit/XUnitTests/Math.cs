using Math;

namespace XUnitTests
{
    public class XUnitMath
    {
        MathOperations math = new MathOperations();

        [Fact]
        public void AddTest()
        {
            Assert.Equal(20, math.Add(10, 10));
        }
        [Fact]
        public void SubtractTest()
        {
            Assert.Equal(0, math.Subtract(10, 10));
        }
        [Fact]
        public void MultiplyTest()
        {
            Assert.Equal(100, math.Multiply(10, 10));
        }
        [Fact]
        public void DivideTest()
        {
            Assert.Equal(1, math.Divide(10, 10));
        }
    }
}