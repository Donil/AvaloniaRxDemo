using AvaloniaRxDemo.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class TodoItemsListVm: ReactiveObject
    {
        private readonly ITodoItemsService todoItemsService;
        private TodoItemVm selectedTodoItem;

        public TodoItemsListVm(ITodoItemsService todoItemsService)
        {
            this.todoItemsService = todoItemsService;

            // Firstly get all items, and after that watch to changes.
            todoItemsService.GetAll()
                    .Select(items => items.Select(todoItem => new TodoItemVm(todoItem)))
                    .Do(items => TodoItems.AddRange(items))
                    .SelectMany(_ => todoItemsService.TodoItemAdded)
                    .Subscribe(todoItem => TodoItems.Add(new TodoItemVm(todoItem)));

            this.WhenAnyValue(x => x.SelectedTodoItem)
                .Where(todoItem => todoItem != null)
                .Select(todoItem => todoItem.Model)
                .SelectMany(todoItem => todoItemsService.SetCurrentTodoItem(todoItem))
                .Subscribe();
        }

        public ReactiveList<TodoItemVm> TodoItems { get; } = new ReactiveList<TodoItemVm>();

        public TodoItemVm SelectedTodoItem
        {
            get { return selectedTodoItem; }
            set { this.RaiseAndSetIfChanged(ref selectedTodoItem, value); }
        }
    }
}
