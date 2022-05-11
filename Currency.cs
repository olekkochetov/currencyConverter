using Newtonsoft.Json;

namespace CurrencyConverterStatic
{
    public class Currency
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty ("query")]
        public QueryClass Query { get; set; }

        [JsonProperty("info")]
        public InfoClass Info { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
        
        [JsonProperty("result")]
        public double Result { get; set; }

    }
    public class QueryClass
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
    public class InfoClass
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty("rate")]
        public double Rate { get; set; }
    }
}
