using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace planer_dnia
{
    public partial class MainWindow : Window
    {
        private List<Zadanie> zadania = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DodajZadanie(object? sender, RoutedEventArgs e)
        {
            if (NazwaZadania.Text != "" && KategoriaZadania.SelectedItem is ComboBoxItem kat)
            {
                zadania.Add(new Zadanie { Nazwa = NazwaZadania.Text, Kategoria = kat.Content.ToString() });
                OdswiezListe();
            }
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