using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Deník
{
    public class Uzivatel
    {
        private MainWindow mainWindow;
        private Denik denik = new Denik();
        public Uzivatel(MainWindow mainWindow, Denik denik)
        {
            this.mainWindow = mainWindow;
            this.denik = denik;
        }
        public void ZobrazAktualniZaznam()
        {
            Zaznam aktualniZaznam = denik.GetAktualniZaznam();

            if (aktualniZaznam != null)
            {
                mainWindow.DatumBox.Text = aktualniZaznam.Datum.ToString("dd.MM.yyyy");
                mainWindow.TextBox.Text = aktualniZaznam.Text;
            }
            else
            {
                mainWindow.DatumBox.Text = string.Empty;
                mainWindow.TextBox.Text = string.Empty;
            }
            mainWindow.Pocet.Content = denik.GetPocetZaznamu();
            if (denik.GetPocetZaznamu() == 0)
            {
                mainWindow.Smazat.IsEnabled = false;
            }
            else
            {
                mainWindow.Smazat.IsEnabled = true;
            }
            if (denik.GetPocetZaznamu() < 2)
            {
                mainWindow.Predchozi.IsEnabled = false;
                mainWindow.Dalsi.IsEnabled = false;
            }
            else
            {
                mainWindow.Predchozi.IsEnabled = true;
                mainWindow.Dalsi.IsEnabled = true;
            }
        }
        public void Novy()
        {
            mainWindow.DatumBox.Text = string.Empty;
            mainWindow.TextBox.Text = string.Empty;
            mainWindow.TextBox.IsEnabled = true;
            mainWindow.DatumBox.IsEnabled = true;
            mainWindow.Ulozit.IsEnabled = true;
        }
        public void Ulozit()
        {
            string textZaznamu = mainWindow.TextBox.Text;
            string datumZaznamuText = mainWindow.DatumBox.Text;
            DateTime datumZaznamu;

            if (!string.IsNullOrWhiteSpace(textZaznamu) && DateTime.TryParseExact(datumZaznamuText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datumZaznamu))
            {
                Zaznam novyZaznam = new Zaznam { Datum = datumZaznamu, Text = textZaznamu };
                denik.AddZaznam(novyZaznam);

                mainWindow.TextBox.IsEnabled = false;
                mainWindow.DatumBox.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Vyplňte prosím správně pole pro datum (dd.MM.yyyy) a text záznamu.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ZobrazAktualniZaznam();
            mainWindow.Ulozit.IsEnabled = false;
        }
        public void Smazat()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete smazat tento záznam?", "Potvrzení smazání", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                denik.RemoveZaznam();
            }
            ZobrazAktualniZaznam();
        }
        public void Predchozi()
        {
            denik.GetPrevZaznam();
            ZobrazAktualniZaznam();
        }
        public void Dalsi()
        {
            denik.GetNextZaznam();
            ZobrazAktualniZaznam();
        }
        public void Ukoncit()
        {
            mainWindow.Close();
        }
    }
}
