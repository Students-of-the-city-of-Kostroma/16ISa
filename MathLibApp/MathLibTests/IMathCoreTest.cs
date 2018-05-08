using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
