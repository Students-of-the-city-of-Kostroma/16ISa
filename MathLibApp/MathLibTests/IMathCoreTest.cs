using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibDLL;

namespace MathLibTests
{
    [TestClass]
    public class IMathCoreTest
    {
        [ClassInitialize]
        public void ClassInitialize()
        {

        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","textData.xml", "Calculate",
            DataAccessMethod.Sequentail)]
        [TestMethod]
        public void MathLib_Calculate_FromXML()
        {
            //arrange
            string data = Convert.ToString(TextContext.DataRow["data"]);
            //acts
            
            //assert

        }
    }
}
