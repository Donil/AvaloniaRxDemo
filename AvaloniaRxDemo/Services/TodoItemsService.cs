using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using AvaloniaRxDemo.Models;

namespace AvaloniaRxDemo.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly List<TodoItem> todoItems;
        private readonly Subject<TodoItem> todoItemAdded;
        private readonly Subject<TodoItem> currentTodoItem;

        public TodoItemsService()
        {
            todoItems = new List<TodoItem>();
            todoItemAdded = new Subject<TodoItem>();
            currentTodoItem = new Subject<TodoItem>();
        }

        public IObservable<TodoItem> TodoItemAdded
        {
            get { return todoItemAdded; }
        }

        public IObservable<TodoItem> CurrentTodoItem
        {
            get { return currentTodoItem; }
        }

        public IObservable<TodoItem> Add(TodoItem todoItem)
        {
            todoItem.Id = todoItems.Count == 0
                   ? 1
                   : todoItems.Max(t => t.Id) + 1;
            todoItem.CreatedAt = DateTime.Now;
            todoItems.Add(todoItem);

            return Observable.Return(todoItem)
                .Do(createdItem => {
                    todoItemAdded.OnNext(createdItem);
                });
        }

        public IObservable<IEnumerable<TodoItem>> GetAll()
        {
            return Observable.Return(todoItems);
        }

        public IObservable<TodoItem> GetById(int id)
        {
            var todoItem = todoItems.FirstOrDefault(t => t.Id == id);
            return Observable.Return(todoItem);
        }

        public IObservable<TodoItem> SetCurrentTodoItem(TodoItem todoItem)
        {
            return Observable.Return(todoItem)
                .Do(_ => currentTodoItem.OnNext(todoItem));
        }
    }
}
