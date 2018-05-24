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
    public class Tests
    {
        public TestContext TestContext { get; set; }
        private static MathCore mc;
        [TestInitialize]
        public void ClassInitialize()
        {
            mc = new MathCore();
        }
        public string MakeString(int n)
        {
            string s = "";
            Random r = new Random();
            double[] arr = new double[n + 1];
            bool flag = true;
            for (int i = 0; i < n + 1; i++)
            {
                arr[i] = r.Next(4, 6);
                s += arr[i].ToString();
                if (i != n)
                {
                    if (flag)
                    {
                        s += "*";
                        flag = false;
                    }
                    else
                    {
                        s += "/";
                        flag = true;
                    }
                }
            }
            return s;
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MultiplicationDivisionCalc_9()
        {
            //arrange
            string data = MakeString(500);
            //acts
            double actual = mc.Calculate(data);

        }
        [TestMethod]
        public void MultiplicationDivisionCalc_10()
        {
            //arrange
            string data = "2e+2 + 25 * 2";
            double expected = 250;

            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void MultiplicationDivisionCalc_11()
        {
            //arrange
            string data = null;

            //acts
            double actual = mc.Calculate(data);

        }
        [TestMethod]
        public void MultiplicationDivisionCalc_12()
        {
            //arrange
            string data = "1/0";
            double expected = double.NaN;

            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }


    }
}
