using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Deník
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Uzivatel uzivatel;
        private Denik denik;
        public MainWindow()
        {
            InitializeComponent();
            denik = new Denik();
            uzivatel = new Uzivatel(this, denik);
            TextBox.IsEnabled = false;
            DatumBox.IsEnabled = false;
            Ulozit.IsEnabled = false;
            Smazat.IsEnabled = false;
            uzivatel.ZobrazAktualniZaznam();
        }
        private void Predchozi_Click(object sender, RoutedEventArgs e)
        {
            uzivatel.Predchozi();
        }
        private void Dalsi_Click(object sender, RoutedEventArgs e)
        {
            uzivatel.Dalsi();
        }
        private void Novy_Click(object sender, RoutedEventArgs e)
        {
            uzivatel.Novy();
        }
        private void Ulozit_Click(object sender, RoutedEventArgs e)
        {
            uzivatel.Ulozit();
        }
        private void Smazat_Click(object sender, RoutedEventArgs e)
        {
            uzivatel.Smazat();
        }
        private void Ukoncit_Click(object sender, RoutedEventArgs e)
        {
            uzivatel.Ukoncit();
        }
    }
}
