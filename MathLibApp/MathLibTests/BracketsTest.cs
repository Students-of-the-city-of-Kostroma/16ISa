using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL;
using System.Collections.Generic;
using Moq;
using MathLibDLL.Interfaces;

namespace MathLibTests
{

    [TestClass]
    public class BracketsTest
    {
        public TestContext TestContext { get; set; }
        private static MathCore mc;
        private static MxparserExpression exp;

        [TestInitialize]
        public void ClassInitialize()
        {
            mc = new MathCore();
        }

        //Здесь включены тесты CalcBrackets_1, CalcBrackets_2, CalcBrackets_3,
        //CalcBrackets_4
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml",
            "Brackets", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Calculate_From_XML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = Convert.ToDouble(TestContext.DataRow["expected"]);
            exp = new MxparserExpression(data);
            //acts
            double actual = mc.Calculate(exp);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //Здесь включены тесты CalcBrackets_5, CalcBrackets_6
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml",
            "BracketsErrors", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Calculate_From_XML_returns_NaN()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = double.NaN;
            exp = new MxparserExpression(data);
            //acts
            double actual = mc.Calculate(exp);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
