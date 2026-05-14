using System;
using System.ComponentModel.DataAnnotations;
using NotificationModelLibrary.Interface;

namespace NotificationModelLibrary
{
    
    public abstract class Notification : INotification
    {
        
        public string Body { get; set; }= string.Empty;
        public DateTime sentDate { get; set; }= DateTime.Now;

        public abstract void Send();
    }
}