using AvaloniaRxDemo.Models;
using AvaloniaRxDemo.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class CreateTodoItemVm: ReactiveObject
    {
        private readonly ITodoItemsService todoItemsService;
        private string name;
        private string description;
        private uint duration = 1;

        public CreateTodoItemVm(ITodoItemsService todoItemsService)
        {
            this.todoItemsService = todoItemsService;

            CreateCommand = ReactiveCommand.CreateAsyncObservable(item =>
            {
                var todoItem = new TodoItem();
                todoItem.Name = Name;
                todoItem.Description = Description;
                todoItem.Duration = Duration;

                return todoItemsService.Add(todoItem);
            });

            CreateCommand.Subscribe(_ => 
            {
                Name = Description = null;
                Duration = 1;
            });
        }

        public ReactiveCommand<TodoItem> CreateCommand { get; set; }

        public string Name
        {
            get { return name; }
            set { this.RaiseAndSetIfChanged(ref name, value); }
        }

        public string Description
        {
            get { return description; }
            set { this.RaiseAndSetIfChanged(ref description, value); }
        }

        public uint Duration
        {
            get { return duration; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Value can not be zero");
                }
                this.RaiseAndSetIfChanged(ref duration, value);
            }
        }
    }
}
