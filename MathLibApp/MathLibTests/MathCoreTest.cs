using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL;
using System.Collections.Generic;
using Moq;
using MathLibDLL.Interfaces;

namespace MathLibTests
{
    
    [TestClass]
    public class MathCoreTest
    {
        public TestContext TestContext { get; set; }
        private static MathCore mc;

        [TestInitialize]
        public void ClassInitialize()
        {
            mc = new MathCore();
        }

        //Здесь включены тесты CalcBrackets_1, CalcBrackets_2, CalcBrackets_3,
        //CalcBrackets_4, CalcBrackets_5, CalcBrackets_6
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml",
            "Brackets", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Calculate_From_XML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = Convert.ToDouble(TestContext.DataRow["expected"]);
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            mockExp.Setup(exp => exp.Arguments).Returns(a);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
