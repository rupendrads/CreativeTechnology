using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace stringcalc.tests
{
    [TestClass]
    public class SumCalculatorTests
    {
        private readonly ISumCalculator sumCalculator;
        IKernel kernel = new StandardKernel();

        public SumCalculatorTests()
        {
            kernel.Load(new DIRegistration());
            sumCalculator = kernel.Get<ISumCalculator>();
        }

        [TestMethod]
        public void CalculateSum_Should_Return_Sum_of_Numbers_In_String()
        {
            string numbers = "1;2%3";
            char[] delimiterArray = new char[]{ ';', '%' };

            int sum = sumCalculator.CalculateSum(numbers, delimiterArray);

            Assert.AreEqual(6, sum);
        }
    }
}