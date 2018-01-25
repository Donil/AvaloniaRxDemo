using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaRxDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRxDemo.Views
{
    public class StatisticView: UserControl
    {
        public StatisticView()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Resolve<StaticVm>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
