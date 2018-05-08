using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL.Interfaces;
using System.Collections.Generic;

namespace MathLibTests
{

    [TestClass]
    public class IMathCoreTest
    {
        public TestContext TestContext { get; set; }
        IMathCore IMC;
        IExpression IE;

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","testData.xml", "Calculate",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void MathLib_Calculate_FromXML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts
            IE.Expression = data;
            double actual = IMC.Calculate(IE);//якобы на выходе будет null            
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Calculate_MaxValue_Plus_1_Returned_Null()
        {
            //arrange
            double mv = double.MaxValue;
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts
            IE.Expression = mv+"+1";
            double actual = IMC.Calculate(IE);//якобы на выходе будет null
            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Calculate_MinValue_Minus_1_Returned_Null()
        {
            //arrange
            double mv = double.MinValue;
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts
            IE.Expression ="-" + mv + "-1";
            double actual = IMC.Calculate(IE);//якобы на выходе будет null
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
