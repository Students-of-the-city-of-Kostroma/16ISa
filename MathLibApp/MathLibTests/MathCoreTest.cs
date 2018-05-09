﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.mariuszgromada.math.mxparser;
using MathLibDLL;
using System.Collections.Generic;

namespace MathLibTests
{
    
    [TestClass]
    public class MathCoreTest
    {
        public TestContext TestContext { get; set; }
        //MathCore mc = new MathCore();
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml",
            "Calculate", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Calculate_From_XML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts
            //double actual=mc.Calculate();//якобы на выходе будет null            
            //assert
            //Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void MultiplicationDivisionCalc_1()
        {
            //arrange
            double expected = 1;
            string data = "1*2/2";
            //acts
            //double actual = mc.Calculate(data);
            //assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_2()
        {
            //arrange
            double expected = 0.5;
            string data = "1/20.*10";
            //acts
            //double actual = mc.Calculate(data);
            //assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_3()
        {
            //arrange
            double expected = 2.10327613;
            string data = "52.5*321/8012.5";
            //acts
            //double actual = mc.Calculate(data);
            //assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationDivisionCalc_4()
        {
            //arrange
            double expected = 856356.822;
            string data = "8911.52*219.48/23/34*786/2012.5*0.5*2999/502*10500.228/322*9";
            //acts
            //double actual = mc.Calculate(data);
            //assert
            //Assert.AreEqual(expected, actual);
        }
    }
}
