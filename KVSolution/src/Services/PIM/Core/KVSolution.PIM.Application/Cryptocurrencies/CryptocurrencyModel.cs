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
}
