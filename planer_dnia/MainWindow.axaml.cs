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

        private void DodajZadanie(object sender, RoutedEventArgs e)
        {
            if (NazwaZadania.Text != "")
            {
                var noweZadanie = new Zadanie();
                noweZadanie.Nazwa = NazwaZadania.Text;
                if (KategoriaZadania.SelectedItem is ComboBoxItem kat)
                {
                    noweZadanie.Kategoria = kat.Content.ToString();
                }
                else
                {
                    noweZadanie.Kategoria = "Brak";
                }

                zadania.Add(noweZadanie);
                OdswiezListe();
            }
        }


        private void UsunZadanie(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            if (przycisk.Tag != null)
            {
                zadania.Remove((Zadanie)przycisk.Tag);
                OdswiezListe();
            }
        }

        private void OdswiezListe()
        {
            ListaZadan.Children.Clear();
            ListaZadan.RowDefinitions.Clear(); 

            for (int i = 0; i < zadania.Count; i++)
            {
                ListaZadan.RowDefinitions.Add(new RowDefinition()); 

                var zadanie = zadania[i];

                var nazwa = new TextBlock();
                nazwa.Text = zadanie.Nazwa;
                Grid.SetRow(nazwa, i);
                Grid.SetColumn(nazwa, 0);
                ListaZadan.Children.Add(nazwa);

                var kategoria = new TextBlock();
                kategoria.Text = zadanie.Kategoria;
                Grid.SetRow(kategoria, i);
                Grid.SetColumn(kategoria, 1);
                ListaZadan.Children.Add(kategoria);

                var checkBox = new CheckBox();
                checkBox.IsChecked = zadanie.CzyUkonczone;
                checkBox.Checked += (s, e) => { zadanie.CzyUkonczone = checkBox.IsChecked ?? false; };
                Grid.SetRow(checkBox, i);
                Grid.SetColumn(checkBox, 2);
                ListaZadan.Children.Add(checkBox);

                var btnUsun = new Button();
                btnUsun.Content = "Usuń";
                btnUsun.Tag = zadanie;
                btnUsun.Click += UsunZadanie;
                Grid.SetRow(btnUsun, i);
                Grid.SetColumn(btnUsun, 3);
                ListaZadan.Children.Add(btnUsun);
            }

            int ukonczone = 0;
            for (int i = 0; i < zadania.Count; i++)
            {
                if (zadania[i].CzyUkonczone)
                {
                    ukonczone++;
                }
            }

            Podsumowanie.Text = "Zadań: " + zadania.Count + ", Ukończonych: " + ukonczone;
        }




        public class Zadanie
        {
            public string Nazwa { get; set; }
            public string Kategoria { get; set; }
            public bool CzyUkonczone { get; set; }
        }
    }
}