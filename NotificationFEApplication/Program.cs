using NotificationModelLibrary;
using NotificationBLLibrary.Services;
using NotificationDLLibrary.Repositories;
using NotificationDLLibrary.Database;
using Npgsql;

class Program
{
    static void Main()
    {
        NotificationService service = new NotificationService();
        User user=new User();
        Validator Validator = new Validator();
        NRepository nrepo=new NRepository();
        PgDatabaseConnection database=new PgDatabaseConnection();


        while (true)
        {
            Console.WriteLine("\n1. Add User");
            Console.WriteLine("2. GetUser");
            Console.WriteLine("3. GetUsers");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Update");
            Console.WriteLine("6. Send Email or SMS");
            Console.WriteLine("7. View Notifications");
            Console.WriteLine("8. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1:
                    Console.Write("Please Enter User Name: ");
                    user.Name = Console.ReadLine() ?? "";

                    Console.Write("Please Enter Email: ");
                    user.EmailId = Console.ReadLine() ?? "";
                    Validator.EmailValidator(user.EmailId);

                    Console.Write("Please Enter Phone: ");
                    user.Phone = Console.ReadLine() ?? "";
                    Validator.PhoneValidator(user.Phone);
                    database.insertUserIntoDatabase(user);
                    break;
                case 2:
                    Console.WriteLine("Please Enter th UserId");
                    string id = Console.ReadLine() ?? "";
                    Console.WriteLine(database.GetUserById(id));
                    break;

                case 3:
                    Dictionary<string,User> users=database.GetAllUsers();
                    foreach (User u in users.Values)
                    {
                        Console.WriteLine(u);
                        Console.WriteLine("-----------------------------");
                    }
                    break;

                case 4:
                    Console.WriteLine("Please Enter the userId You want to delete");
                    string userid = Console.ReadLine() ?? "";
                    database.DeleteUserById(userid);
                    break;

                case 5:
                    Console.Write("Please Enter User Id that you want to Update: ");
                    string userId = Console.ReadLine() ?? "";

                    Console.WriteLine("Please Enter the field");
                    string field = Console.ReadLine() ?? "";
                    
                    Console.Write("Please Enter field Content: ");
                    string content = Console.ReadLine() ?? "";
                    
                    if(field == "Email" || field == "email")  Validator.EmailValidator(content);
                    if(field == "Phone" || field == "phone")   Validator.PhoneValidator(content);
                    database.UpdateUserDetails(userId,content, field);
                    break;

                case 6:
                    Console.WriteLine("Please Choose 1 to send Email or 2 to send SMS");
                    int type = int.Parse(Console.ReadLine() ?? "0");
                    if (type == 1)
                    {
                        Console.Write("Please Enter ToEmailId: ");
                        var emailUser = service.GetUserByEmail(Console.ReadLine() ?? "", database.GetAllUsers());

                        if (emailUser == null)
                        {
                            Console.WriteLine("User not found");
                            break;
                        }

                        Emails email = new Emails();
                        email.ToMailId = emailUser.EmailId;

                        Console.Write("Subject: ");
                        email.subject = Console.ReadLine() ?? "";
                        Validator.MessageValidator(email.subject);

                        Console.Write("Message: ");
                        email.Body = Console.ReadLine() ?? "";
                        Validator.MessageValidator(email.Body);
                        nrepo.Add(email);
                        service.SendNotification(email);
                    }
                    else if (type == 2)
                    {
                        Console.Write("Enter Phone: ");
                        var smsUser = service.GetUserByPhone(Console.ReadLine() ?? "", database.GetAllUsers());

                        if (smsUser == null)
                        {
                            Console.WriteLine("User not found");
                            break;
                        }

                        Sms sms = new Sms();
                        sms.ToPhone = smsUser.Phone;

                        Console.Write("Message: ");
                        sms.Body = Console.ReadLine() ?? "";
                        Validator.MessageValidator(sms.Body);
                        nrepo.Add(sms);
                        service.SendNotification(sms);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }

                    break;
                case 7:
                    var notifications = nrepo.GetNotifications();
                    Console.WriteLine("All Notifications");
                    foreach (var notification in notifications)
                    {
                        Console.WriteLine(notification);
                    }

                    break;
                case 8:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        
    }
}