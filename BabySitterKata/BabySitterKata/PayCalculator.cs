﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitterKata
{
    public class PayCalculator
    {
        public void Begin()
        {

        }

        public List<Family> Initialize()
        {
            List<Family> families = new List<Family>();
            string tomorrow = DateTime.Now.AddDays(1).ToShortDateString();

            families.Add(new Family
            {
                FamilyName = "Family A",
                FamilyAbbreviation = "A",
                WorkHours = new List<PayRate> {
                    new PayRate {
                        Rate = 15, StartTime = DateTime.Parse("5:00 PM"), EndTime = DateTime.Parse("11:00 PM")
                    },
                    new PayRate {
                        Rate = 20, StartTime = DateTime.Parse("11:00 PM"), EndTime = DateTime.Parse(tomorrow + " 4:00 AM")
                    }
                }
            });

            families.Add(new Family
            {
                FamilyName = "Family B",
                FamilyAbbreviation = "B",
                WorkHours = new List<PayRate> {
                    new PayRate {
                        Rate = 12, StartTime = DateTime.Parse("5:00 PM"), EndTime = DateTime.Parse("10:00 PM")
                    },
                    new PayRate {
                        Rate = 8, StartTime = DateTime.Parse("10:00 PM"), EndTime = DateTime.Parse(tomorrow + " 12:00 AM")
                    },
                    new PayRate {
                        Rate = 16, StartTime = DateTime.Parse(tomorrow + " 12:00 AM"), EndTime = DateTime.Parse(tomorrow + " 4:00 AM")
                    }
                }
            });

            families.Add(new Family
            {
                FamilyName = "Family C",
                FamilyAbbreviation = "C",
                WorkHours = new List<PayRate> {
                    new PayRate {
                        Rate = 21, StartTime = DateTime.Parse("5:00 PM"), EndTime = DateTime.Parse("9:00 PM")
                    },
                    new PayRate {
                        Rate = 15, StartTime = DateTime.Parse("9:00 PM"), EndTime = DateTime.Parse(tomorrow + " 4:00 AM")
                    }
                }
            });

            return families;
        }

        public bool NotificationManager(string notificationType, Sitter sitter)
        {
            bool notificationSuccess = false;

            switch (notificationType)
            {
                case "ContinueApplication":
                    DisplayMessage("Are you done calculating your babysitting pay? Please Enter 'YES' to exit...");
                    notificationSuccess = true;
                    break;
                case "WelcomeMessage":
                    DisplayMessage("Welcome to the Babysitter Pay Calculator!");
                    DisplayMessage("Please press ENTER to begin... or any other Key to exit!\n");
                    notificationSuccess = true;
                    break;
                case "FamilySelection":
                    DisplayMessage("Which Family do you want to babysit?");
                    DisplayMessage("Please enter A, B, or C:");
                    notificationSuccess = true;
                    break;
                case "StartTime":
                    DisplayMessage("\nWhat is your start time?");
                    DisplayMessage("Please enter a time no earlier than 5:00 PM:");
                    notificationSuccess = true;
                    break;
                case "EndTime":
                    DisplayMessage("\nWhat is your end time?");
                    DisplayMessage("Please enter a time no later than 4:00 AM:");
                    notificationSuccess = true;
                    break;
                case "ShowTotalPay":
                    DisplayMessage("\nYour total pay for working " + "X" + " payable hours is $" + "X" + " dollars.");
                    DisplayMessage("Unfortunately any fractional hours incured are non payable.");
                    notificationSuccess = true;
                    break;
                case "IncorrectTimeInput":
                    DisplayMessage("\n- Invalid Time Entry -");
                    DisplayMessage("Your time must be in XX:XX PM or XX:XX AM format.");
                    DisplayMessage("Please enter a time no earlier than 5:00 PM and no later than 4:00 AM:");
                    notificationSuccess = true;
                    break;
                case "IncorrectEndTimeInput":
                    DisplayMessage("\n- Invalid End Time Entry -");
                    DisplayMessage("Please enter a time later than your start time of " + "XX" + ":");
                    notificationSuccess = true;
                    break;
                case "IncorrectFamilyInput":
                    DisplayMessage("- Invalid Family Entry -");
                    DisplayMessage("Please select a family by entering exactly A, B, or C:");
                    notificationSuccess = true;
                    break;

                default:
                    notificationSuccess = false;
                    break;
            }

            return notificationSuccess;
        }

        public Sitter CalculatePay(Sitter sitter, List<Family> families)
        {
            sitter.TotalPay = 25;
            return sitter;
        }

        public Sitter ProcessTime(string inputString, string timePeriod, Sitter sitter)
        {
            string MorningOrEvening = string.Empty;
            DateTime convertedTime = new DateTime();
            DateTime startTimeLimit = DateTime.Parse("5:00 PM");
            DateTime endTimeLimit = DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString() + " 4:00 AM");

            if (DateTime.TryParse(inputString, out convertedTime))
            {

                MorningOrEvening = convertedTime.ToString(@"tt", new CultureInfo("en-US"));

                if (MorningOrEvening == "AM") convertedTime = convertedTime.AddDays(1);

                if (convertedTime < startTimeLimit || convertedTime > endTimeLimit)
                {
                    NotificationManager("IncorrectTimeInput", sitter);
                    sitter.ErrorFlag = true;
                }
                else
                {

                    if (timePeriod == "starttime")
                    {
                        if (convertedTime >= endTimeLimit)
                        {
                            NotificationManager("IncorrectTimeInput", sitter);
                            sitter.ErrorFlag = true;
                        }
                        else
                        {
                            sitter.StartTime = convertedTime;
                        }
                    }
                    else if (timePeriod == "endtime")
                    {

                        if (convertedTime <= sitter.StartTime)
                        {
                            NotificationManager("IncorrectEndTimeInput", sitter);
                            sitter.ErrorFlag = true;
                        }
                        else
                        {
                            sitter.EndTime = convertedTime;
                        }

                    }
                }

            }
            else
            {
                NotificationManager("IncorrectTimeInput", sitter);
                sitter.ErrorFlag = true;
            }

            return sitter;
        }

        public Sitter ProcessFamilySelection(string input, Sitter sitter)
        {
            if (!string.IsNullOrEmpty(input))
            {
                switch (input.ToLower())
                {
                    case "a":
                        DisplayMessage("\nYou selected Family A.");
                        sitter.Family = "A";
                        break;
                    case "b":
                        DisplayMessage("\nYou selected Family B.");
                        sitter.Family = "B";
                        break;
                    case "c":
                        DisplayMessage("\nYou selected Family C.");
                        sitter.Family = "C";
                        break;
                    default:
                        NotificationManager("IncorrectFamilyInput", sitter);
                        break;
                }
            }
            else
            {
                NotificationManager("IncorrectFamilyInput", sitter);
            }

            return sitter;
        }

        public string DisplayMessage(string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}
