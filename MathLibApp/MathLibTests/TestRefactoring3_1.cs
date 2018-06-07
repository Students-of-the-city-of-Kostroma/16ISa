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
    class TestRefactoring3_1//тесты для части сценариев для основных операторов
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
            for (int i = 0; i < n + 1; i++)//составляется выражение
            {
                arr[i] = r.Next(4, 6);//цифра
                s += arr[i].ToString();
                if (i != n)//знак
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
            char[] operat1 = { '4', '5', '6' };
            double[] mas = new double[n + 1];//массив для чисел
            string[] mas1 = new string[n];//массив для знаков
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
        //BaseCalc_12 На вход подается строка, содержащая выражение которое содержит 10 операторов
        //(сделать так, чтобы не вылетело за диапазон double)
        [TestMethod]
        public void BaseCalc_12()
        {
            //arrange
            string data = MakeString(10);
            double expected = ExpectedResult(data, 10);
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }
        //BaseCalc_13 На вход подается строка, содержащая выражение которое содержит 50 операторов
        //    (сделать так, чтобы не вылетело за диапазон double)
        [TestMethod]
        public void BaseCalc_13()
        {
            //arrange
            string data = MakeString(50);
            double expected = ExpectedResult(data, 50);
            //acts
            double actual = mc.Calculate(data);
            //assert
            Assert.AreEqual(expected, actual);
        }
        //BaseCalc_14 На вход подается строка, содержащая выражение которое
        //содержит 500 операторов(сделать так, чтобы не вылетело за диапазон double)
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void BaseCalc_14()
        {
            //arrange
            string data = MakeString(500);
            //acts
            double actual = mc.Calculate(data);

        }
    }
}

