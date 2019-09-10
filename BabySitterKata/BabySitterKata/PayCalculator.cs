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
            bool notificationStatus = false;

            switch (notificationType)
            {
                case "WelcomeMessage":
                    notificationStatus = true;
                    break;
                case "StartTime":
                    notificationStatus = true;
                    break;

                default:
                    notificationStatus = false;
                    break;
            }

            return notificationStatus;
        }

        public string DisplayMessage(string message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}
