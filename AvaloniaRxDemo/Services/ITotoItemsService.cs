using AvaloniaRxDemo.Models;
using System;
using System.Collections.Generic;
using System.Reactive;

namespace AvaloniaRxDemo.Services
{
    public interface ITodoItemsService
    {
        IObservable<TodoItem> GetById(int id);

        IObservable<IEnumerable<TodoItem>> GetAll();

        IObservable<TodoItem> Add(TodoItem todoItem);

        IObservable<TodoItem> TodoItemAdded { get; }

        IObservable<TodoItem> CurrentTodoItem { get; }

        IObservable<TodoItem> SetCurrentTodoItem(TodoItem todoItem);
    }
}
