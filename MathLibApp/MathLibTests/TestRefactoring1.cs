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
    class TestRefactoring1
    {
        private static MathCore mc;
        [TestInitialize]
        public void ClassInitialize()
        {
            mc = new MathCore();
        }
        #region BaseCalc (Получение численного ответа из входной строки, которая содержит только выражение с основными операторами)
        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение состоящее только из целых чисел
        /// </summary>
        [TestMethod]
        public void BaseCalc_1()
        {
            //arrange 
            string data = "1+2";
            double expected = 3;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение
        /// </summary>
        [TestMethod]
        public void BaseCalc_2()
        {
            //arrange 
            string data = "1+2.5";
            double expected = 3.5;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// На вход подается строка, содержащая обычное математическое выражение
        /// </summary>
        [TestMethod]
        public void BaseCalc_3()
        {
            //arrange 
            string data = "52.5+321+8012.5";
            double expected = 8386;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// На вход подается строка, содержащая большое математическое выражение
        /// </summary>
        [TestMethod]
        public void BaseCalc_4()
        {
            //arrange 
            string data = "8911.52+219.48+23+34+786-2012.5+0.5+2999-502+10500.228+322-20959";
            double expected = 322.228;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region MultiplicationDivisionCalc (Получение численного ответа из входной строки, которая содержит выражение с операторами умножения и деления)
        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение состоящее только из целых чисел
        /// </summary>
        [TestMethod]
        public void MultiplicationDivisionCalc_1()
        {
            //arrange 
            double expected = 1;
            string data = "1*2/2";
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение
        /// </summary>
        [TestMethod]
        public void MultiplicationDivisionCalc_2()
        {
            //arrange 
            double expected = 0.5;
            string data = "1/20.*10";
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// На вход подается строка, содержащая обычное математическое выражение
        /// </summary>
        [TestMethod]
        public void MultiplicationDivisionCalc_3()
        {
            //arrange 
            double expected = 2.10327613;
            string data = "52.5*321/8012.5";
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// На вход подается строка, содержащая большое математическое выражение
        /// </summary>
        [TestMethod]
        public void MultiplicationDivisionCalc_4()
        {
            //arrange 
            double expected = 856356.822;
            string data = "8911.52*219.48/23/34*786/2012.5*0.5*2999/502*10500.228/322*9";
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region  CalcPowerOf(Получение численного ответа из входной строки, которая содержит выражение, в котором присутствуют числа в степени)
        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение,
        /// в котором содержится число в положительной степени
        /// </summary>
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

        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение,
        /// в котором содержится число в отрицательной степени
        /// </summary>
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

        /// <summary>
        /// На вход подается строка, содержащая  математическое выражение,
        /// в котором содержится число в степени-выражении
        /// </summary>
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

        /// <summary>
        /// На вход подается строка, содержащая  математическое выражение,
        /// в котором содержится число в степени числа, которое тоже в свою очередь тоже в степени
        /// </summary>
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

        /// <summary>
        /// На вход подается строка, содержащая маленькое математическое выражение,
        /// в котором содержится число в степени, представленной нецелым значением
        /// </summary>
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

        /// <summary>
        /// На вход подается строка, содержащая  математическое выражение,
        /// в котором содержится математическое выражение в степени
        /// </summary>
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
        #endregion
    }
}
