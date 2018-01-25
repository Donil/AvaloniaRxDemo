using AvaloniaRxDemo.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class UserVm: ReactiveObject
    {
        private readonly User user;

        public UserVm(User user)
        {
            this.user = user;
        }

        public int Id
        {
            get { return user.Id; }
        }

        public string Name
        {
            get { return user.Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                user.Name = value;
            }
        }
    }
}
