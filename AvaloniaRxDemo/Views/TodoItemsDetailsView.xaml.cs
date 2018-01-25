using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaRxDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.Views
{
    public class TodoItemsDetailsView: UserControl
    {
        public TodoItemsDetailsView()
        {
            this.InitializeComponent();
            this.DataContext = ServiceLocator.Resolve<TodoItemsDetailsVm>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
