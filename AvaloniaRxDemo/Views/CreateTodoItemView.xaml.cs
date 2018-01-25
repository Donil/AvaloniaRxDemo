using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaRxDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.Views
{
    public class CreateTodoItemView: UserControl
    {
        public CreateTodoItemView()
        {
            this.InitializeComponent();
            DataContext = ServiceLocator.Resolve<CreateTodoItemVm>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
