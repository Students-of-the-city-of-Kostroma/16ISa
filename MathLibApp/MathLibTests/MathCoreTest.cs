using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MathLibDLL;
using MathLibDLL.Interfaces;
using Moq;
using MathLibDLL.Models;

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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
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
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BaseCalc_1()
        {
            //arrange 
            string data = "1+2";
            double expected = 3;
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            //a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            //a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            //a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
           // a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
            //acts 
            double actual = mc.Calculate(mockExp.Object);
            //assert 
            Assert.AreEqual(actual, expected);
        }
        public string MakeString(int n)
        {
            string s = "";
            Random r = new Random();
            double[] arr = new double[n + 1];
            bool flag = true;
            for (int i = 0; i < n + 1; i++)
            {
                arr[i] = r.Next(2, 6);
                s += arr[i].ToString();
                if (i != n)
                {
                    if (flag)
                    {
                        s += "+";
                        flag = false;
                    }
                    else
                    {
                        s += "-";
                        flag = true;
                    }
                }
            }
            return s;
        }
        public double ExpectedResult(string s, int n)
        {
            char[] operat = { '+', '-' };
            char[] operat1 = { '2', '3', '4', '5', '6' };
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

                if (mas1[i] == "+")
                {
                    res = res + a;
                }
                else if (mas1[i] == "-")
                {
                    res = res - a;
                }
            }
            return res;
        }
        [TestMethod]
        public void BaseCalc_12()
        {
            //arrange
            string data = MakeString(10);
            List<Argument> datalist = new List<Argument>();
            double expected = ExpectedResult(data, 10);
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            mockExp.Setup(exp => exp.Arguments).Returns(datalist);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void BaseCalc_13()
        {
            //arrange
            string data = MakeString(50);
            double expected = ExpectedResult(data, 50);
            List<Argument> datalist = new List<Argument>();
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            mockExp.Setup(exp => exp.Arguments).Returns(datalist);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void BaseCalc_14()
        {
            //arrange
            string data = MakeString(500);
            double expected = ExpectedResult(data, 500);
            List<Argument> datalist = new List<Argument>();
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            mockExp.Setup(exp => exp.Arguments).Returns(datalist);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            //a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            //a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            //a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
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
            List<MathLibDLL.Models.Argument> a = new List<MathLibDLL.Models.Argument>();
            // a.Add(new MathLibDLL.Models.Argument("", expected));
            mockExp.Setup(exp => exp.Arguments).Returns(a);
            //acts 
            double actual = mc.Calculate(mockExp.Object);
            //assert 
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_7()
        {
            //arrange
            string data = MakeString(10);
            double expected = ExpectedResult(data, 10);
            List<MathLibDLL.Models.Argument> datalist = new List<MathLibDLL.Models.Argument>();
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            mockExp.Setup(exp => exp.Arguments).Returns(datalist);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void MultiplicationDivisionCalc_8()
        {
            //arrange
            string data = MakeString(50);
            double expected = ExpectedResult(data, 50);
            List<MathLibDLL.Models.Argument> datalist = new List<MathLibDLL.Models.Argument>();
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            mockExp.Setup(exp => exp.Arguments).Returns(datalist);
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
            List<MathLibDLL.Models.Argument> datalist = new List<MathLibDLL.Models.Argument>();
            var mockExp = new Mock<IExpression>();
            mockExp.Setup(exp => exp.Expression).Returns(data);
            mockExp.Setup(exp => exp.Arguments).Returns(datalist);
            //acts
            double actual = mc.Calculate(mockExp.Object);
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
