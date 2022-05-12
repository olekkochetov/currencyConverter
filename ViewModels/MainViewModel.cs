using CurrencyConverterStatic.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyConverterStatic.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private ObservableCollection<string> _currenciesList = new ObservableCollection<string>() { "UAH", "EUR", "USD", "RUB" };

        private string _from = "EUR";
        private string _to = "UAH";
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
        public string Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }
        public string Res 
        {
            get { return _result; }
            set {
                _result = value;
                OnPropertyChanged();
            } 
        }
        public int selectedIndexTo { get; set; } = 1;
        public int selectedIndexFrom { get; set;} = 0;
        public ObservableCollection<string> CurrenciesList { get { return _currenciesList; } }

        public ButtonClickCommand Convert { get { return new ButtonClickCommand(ClickConvertButton); } }
        public ButtonClickCommand Clear { get { return new ButtonClickCommand(ClickClearButton); } }
        public ButtonClickCommand Swip { get { return new ButtonClickCommand(ClickSwip); } }
        CurrencyRequestViewModel? currencyRequest;
        CurrencyModel? response;


        public async void ClickConvertButton(object ob)
        {
            currencyRequest = new CurrencyRequestViewModel(To, From, Amount);
            response = await currencyRequest.GetAsync();
            Res = response.Result.ToString();
        }

        public void ClickClearButton(object ob)
        {
            Amount = "";
            Res = "0";
        }

        public void ClickSwip(object ob)
        {
            string tmp = To;
            To = From;
            From = tmp;
        }
    }
}
