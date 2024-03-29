using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BabySitterKataTest
{
    [TestClass]
    public class BabySitterKataTest
    {
        BabySitterKata.PayCalculator BabySitterCalculator;
        BabySitterKata.Sitter sitter;
        List<BabySitterKata.Family> families;
        [TestInitialize]
        public void TestInitialize()
        {
            BabySitterCalculator = new BabySitterKata.PayCalculator();
            sitter = new BabySitterKata.Sitter();
            families = BabySitterCalculator.Initialize();
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
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("WelcomeMessage", sitter));
        }

        [TestMethod]
        public void onlyWhenNotificationManagerIsPassedWelcomeMessageOrStartTimeItReturnsTrue()
        {
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("WelcomeMessage", sitter));
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("StartTime", sitter));
            Assert.AreEqual(false, BabySitterCalculator.NotificationManager("BeginTime", sitter));
        }

        [TestMethod]
        public void whenNotificationManagerIsPassedSpecificValuesItReturnsTrue()
        {
            Assert.AreEqual(true, BabySitterCalculator.NotificationManager("EndTime", sitter));
            Assert.AreEqual(false, BabySitterCalculator.NotificationManager("StartApplication", sitter));
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

        [TestMethod]
        public void whenProcessTimeIsPassedString3PMReturnSitterWithStartTimeSetTo3PM()
        {
            sitter = BabySitterCalculator.ProcessTime("6pm", "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual("6:00 PM", sitter.StartTime.ToShortTimeString());
        }

        [TestMethod]
        public void whenProcessTimeIsPassedStringEarlierThan5PmReturnSitterWithErrorLogEqualTrue()
        {
            sitter = BabySitterCalculator.ProcessTime("4pm", "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual(true, sitter.ErrorFlag);
        }

        [TestMethod]
        public void whenProcessTimeIsPassedString12AmReturnSitterWithStartTimeSetToTomorrow12AM()
        {
            sitter = BabySitterCalculator.ProcessTime("12am", "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual(DateTime.Parse(System.DateTime.Now.AddDays(1).ToShortDateString() + " 12:00 AM"), sitter.StartTime);
        }

        [TestMethod]
        public void whenProcessTimeTimePeriodParameterIsPassedStartTimeStringOnlySetStartTime()
        {
            sitter = BabySitterCalculator.ProcessTime("8pm", "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual("8:00 PM", sitter.StartTime.ToShortTimeString());

            sitter = BabySitterCalculator.ProcessTime("10pm", "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual(new DateTime(), sitter.EndTime);
        }

        [TestMethod]
        public void whenProcessTimeIsPassed4AmOrLaterStringReturnSitterWithErrorLogEqualTrue()
        {
            sitter = BabySitterCalculator.ProcessTime("5am", "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual(true, sitter.ErrorFlag);
        }

        [TestMethod]
        public void whenProcessTimeTimePeriodParameterIsPassedEndTimeStringOnlySetEndTime()
        {
            sitter = BabySitterCalculator.ProcessTime("2am", "endtime", new BabySitterKata.Sitter());
            Assert.AreEqual(DateTime.Parse(System.DateTime.Now.AddDays(1).ToShortDateString() + " 2:00 AM"), sitter.EndTime);
            Assert.AreEqual(new DateTime(), sitter.StartTime);
        }

        [TestMethod]
        public void whenProcessTimeEndTimeIsPassedStringEarlierThanStartTimeReturnSitterWithErrorLogEqualTrue()
        {
            sitter = BabySitterCalculator.ProcessTime("10pm", "starttime", new BabySitterKata.Sitter());
            sitter = BabySitterCalculator.ProcessTime("7pm", "endtime", sitter);
            Assert.AreEqual(true, sitter.ErrorFlag);
        }

        [TestMethod]
        public void whenProcessTimeIsPassedNullReturnSitterWithErrorLogEqualTrue()
        {
            sitter = BabySitterCalculator.ProcessTime(null, "starttime", new BabySitterKata.Sitter());
            Assert.AreEqual(true, sitter.ErrorFlag);
        }

        [TestMethod]
        public void ThreeFamiliesNeedsBabySitting()
        {
            Assert.AreEqual(3, families.Count);
        }
        [TestMethod]
        public void ThereIsFamilyAFamilyBFamilyC()
        {
            Assert.AreEqual("A", families[0].FamilyAbbreviation);
            Assert.AreEqual("Family A", families[0].FamilyName);
            Assert.AreEqual("B", families[1].FamilyAbbreviation);
            Assert.AreEqual("Family B", families[1].FamilyName);
            Assert.AreEqual("C", families[2].FamilyAbbreviation);
            Assert.AreEqual("Family C", families[2].FamilyName);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledReturnSitterWithTotalPayEqualTo15()
        {
            sitter.Family = "C";
            sitter.StartTime = DateTime.Parse("10 pm");
            sitter.EndTime = DateTime.Parse("11 pm");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(15, sitter.TotalPay);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledWithSitterFamilyAReturnSitterWithTotalPayEqualTo15()
        {
            sitter.Family = "A";
            sitter.StartTime = DateTime.Parse("11 pm");
            sitter.EndTime = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString() + " 12 am");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(20, sitter.TotalPay);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledWithFamilyBFrom10PmTo2AmReturnSitterWithTotalPayEqualTo48()
        {
            sitter.Family = "B";
            sitter.StartTime = DateTime.Parse("10 pm");
            sitter.EndTime = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString() + " 2 am");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(48, sitter.TotalPay);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledWithFamilyAFrom7PmTo4AmReturnSitterWithTotalPayEqualTo48()
        {
            sitter.Family = "A";
            sitter.StartTime = DateTime.Parse("7 pm");
            sitter.EndTime = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString() + " 4 am");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(160, sitter.TotalPay);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledWithFamilyBFrom5PmTo12AmReturnSitterWithTotalPayEqualTo48()
        {
            sitter.Family = "B";
            sitter.StartTime = DateTime.Parse("5 pm");
            sitter.EndTime = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString() + " 12 am");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(76, sitter.TotalPay);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledWithFamilyCFrom10PmTo3AmReturnSitterWithTotalPayEqualTo48()
        {
            sitter.Family = "C";
            sitter.StartTime = DateTime.Parse("10 pm");
            sitter.EndTime = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString() + " 3 am");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(75, sitter.TotalPay);
        }

        [TestMethod]
        public void whenCalculatePayIsCalledWithFamilyBFrom6PmTo10PmReturnSitterWithTotalPayEqualTo48()
        {
            sitter.Family = "B";
            sitter.StartTime = DateTime.Parse("6 pm");
            sitter.EndTime = DateTime.Parse("10 pm");
            sitter = BabySitterCalculator.CalculatePay(sitter, families);
            Assert.AreEqual(48, sitter.TotalPay);
        }

    }
}
