using System;
using System.Collections.Generic;

using AvaloniaRxDemo.Models;

namespace AvaloniaRxDemo.Services
{
    public interface IUsersService
    {
        User GetById(int id);

        IEnumerable<User> GetAll();

        void Add(User user);

        IObservable<User> UserAdded { get; }
    }
}
