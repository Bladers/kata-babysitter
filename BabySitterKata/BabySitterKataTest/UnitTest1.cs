using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabySitterKataTest
{
    [TestClass]
    public class BabySitterKataTest
    {
        BabySitterKata.PayCalculator BabySitterCalculator;
        BabySitterKata.Sitter sitter;

        [TestInitialize]
        public void TestInitialize()
        {
            BabySitterCalculator = new BabySitterKata.PayCalculator();
            sitter = new BabySitterKata.Sitter();
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

        [TestMethod]
        public void whenProcessFamilySelectionIsPassedTheStringAReturnSitterWithFamilySetToA()
        {
            sitter = BabySitterCalculator.ProcessFamilySelection("a", new BabySitterKata.Sitter());
            Assert.AreEqual("A", sitter.Family);
        }
        [TestMethod]
        public void whenProcessFamilySelectionIsPassedStringABOrCReturnSitterWithFamilySetToABOrC()
        {
            sitter = BabySitterCalculator.ProcessFamilySelection("a", new BabySitterKata.Sitter());
            Assert.AreEqual("A", sitter.Family);
            sitter = BabySitterCalculator.ProcessFamilySelection("b", new BabySitterKata.Sitter());
            Assert.AreEqual("B", sitter.Family);
            sitter = BabySitterCalculator.ProcessFamilySelection("c", new BabySitterKata.Sitter());
            Assert.AreEqual("C", sitter.Family);
        }


    }
}
