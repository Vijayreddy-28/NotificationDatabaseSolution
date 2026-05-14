using System.Linq;
using NotificationModelLibrary;
using System.Collections;
namespace NotificationDLLibrary.Repositories
{

    public class NRepository
    {
            List<Notification> notifications=new List<Notification>();

            public void Add(Notification notification)
            {
                notifications.Add(notification);
                Console.WriteLine("Notification saved");
            }

            public List<Notification> GetNotifications()
            {
                return notifications;
            }
    }
}