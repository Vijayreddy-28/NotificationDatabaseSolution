using System;
using NotificationModelLibrary.Interface;

namespace NotificationModelLibrary
{
    public class User 
    {
        public string userId {get; set;}=string.Empty;
        public string Name { get; set;}=string.Empty;
        public string EmailId { get; set;}=string.Empty;
        public string Phone { get; set;}=string.Empty;

    public override string ToString()
        {
            return $"UserId : {userId}\n Name : {Name}\nEmailId : {EmailId}\n Phone Number: {Phone}";
        }
    }

}