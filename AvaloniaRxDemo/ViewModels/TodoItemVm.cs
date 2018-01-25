using AvaloniaRxDemo.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class TodoItemVm: ReactiveObject
    {
        private readonly TodoItem todoItem;
        private string name;
        private string description;
        private uint duration;

        public TodoItemVm()
            : this(new TodoItem())
        {

        }

        public TodoItemVm(TodoItem todoItem)
        {
            this.todoItem = todoItem;
            name = todoItem.Name;
            description = todoItem.Description;
            duration = todoItem.Duration;
        }

        public int Id
        {
            get { return todoItem.Id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                todoItem.Name = value;
                this.RaiseAndSetIfChanged(ref name, value);
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                todoItem.Description = value;
                this.RaiseAndSetIfChanged(ref description, value);
            }
        }

        public uint Duration
        {
            get { return duration; }
            set
            {
                todoItem.Duration = value;
                this.RaiseAndSetIfChanged(ref duration, value);
            }
        }

        public TodoItem Model
        {
            get { return todoItem; }
        }
    }
}
