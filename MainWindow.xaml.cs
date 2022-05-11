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
        private string _amount = "1";

        public string? To { get { return _to; } set { _to = value; } }
        public string? From { get { return _from; } set { _from = value; } }
        public string? Amount { get { return _amount; } set { _amount = value; } }
        private string jsonString = "";
        CurrencyRequest currencyRequest;
        Currency response;

        public MainWindow()
        {
            InitializeComponent();
            FromBox.ItemsSource = CurrenciesList;
            FromBox.SelectedItem = CurrenciesList[1];
            ToBox.ItemsSource = CurrenciesList;
            ToBox.SelectedItem = CurrenciesList[0];
        }

        private async void ConvertCurrency(object sender, RoutedEventArgs e)
        {
            From = FromBox.SelectedValue.ToString();
            To = ToBox.SelectedValue.ToString();

            if(AmountField.Text == "" ||  AmountField.Text == "0" ||  AmountField == null )
            {
                MessageBox.Show("Amount must be filled and must be greater then 0");
            }
            else
            {
                Amount = AmountField.Text;
            }

            currencyRequest = new CurrencyRequest(_to, _from, _amount);
            response = await currencyRequest.GetAsync();
            Result.Text = response.Result.ToString();
        }

        private void ClearForm(object sender, RoutedEventArgs e)
        {
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
