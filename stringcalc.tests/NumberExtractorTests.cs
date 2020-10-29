using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace stringcalc.tests
{
    [TestClass]
    public class NumberExtracterTests
    {
        private readonly INumbersExtractor numbersExtractor;
        IKernel kernel = new StandardKernel();

        public NumberExtracterTests()
        {
            kernel.Load(new DIRegistration());
            numbersExtractor = kernel.Get<INumbersExtractor>(); 
        }

        [TestMethod]
        public void ExtractNumbers_Should_Return_Numbers_Part_For_Multiple_Delimiter()
        {
            string numbers = @"//;\n1;2";
            char delimiter = ',';
            char[] delimiterArray = new char[]{};

            numbers = numbersExtractor.ExtractNumbers(numbers, delimiter, ref delimiterArray);

            Assert.AreEqual("1;2", numbers);
        }
    }
}