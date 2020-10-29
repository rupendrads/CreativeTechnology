using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Moq;
using System;

namespace stringcalc.tests
{
    [TestClass]
    public class ReplacerTests
    {
        private readonly IReplacer replacer;
        IKernel kernel = new StandardKernel();

        public ReplacerTests()
        {
            kernel.Load(new DIRegistration());
            replacer = kernel.Get<IReplacer>();    
        }

        [TestMethod]
        public void Replace_Should_Replace_Old_Value_With_New_Value()
        {
            string numbers = "1,2\n3";
            replacer.Replace(ref numbers, "\n", ",");

            Assert.AreEqual("1,2,3", numbers);
        }
    }
}