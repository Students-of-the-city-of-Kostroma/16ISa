using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL.Interfaces;

namespace MathLibTests
{
    [TestClass]
    public class IMathCoreTest
    {
        public TestContext TestContext { get; set; }
        IMathCore IMC;
        IExpression IE;

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
            IE.Expression = data;
            double actual = IMC.Calculate(IE);//якобы на выходе будет null            
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
