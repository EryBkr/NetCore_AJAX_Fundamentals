using Example.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Models
{
    public static class Users
    {
        private static readonly List<User> _user = new List<User>() 
        {
             new User{Id=1,Name="User 1"},
             new User{Id=2,Name="User 2"}
        };

        public static List<User> GetAll()
        {
            return _user;
        }

        public static User GetById(int id)
        {
            return _user.FirstOrDefault(i=>i.Id==id);
        }

        public static void AddUser(User user)
        {
            _user.Add(user);
        }
      
    }
}
