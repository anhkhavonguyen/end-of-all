using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;

namespace KVSolution.PIM.Infrastructure.Services.CryptoCurrency
{
    public static class CryptocurrencyService
    {
        private static string API_KEY = "bc77c358-5071-4690-b8d2-343748eebf98";

        public static string makeAPICall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/map");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = "BTC,USDT,BNB";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }
    }
}
