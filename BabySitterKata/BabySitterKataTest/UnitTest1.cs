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

        [TestMethod]
        public void whenDisplayMessageIsPassedAStringItReturnsThatString()
        {
            Assert.AreEqual("Hi", BabySitterCalculator.DisplayMessage("Hi"));
            Assert.AreEqual("Good Morning", BabySitterCalculator.DisplayMessage("Good Morning"));
            Assert.AreEqual("How are you", BabySitterCalculator.DisplayMessage("How are you"));
        }

        [TestMethod]
        public void whenDisplayMessageIsPassedAStringItDisplaysToConsole()
        {
            Assert.AreEqual("Good Night", BabySitterCalculator.DisplayMessage("Good Night"));
        }

        [TestMethod]
        public void whenNotificationManagerIsPassedWelcomeMessageItReturnsTrue()
        {
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("WelcomeMessage"));
        }

        [TestMethod]
        public void onlyWhenNotificationManagerIsPassedWelcomeMessageOrStartTimeItReturnsTrue()
        {
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("WelcomeMessage"));
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("StartTime"));
            Assert.AreEqual(false, BabySitterCalculator.NotificationManager("BeginTime"));
        }

        [TestMethod]
        public void whenNotificationManagerIsPassedSpecificValuesItReturnsTrue()
        {
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("EndTime"));
            Assert.AreEqual(false, BabySitterCalculator.NotificationManager("StartApplication"));
        }


    }
}
