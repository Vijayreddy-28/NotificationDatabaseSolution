using System;
using System.Collections.Generic;
using System.Linq;
using NotificationModelLibrary;
using NotificationDLLibrary.Repositories;
using System.Text.RegularExpressions;
using NotificationBLLibrary.Exceptions;

namespace NotificationBLLibrary.Services
{

    public class Validator
    {
        public void PhoneValidator(string Phone)
        {
            string Phonepattern = @"^[6-9]\d{9}$";
            
            if (!Regex.IsMatch(Phone, Phonepattern))
            {
                throw new InvalidPhoneNumberException();
            }
            

        }

        public void EmailValidator(string Email)
        {
            string Emailpattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(Email, Emailpattern))
            {
                throw new InvalidMailIdException();
            }
        }

        public void MessageValidator(string Message)
        {
            if (Message == null || Message.Length < 5 || Message.Length > 100)
            {
                throw new MessageException(Message);
            }
            
        }
        
    }
}