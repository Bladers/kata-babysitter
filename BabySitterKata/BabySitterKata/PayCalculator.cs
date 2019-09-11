using System;
using System.Collections.Generic;
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

        public bool NotificationManager(string notificationType)
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

        public string DisplayMessage(string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}
