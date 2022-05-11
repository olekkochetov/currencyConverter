﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyConverterStatic
{
    internal class CurrencyRequest : HttpClient 
    {
        private string _to = "";
        private string _from = "";
        private string _amount = "";
        private const string url = @"https://api.apilayer.com/exchangerates_data/convert";
        private const string TOKEN = "10Q091WyjvKknp4nZsp8JlkFm3eiqWsd";

        public string Result = "";
        public string To { get { return _to; } set { _to = value; } }
        public string From { get { return _from; } set { _from = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }


        public CurrencyRequest(string to, string from, string amount)
        {
            To = to;
            From = from;
            Amount = amount;
        }

        private string GetQueryString()
        {
            return new string($"{url}?to={To}&from={From}&amount={Amount}&apikey={TOKEN}");
        }

        public async void GetAsync()
        {
            string res;
            using (HttpClient client = new HttpClient())
            {
                Result = await client.GetStringAsync($"{url}?to={To}&from={From}&amount={Amount}&apikey={TOKEN}");
                MessageBox.Show(Result);

                //using (StreamWriter sw = new StreamWriter("my.json"))
                //{
                //    await sw.WriteAsync(res);
                //}
            }
        }
    }
}
