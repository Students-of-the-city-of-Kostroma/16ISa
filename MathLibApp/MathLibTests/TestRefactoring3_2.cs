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
    class TestRefactoring3_2//операторы умножение и деление
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
        [TestMethod]
        public void MultiplicationDivisionCalc_7()
        {
            //arrange
            string data = MakeString(10);
            double expected = ExpectedResult(data, 10);
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MultiplicationDivisionCalc_8()
        {
            //arrange
            string data = MakeString(50);
            double expected = ExpectedResult(data, 50);
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
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
            string data = "2e+2 +25 * 2";
            double expected = 250;

            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }

        //[ExpectedException(typeof(NullReferenceException))]
        //[TestMethod]
        //public void MultiplicationDivisionCalc_11()
        //{
        //    //arrange
        //    string data = null;

        //    //acts
        //    double actual = mc.Calculate(data);

        //}
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

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MultiplicationDivisionCalc_13()
        {
            //arrange
            string data = "";

            //acts
            double actual = mc.Calculate(data);

        }
        public double ExpectedResult(string s, int n)
        {
            char[] operat = { '*', '/' };
            char[] operat1 = { '4', '5', '6' };
            double[] mas = new double[n + 1];
            string[] mas1 = new string[n];
            var data = s.Split(operat, StringSplitOptions.None);
            for (int i = 0; i < n + 1; i++)
            {
                mas[i] = double.Parse(data[i]);
            }
            var data1 = s.Split(operat1, StringSplitOptions.None);
            for (int i = 0; i < n; i++)
            {
                if (data1[i + 1] != "")
                {
                    mas1[i] = data1[i + 1];
                }
            }
            double res = mas[0];
            for (int i = 0; i < n; i++)
            {
                double a = mas[i + 1];

                if (mas1[i] == "*")
                {
                    res = res * a;
                }
                else if (mas1[i] == "/")
                {
                    res = res / a;
                }
            }
            return res;
        }
    }
}
