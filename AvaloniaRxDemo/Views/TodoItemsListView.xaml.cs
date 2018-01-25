using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaRxDemo.ViewModels;
using System;
using System.Reflection;

namespace AvaloniaRxDemo.Views
{
    public class TodoItemsListView: UserControl
    {
        public TodoItemsListView()
        {
            var type = typeof(TodoItemsListView);
            var asm = type.GetTypeInfo().Assembly.GetName().Name;
            var typeName = type.FullName;
            var u1 = new Uri("resm:" + typeName + ".xaml?assembly=" + asm);
            var u2 = new Uri("resm:" + typeName + ".paml?assembly=" + asm);

            this.InitializeComponent();
            DataContext = ServiceLocator.Resolve<TodoItemsListVm>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
