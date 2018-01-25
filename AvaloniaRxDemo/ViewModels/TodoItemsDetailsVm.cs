using AvaloniaRxDemo.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class TodoItemsDetailsVm: ReactiveObject
    {
        private readonly ITodoItemsService todoItemsService;

        public TodoItemsDetailsVm(ITodoItemsService todoItemsService)
        {
            this.todoItemsService = todoItemsService;

            CurrentTodoItem = todoItemsService.CurrentTodoItem.Select(todoItem =>
            {
                return new TodoItemVm(todoItem);
            });
        }
    

        public IObservable<TodoItemVm> CurrentTodoItem { get; }
    }
}
