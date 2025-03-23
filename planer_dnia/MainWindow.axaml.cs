using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace planer_dnia;
{
    public partial class MainWindow : Window
    {
        private List<Zadanie> zadania = new();
        public MainWindow()
        {
            InitializeComponent();
            AktualizujWidok();
        }

        private void Zadanie(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Usun(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}