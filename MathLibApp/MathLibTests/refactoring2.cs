using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL;
using System.Collections.Generic;

namespace MathLibTests
{
    [TestClass]
    class Refactoring2
    {
        public TestContext TestContext { get; set; }
        private static MathCore mc;

        [TestInitialize]
        public void ClassInitialize()
        {
            mc = new MathCore();
        }

        #region BaseCalc

        //На вход подается строка, не содержащая выражения
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_5()
        {
            //arrange 
            string data = "Где выражение?";
            //acts 
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая заведомо неправильно составленное выражение
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_6()
        {
            //arrange 
            string data = "1++2";
            //acts 
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая заведомо неправильно составленное выражение
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_7()
        {
            //arrange 
            string data = "1--2";
            //acts 
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая заведомо неправильно составленное выражение
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_8()
        {
            //arrange 
            string data = "1+,2";
            //acts 
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая заведомо неправильно составленное выражение
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_9()
        {
            //arrange 
            string data = "1=2";
            //acts 
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая выражение, результат которого будет больше,
        //чем максимальное положительное значение double
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_10()
        {
            //arrange 
            double maxVal = double.MaxValue;
            string data = maxVal.ToString() + "+1";
            //acts 
            double actual = mc.Calculate(data);
            //assert
        }

        //На вход подается строка, содержащая выражение, результат которого будет меньше,
        //чем максимальное отрицательное значение double
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void BaseCalc_11()
        {
            //arrange

            double minVal = double.MinValue;
            string data = minVal.ToString() + "-1"; ;
            //acts 
            double actual = mc.Calculate(data);
        }
        #endregion

        #region MultiplicationDivisionCalc

        //На вход подается строка, содержащая заведомо неправильно составленное выражение
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void MultiplicationDivisionCalc_5()
        {
            //arrange 
            string data = "1**2";
            //acts 
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая заведомо неправильно составленное выражение
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void MultiplicationDivisionCalc_6()
        {
            //arrange 
            string data = "1//2";
            //acts 
            double actual = mc.Calculate(data);
        }
        #endregion

        #region Brackets

        //На вход подается строка, содержащая  математическое выражение,
        //в котором содержится одна пара скобок
        [TestMethod]
        public void CalcBrackets_1()
        {
            //arrange
            string data = "2*(1+2)";
            double expected = 6;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //На вход подается строка, содержащая  математическое выражение,
        //в котором содержится несколько пар скобок
        [TestMethod]
        public void CalcBrackets_2()
        {
            //arrange
            string data = "(0.5+2.5)-2*(30-5)/5*(2-1)";
            double expected = -7;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //На вход подается строка, содержащая  математическое выражение,
        //в котором содержится множество пар скобок
        [TestMethod]
        public void CalcBrackets_3()
        {
            //arrange
            string data = "(20/10+2*(30-(20/4)/(500/(25+5*5)/0.5)))";
            double expected = 61.5;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //На вход подается строка, содержащая  математическое выражение, 
        //в котором содержится отрицательное число в скобках
        [TestMethod]
        public void CalcBrackets_4()
        {
            //arrange
            string data = "5+(-5)";
            double expected = 0;
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //На вход подается строка, содержащая  математическое выражение,
        //в котором содержатся незакрытые скобки
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void CalcBrackets_5()
        {
            //arrange
            string data = "(1+2";
            //acts
            double actual = mc.Calculate(data);
        }

        //На вход подается строка, содержащая  математическое выражение,
        //в котором содержатся пустые скобки
        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void CalcBrackets_6()
        {
            //arrange
            string data = "()+2";
            //acts
            double actual = mc.Calculate(data);
        }
        #endregion
    }
}
