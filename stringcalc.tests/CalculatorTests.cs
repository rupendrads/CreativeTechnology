using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;

namespace stringcalc.tests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly ICalculator calculator;
        IKernel kernel = new StandardKernel();

        public CalculatorTests()
        {
            kernel.Load(new DIRegistration());
            calculator = kernel.Get<ICalculator>();                    
        }

        [TestMethod]
        public void Add_Should_Return_Zero_for_EmptyString()
        {
            int sum = calculator.Add("");

            Assert.AreEqual(0, sum);
        }

        [TestMethod]
        public void Add_Should_Return_1_for_1()
        {
            int sum = calculator.Add("1");

            Assert.AreEqual(1, sum);
        }

        [TestMethod]
        public void Add_Should_Return_3_for_1_and_2()
        {
            int sum = calculator.Add("1,2");

            Assert.AreEqual(3, sum);
        }

        [TestMethod]
        public void Add_Should_Handle_Unknown_Amount_of_Numbers()
        {
            int sum = calculator.Add("1,2,3,4,5");

            Assert.AreEqual(15, sum);
        }

        [TestMethod]
        public void Add_Should_New_Lines_Between_Numbers()
        {
            int sum = calculator.Add(@"1\n2,3");

            Assert.AreEqual(6, sum);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Add_Should_Not_Allow_New_Lines_At_End()
        {
            int sum = calculator.Add(@"1,\n");
        }

        [TestMethod]
        public void Add_Should_Support_Different_Single_Character_Delimiter()
        {
            int sum = calculator.Add(@"//;\n1;2");

            Assert.AreEqual(3, sum);
        }

        [TestMethod]        
        public void Add_Should_Throw_Exception_For_Negative_Numbers()
        {
            const string expectedMessage = "Negatives not allowed : -2,-4";
            
            var exception = Assert.ThrowsException<Exception>(() => calculator.Add(@"//;\n1;-2;3;-4;5"));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void Add_Should_Ignore_Numbers_Greater_Than_1000()
        {
            int sum = calculator.Add(@"//;,\n2;1001;13");

            Assert.AreEqual(15, sum);
        }

        [TestMethod]
        public void Add_Should_Allow_Multiple_Delimiters()
        {
            int sum = calculator.Add(@"//*%\n1*2%3");

            Assert.AreEqual(6, sum);
        }
    }
}
