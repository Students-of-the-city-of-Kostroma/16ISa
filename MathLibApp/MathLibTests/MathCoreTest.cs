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


        //Включены следующие методы: BaseCalc_5, BaseCalc_6,BaseCalc_7, BaseCalc_8, BaseCalc_9
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","testData.xml", "Calculate",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void MathLib_Calculate_FromXML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = double.NaN;//Читал про библиотеку, которую используют прогеры
            //она возвращает double.NaN, если строка неверного формата
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            a.Add(new MathLibDLL.Models.Argument("", double.NaN));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
            //acts   
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void BaseCalc_10()
        {
            //arrange
            double mv = double.MaxValue;
            double expected = double.NaN;
            string data = mv + "+" + 1;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            a.Add(new MathLibDLL.Models.Argument("", double.NaN));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void BaseCalc_11()
        {
            //arrange
            double mv = double.MinValue;
            double expected = double.NaN;
            string data = "-" + mv + "-" + 1;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            a.Add(new MathLibDLL.Models.Argument("", double.NaN));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
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
