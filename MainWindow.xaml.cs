using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UrhajoFeladat
{
    
    public class Urhajo
    {
        public string Nev { get; set; } = string.Empty;
        public int Legenyseg { get; set; }
        public int MaxHatotav { get; set; }
        public int Uzemanyagszint { get; set; }
        public string Gyarto { get; set; } = string.Empty;
        public string KuldetesStatusz { get; set; } = string.Empty;
        public int InditasEve { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Urhajo> urhajokLista = new List<Urhajo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            urhajokLista.Clear();

            urhajokLista.Add(new Urhajo { Nev = "Falcon-9", Legenyseg = 7, MaxHatotav = 550000, Uzemanyagszint = 87, Gyarto = "SpaceX", KuldetesStatusz = "Sikeres", InditasEve = 2020 });
            urhajokLista.Add(new Urhajo { Nev = "Orion-X1", Legenyseg = 4, MaxHatotav = 820000, Uzemanyagszint = 73, Gyarto = "NASA", KuldetesStatusz = "Folyamatban", InditasEve = 2023 });
            urhajokLista.Add(new Urhajo { Nev = "StarRider", Legenyseg = 12, MaxHatotav = 910000, Uzemanyagszint = 66, Gyarto = "Boeing", KuldetesStatusz = "Sikeres", InditasEve = 2019 });
            urhajokLista.Add(new Urhajo { Nev = "SolarWind", Legenyseg = 3, MaxHatotav = 300000, Uzemanyagszint = 92, Gyarto = "ESA", KuldetesStatusz = "Sikertelen", InditasEve = 2018 });
            urhajokLista.Add(new Urhajo { Nev = "Galaxy-Cruiser", Legenyseg = 18, MaxHatotav = 1200000, Uzemanyagszint = 54, Gyarto = "Blue Origin", KuldetesStatusz = "Sikeres", InditasEve = 2022 });
            urhajokLista.Add(new Urhajo { Nev = "Nova-Prime", Legenyseg = 10, MaxHatotav = 760000, Uzemanyagszint = 80, Gyarto = "Roscosmos", KuldetesStatusz = "Sikeres", InditasEve = 2017 });
            urhajokLista.Add(new Urhajo { Nev = "Pioneer-VII", Legenyseg = 6, MaxHatotav = 640000, Uzemanyagszint = 70, Gyarto = "NASA", KuldetesStatusz = "Folyamatban", InditasEve = 2024 });
            urhajokLista.Add(new Urhajo { Nev = "Titan-Hawk", Legenyseg = 14, MaxHatotav = 1050000, Uzemanyagszint = 48, Gyarto = "SpaceX", KuldetesStatusz = "Sikeres", InditasEve = 2021 });
            urhajokLista.Add(new Urhajo { Nev = "CosmoJet", Legenyseg = 5, MaxHatotav = 430000, Uzemanyagszint = 93, Gyarto = "JAXA", KuldetesStatusz = "Sikertelen", InditasEve = 2016 });
            urhajokLista.Add(new Urhajo { Nev = "Nebula-FX", Legenyseg = 11, MaxHatotav = 870000, Uzemanyagszint = 60, Gyarto = "ESA", KuldetesStatusz = "Sikeres", InditasEve = 2020 });

            dgUrhajok.ItemsSource = urhajokLista;
            dgUrhajok.Items.Refresh();
        }

        private void BtnHanyUrhajo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {urhajokLista.Count} űrhajó van.", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnLegnagyobbHatotav_Click(object sender, RoutedEventArgs e)
        {
            if (urhajokLista.Count == 0) return;
            var max = urhajokLista.OrderByDescending(u => u.MaxHatotav).First();
            MessageBox.Show($"A legnagyobb hatótávú űrhajó: {max.Nev} ({max.MaxHatotav} km)", "Legnagyobb hatótáv", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnSikeresKuvetes_Click(object sender, RoutedEventArgs e)
        {
            var sikeresek = urhajokLista.Where(u => u.KuldetesStatusz.ToLower() == "sikeres").ToList();
            dgUrhajok.ItemsSource = sikeresek;
        }

        private void BtnAtlagLegenyseg_Click(object sender, RoutedEventArgs e)
        {
            if (urhajokLista.Count == 0) return;
            double atlag = urhajokLista.Average(u => u.Legenyseg);
            MessageBox.Show($"Átlagos legénységszám: {atlag:F2} fő", "Átlag legénység", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnGyartokCsoportosit_Click(object sender, RoutedEventArgs e)
        {
            var rendezett = urhajokLista.OrderBy(u => u.Gyarto).ThenBy(u => u.Nev).ToList();
            dgUrhajok.ItemsSource = rendezett;
            MessageBox.Show("A táblázat rendezve lett gyártó szerint.", "Csoportosítás", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnKeresesNev_Click(object sender, RoutedEventArgs e)
        {
           
            var talalat = urhajokLista.Where(u => u.Nev.Contains("Falcon")).ToList();
            dgUrhajok.ItemsSource = talalat;
        }
    }
}