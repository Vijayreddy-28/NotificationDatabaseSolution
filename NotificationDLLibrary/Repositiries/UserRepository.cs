using System;
using NotificationModelLibrary;
using System.Linq;
using NotificationDLLibrary.Interfaces;

namespace NotificationDLLibrary.Repositories
{
    public class UserRepository: IRepository<string, User> {
          
        Dictionary<string,User> users=new Dictionary<string, User>();
        string Id="100";
        public User Create(User user)
        {
            int UserNum=Convert.ToInt32(Id);
            user.userId=(++UserNum).ToString();
            Id=UserNum.ToString();
            users.Add(user.userId,user);
            return user;
        }
        public User? GetUser(string Id)
        {
            if (!users.ContainsKey(Id))
            {
                return null;
            }
            return users[Id];
        }

        public List<User>? GetUsers()
        {
            if(users.Count==0) return null;
            var list=users.Values.ToList();
            return list;
        }

        public User? Delete(string Id)
        {
            var user = users.GetValueOrDefault(Id);
            if (user == null){
                Console.WriteLine("Userid is not found for Delete");
                return null;
            }
            users.Remove(Id);
            return user;
        }

        public User? Update(string Id,User user)
        {
            if(users[Id]==null) {
                Console.WriteLine("the userId is not found for update");
                return null;
            }
            user.userId = Id;
            users[Id]=user;
            return user;
        }
    }
}