using System;
using System.Collections.Generic;
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

namespace CurrencyConverterStatic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> CurrenciesList = new List<string>() { "UAH", "EUR", "USD", "RUB"};

        private string _from ="";
        private string _to = "";
        private string _amount = "";

        public string? To { get { return _to; } set { _to = value; } }
        public string? From { get { return _from; } set { _from = value; } }
        public string? Amount { get { return _amount; } set { _amount = value; } }
        private string jsonString = "";
        CurrencyRequest currencyRequest;
        CurrencyResponse response;

        public MainWindow()
        {
            InitializeComponent();
            FromBox.ItemsSource = CurrenciesList;
            FromBox.SelectedItem = CurrenciesList[1];
            ToBox.ItemsSource = CurrenciesList;
            ToBox.SelectedItem = CurrenciesList[0];
        }

        private void ConvertCurrency(object sender, RoutedEventArgs e)
        {
            From = FromBox.SelectedValue.ToString();
            To = ToBox.SelectedValue.ToString();
            Amount = AmountField.Text;

            currencyRequest = new CurrencyRequest(_to, _from, _amount);
            currencyRequest.GetAsync();
        }

        private void ClearForm(object sender, RoutedEventArgs e)
        {
            FromBox.Text = "";
            ToBox.Text = "";
            AmountField.Text = "";
            Result.Text = "0";
        }

        private void SwipCurrencies(object sender, RoutedEventArgs e)
        {

        }

        private void FromBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GetResult()
        {
             currencyRequest.GetAsync();
        }
    }
}
