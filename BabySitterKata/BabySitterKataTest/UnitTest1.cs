using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabySitterKataTest
{
    [TestClass]
    public class BabySitterKataTest
    {
        BabySitterKata.PayCalculator BabySitterCalculator;
        [TestInitialize]
        public void TestInitialize()
        {
            BabySitterCalculator = new BabySitterKata.PayCalculator();
        }

        [TestMethod]
        public void whenDisplayMessageIsPassedHelloWorldReturnHelloWorld()
        {
            string actualResult = string.Empty;
            actualResult = BabySitterCalculator.DisplayMessage("Hello World");
            Assert.AreEqual("Hello World", actualResult);
        }
    }
}
