using System;
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
    }
}
