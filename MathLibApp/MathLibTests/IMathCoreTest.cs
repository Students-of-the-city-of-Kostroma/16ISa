using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL.Interfaces;
using MathLibDLL.Models;
using System.Collections.Generic;

namespace MathLibTests
{
    [TestClass]
    public class IMathCoreTest
    {
        public TestContext TestContext { get; set; }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","textData.xml", "Calculate",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void MathLib_Calculate_FromXML()
        {
            //arrange
            string data = Convert.ToString(TestContext.DataRow["data"]);
            //acts

            //assert

        }

        public void Calculate_MaxValue_Plus_1_Returned_Null()
        {
            //arrange
            double mv = double.MaxValue;
            //acts

            //assert
        }

        public void Calculate_MinValue_Minus_1_Returned_Null()
        {
            //arrange
            double mv = double.MinValue;
            //acts

            //assert
        }
    }
}
