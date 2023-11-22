using Math;
namespace NUnitTests
{
    [TestFixture]
    public class TestMath
    {
        MathOperations math = new MathOperations();

        [TestCase]
        public void AddTest()
        {
            Assert.AreEqual(20, math.Add(10, 10));
        }
        [TestCase]
        public void SubtractTest()
        {
            Assert.AreEqual(0, math.Subtract(10, 10));
        }
        [TestCase]
        public void MultiplyTest()
        {
            Assert.AreEqual(100, math.Multiply(10, 10));
        }
        [TestCase]
        public void DivideTest()
        {
            Assert.AreEqual(1, math.Divide(10, 10));
        }
        public void AddTestConstraintModel()
        {
            Assert.That(math.Add(10, 10), Is.EqualTo(20));
        }
        [TestCase]
        public void SubtractTestConstraintModel()
        {
            Assert.That(math.Subtract(10, 10), Is.EqualTo(0));
        }
        [TestCase]
        public void MultiplyTestConstraintModel()
        {
            Assert.That(math.Multiply(10, 10), Is.EqualTo(100));
        }
        [TestCase]
        public void DivideTestConstraintModel()
        {
            Assert.That(math.Divide(10, 10), Is.EqualTo(1));
        }

        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
    }
}