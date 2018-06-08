using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL;

namespace MathLibTests
{

    [TestClass]
    public class BracketsTest
    {
        private static MathCore mc;
        //private static MxparserExpression exp;

        [TestInitialize]
        public void ClassInitialize()
        {
            mc = new MathCore();
        }
        
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

        [ExpectedException(typeof(ArgumentException),"Всё гуд")]
        [TestMethod]
        public void CalcBrackets_5()
        {
            //arrange
            string data = "(1+2";
            //acts
            double actual = mc.Calculate(data);
        }

        [ExpectedException(typeof(ArgumentException), "Всё гуд")]
        [TestMethod]
        public void CalcBrackets_6()
        {
            //arrange
            string data = "()+2";
            //acts
            double actual = mc.Calculate(data);
        }
    }
}
