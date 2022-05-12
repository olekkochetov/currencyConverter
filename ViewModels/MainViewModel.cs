using CurrencyConverterStatic.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CurrencyConverterStatic.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private ObservableCollection<string> _currenciesList = new ObservableCollection<string>() { "UAH", "EUR", "USD", "RUB" };

        private string _from = "";
        private string _to = "";
        private string _amount = "10";
        private string _result = "";

        public string To
        { 
            get { return _to; }
            set 
            {
                _to = value;
                OnPropertyChanged();
            }
        }
        public string From 
        { 
            get { return _from; }
            set
            { 
                _from = value;
                OnPropertyChanged();
            } 
        }
        public string Amount { get { return _amount; } set { _amount = value; } }
        public string Res 
        {
            get { return _result; }
            set {
                _result = value;
                OnPropertyChanged();
            } 
        }

        public ObservableCollection<string> CurrenciesList { get { return _currenciesList; } }

        public ConvertCommand convert { get { return new ConvertCommand(ClickEvent); } }
        CurrencyRequestViewModel? currencyRequest;
        CurrencyModel? response;


        public async void ClickEvent(object ob)
        {
            currencyRequest = new CurrencyRequestViewModel(To, From, Amount);
            response = await currencyRequest.GetAsync();
            Res = response.Result.ToString();
        }
    }
}
