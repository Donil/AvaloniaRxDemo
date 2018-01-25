using AvaloniaRxDemo.Models;
using AvaloniaRxDemo.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class MainWindowVm : ReactiveObject
    {
        private readonly ITodoItemsService todoItemsService;
        private readonly IUsersService usersService;
        private ObservableCollection<TodoItemVm> todoItems;
        private TodoItemVm newTodoItemPlaceholder;
        private Subject<MainWindowVm> viewModelDisposed;

        public MainWindowVm(ITodoItemsService todoItemsService, IUsersService usersService)
        {
            this.usersService = usersService;
            this.todoItemsService = todoItemsService;

            todoItems = new ObservableCollection<TodoItemVm>();
            newTodoItemPlaceholder = new TodoItemVm();
            viewModelDisposed = new Subject<MainWindowVm>();

            //AddTodoItemCommand = ReactiveCommand.CreateAsyncObservable<object>((arg) =>
            //{

            //});

            //AddTodoItemCommand.Subscribe(e =>
            //{
            //    var todoItem = new TodoItem();
            //    todoItem.Name = "New item";
            //    todoItemsService.Add(todoItem);
            //});

            this.todoItemsService.TodoItemAdded
                .TakeUntil(viewModelDisposed)
                .Subscribe(todoItem =>
                    {
                        var viewModel = new TodoItemVm(todoItem);
                        todoItems.Add(viewModel);
                    });
        }

        public ObservableCollection<TodoItemVm> TodoItems
        {
            get { return todoItems; }
        }

        public TodoItemVm NewTodoItemPlaceholder
        {
            get { return newTodoItemPlaceholder; }
        }

        public ReactiveCommand<object> AddTodoItemCommand { get; }

        public void Dispose()
        {
            viewModelDisposed.OnNext(this);
        }
    }
}
