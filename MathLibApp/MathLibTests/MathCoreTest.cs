using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MathLibTests
{

    [TestClass]
    public class MathCoreTest
    {
        public TestContext TestContext { get; set; }

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
            
            //assert
            //Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Calculate_MaxValue_Plus_1_Returned_Null()
        {
            //arrange
            double mv = double.MaxValue;
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts

            //assert
            //Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Calculate_MinValue_Minus_1_Returned_Null()
        {
            //arrange
            double mv = double.MinValue;
            double expected = double.NaN;//предлагается использовать null, 
            //но его нельзя поместить в тип double
            //acts

            //assert
            //Assert.AreEqual(actual, expected);
        }
    }
}
