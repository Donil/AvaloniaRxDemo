using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public uint Duration { get; set; }

        public User CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public User AssignedTo { get; set; }
    }
}
