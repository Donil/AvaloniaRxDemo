using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TodoItem CurrentTask { get; set; }
    }
}
