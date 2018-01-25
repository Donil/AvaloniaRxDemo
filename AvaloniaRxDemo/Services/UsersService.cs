using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using AvaloniaRxDemo.Models;

namespace AvaloniaRxDemo.Services
{
    public class UsersService : IUsersService
    {
        private readonly Subject<User> userAdded;
        private readonly List<User> usersList;

        public UsersService()
        {
            userAdded = new Subject<User>();
            usersList = new List<User>();

            // Add fake users.
            var user = new User
            {
                Name = "Steven",
            };
            Add(user);
        }

        public IObservable<User> UserAdded
        {
            get { return userAdded; }
        }

        public void Add(User user)
        {
            user.Id = usersList.Count == 0 
                ? 1 
                : usersList.Max(u => u.Id) + 1;
            usersList.Add(user);
            userAdded.OnNext(user);
        }

        public IEnumerable<User> GetAll()
        {
            return usersList;
        }

        public User GetById(int id)
        {
            return usersList.FirstOrDefault(u => u.Id == id);
        }
    }
}
