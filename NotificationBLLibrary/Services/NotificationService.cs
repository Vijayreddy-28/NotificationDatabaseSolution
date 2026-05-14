using NotificationModelLibrary.Interface;
using NotificationModelLibrary;
using NotificationDLLibrary.Repositories;

namespace NotificationBLLibrary.Services
{
    public class NotificationService
{
    public User? GetUserByEmail(string email, Dictionary<string,User> repo)
    {
        return repo.FirstOrDefault(x => x.Value.EmailId == email).Value;
    }

    public User? GetUserByPhone(string phone, Dictionary<string,User> repo)
    {
        return repo.FirstOrDefault(x => x.Value.Phone == phone).Value;
    }

    public void SendNotification(INotification notification)
    {
        notification.Send();
    }
}
}