using System;

namespace NotificationModelLibrary
{
    public class Sms : Notification
    {
        public string ToPhone {get; set;}=string.Empty;
        
        public override void Send()
        {
            Console.WriteLine("----- Message SENT -----");
            Console.WriteLine($"To      : {ToPhone}");
            Console.WriteLine($"Body    : {Body}");
            Console.WriteLine($"sent    : {sentDate}");
            Console.WriteLine("----------------------");
        }
        public override string ToString()
        {
            return $"SMS To: {ToPhone}, Message: {Body}";
        }
    }
}