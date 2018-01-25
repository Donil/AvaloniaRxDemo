using AvaloniaRxDemo.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace AvaloniaRxDemo.ViewModels
{
    public class StaticVm: ReactiveObject
    {
        private readonly ITodoItemsService todoItemsService;
        private uint totalDuration;
        private double averageDuration;
        private uint minDuration = 0;
        private uint maxDuration = 0;
        private uint totalItems = 0;

        public StaticVm(ITodoItemsService todoItemsService)
        {
            this.todoItemsService = todoItemsService;

            var allItems = todoItemsService.GetAll()
                .SelectMany(items => items);

            Observable.Merge(allItems, todoItemsService.TodoItemAdded)
                .Scan(this, (acc, todoItem) => {
                    acc.TotalItems++;
                    acc.TotalDuration += todoItem.Duration;
                    acc.AverageDuration += acc.TotalDuration / totalItems;
                    acc.MinDuration = Math.Min(acc.MinDuration, todoItem.Duration);

                    acc.MaxDuration = Math.Min(acc.MaxDuration, todoItem.Duration);

                    return this;
                }).Subscribe();
        }

        public uint TotalItems
        {
            get { return totalItems; }
            set { this.RaiseAndSetIfChanged(ref totalItems, value); }
        }

        public uint TotalDuration
        {
            get { return totalDuration; }
            set { this.RaiseAndSetIfChanged(ref totalDuration, value); }
        }

        public double AverageDuration
        {
            get { return averageDuration; }
            set { this.RaiseAndSetIfChanged(ref averageDuration, value); }
        }
    
        public uint MinDuration
        {
            get { return minDuration; }
            set { this.RaiseAndSetIfChanged(ref minDuration, value); }
        }

        public uint MaxDuration
        {
            get { return maxDuration; }
            set { this.RaiseAndSetIfChanged(ref maxDuration, value); }
        }
    }
}
