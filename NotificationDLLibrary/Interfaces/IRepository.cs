using System;
using NotificationModelLibrary;

namespace NotificationDLLibrary.Interfaces
{
   
    internal interface IRepository<K,T> where T : class
    {
        public User Create(T item);
        public User? GetUser(K key);
        public List<User>? GetUsers();

        public User? Update(K key,T item);
        public User? Delete(K key);

    }
}
