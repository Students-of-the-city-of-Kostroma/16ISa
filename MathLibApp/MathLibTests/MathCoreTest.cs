﻿using System;
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

        //Здесь включены тесты: MultiplicationDivisionCalc_5, MultiplicationDivisionCalc_6
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml",
            "Calculate", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Calculate_From_XML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = double.NaN;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void MultiplicationDivisionCalc_1()
        {
            //arrange
            double expected = 1;
            string data = "1*2/2";
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_2()
        {
            //arrange
            double expected = 0.5;
            string data = "1/20.*10";
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_3()
        {
            //arrange
            double expected = 2.10327613;
            string data = "52.5*321/8012.5";
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_4()
        {
            //arrange
            double expected = 856356.822;
            string data = "8911.52*219.48/23/34*786/2012.5*0.5*2999/502*10500.228/322*9";
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object)    ;
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void MultiplicationDivisionCalc_7()
        {
            //arrange
            string data = MakeString(10);
            double expected = ExpectedResult(data, 10);
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        public string MakeString(int n)
        {
            string s = "";
            Random r = new Random();
            double[] arr = new double[n+1];
            bool flag = true;
            for (int i = 0; i < n+1; i++)
            {
                arr[i] = r.Next(2, 6);
                s += arr[i].ToString();
                if (i !=n)
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
            }return s;
        }
        public double ExpectedResult(string s,int n)
        {
            char[] operat = { '/', '*' };
            char[] operat1 = { '2', '3', '4', '5', '6' };
            double[] mas = new double[n+1];
            string[] mas1 = new string[n];
            var data = s.Split(operat, StringSplitOptions.None);
            for (int i = 0; i < n+1; i++)
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
        [TestMethod]
        public void MultiplicationDivisionCalc_8()
        {
            //arrange
            string data = MakeString(50);
            double expected = ExpectedResult(data,50);
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void MultiplicationDivisionCalc_9()
        {
            //arrange
            string data = MakeString(500);
            double expected = ExpectedResult(data, 500);
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
