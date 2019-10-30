using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KVSolution.PIM.Application.Cryptocurrencies
{
    public class CryptocurrencyModel
    {
        public List<CryptocurrencyItem> Data { get; set; }
        public object Status { get; set; }
    }

    public class CryptocurrencyItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public int Rank { get; set; }
    }

    public class CryptocurrencyItemQuote
    {
        public string Price { get; set; }
        [JsonProperty("volume_24h")]
        public string Volume_24h { get; set; }
        [JsonProperty("percent_change_1h")]
        public string Percent_Change_1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public string Percent_Change_24h { get; set; }
        [JsonProperty("percent_change_7d")]
        public bool Percent_Change_7d { get; set; }
        [JsonProperty("market_cap")]
        public string Market_cap { get; set; }
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

    public class QuoteMetadata
    {
        [JsonProperty("USD")]
        public CryptocurrencyItemQuote Value { get; set; }
    }

    public class Metadata
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        [JsonProperty("quote")]
        public QuoteMetadata Quote { get; set; }
    }

    public class DataQuote
    {
        [JsonProperty("1")]
        public Metadata Value { get; set; }
    }

    public class CryptocurrencyQuote
    {
        public object Status { get; set; }
        public DataQuote Data { get; set; }
    }
}
