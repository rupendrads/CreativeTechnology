using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using System;

namespace stringcalc.tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void IsValid_Should_Return_False_If_String_Ends_With_NewLine()
        {
            string numbers = "1,2\n3\n";
            var mock = new Mock<IValidator>();
            mock.Setup(p => p.IsValid(numbers)).Returns(false);
            bool isValid = mock.Object.IsValid(numbers);

            Assert.IsFalse(isValid);
        }
    }
}