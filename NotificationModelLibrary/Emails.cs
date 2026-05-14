using System;
using System.Security.Cryptography.X509Certificates;


namespace NotificationModelLibrary
{
    public class Emails : Notification
    {
        public string subject { get; set;} = string.Empty;
        public string ToMailId { get; set;} = string.Empty;
        public override void Send()
        {
            Console.WriteLine("----- EMAIL SENT -----");
            Console.WriteLine($"To      : {ToMailId}");
            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine($"Body    : {Body}");
            Console.WriteLine($"sent    : {sentDate}");
            Console.WriteLine("----------------------");
        }
    }
}