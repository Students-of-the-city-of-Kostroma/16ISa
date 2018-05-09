using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MathLibDLL;
using MathLibDLL.Interfaces;
using Moq;

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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","testData.xml", "Calculate",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void MathLib_Calculate_FromXML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts   
            
            //assert
            //Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Calculate_MaxValue_Plus_1_Returned_Null()
        {
            //arrange
            double mv = double.MaxValue;
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts

            //assert
            //Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Calculate_MinValue_Minus_1_Returned_Null()
        {
            //arrange
            double mv = double.MinValue;
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts

            //assert
            //Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void BaseCalc_1()
        {
            //arrange
            string data = "1+2";    
            double expected = 3;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void BaseCalc_2()
        {
            //arrange
            string data = "1+2.5";
            double expected = 3.5;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void BaseCalc_3()
        {
            //arrange
            string data = "52.5+321+8012.5";
            double expected = 8386;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void BaseCalc_4()
        {
            //arrange
            string data = "8911.52+219.48+23+34+786-2012.5+0.5+2999-502+10500.228+322-20959";
            double expected = 322.228;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }

    }
}
