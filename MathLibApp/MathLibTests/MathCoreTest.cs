using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.mariuszgromada.math.mxparser;
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
        
        [TestMethod]
        public void CalcPowerOf_1()
        {
            //arrange
            string data = "2^5";
            double expected = 32;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcPowerOf_2()
        {
            //arrange
            string data = "2^-5";
            double expected = 0.03125;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcPowerOf_3()
        {
            //arrange
            string data = "2^(2*10/4)";
            double expected = 32;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcPowerOf_4()
        {
            //arrange
            string data = "2^2^3";
            double expected = 256;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcPowerOf_5()
        {
            //arrange
            string data = "5^0.25";
            double expected = 1.49534878;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
            // Возвращается значение с большим количеством знаков после запятйой при вызове метода
            // Исправить значение Input в сценарии тестирования с 5^0,25 на 5^0.25
        }

        [TestMethod]
        public void CalcPowerOf_6()
        {
            //arrange
            string data = "(2*10-5)^2";
            double expected = 225;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
