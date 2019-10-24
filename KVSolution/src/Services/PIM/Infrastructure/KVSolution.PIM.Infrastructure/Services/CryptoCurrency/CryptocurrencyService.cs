using System;
using System.Web;
using System.Net;
using System.Linq;

namespace KVSolution.PIM.Infrastructure.Services.CryptoCurrency
{
    public static class CryptocurrencyService
    {
        private static string API_KEY = "bc77c358-5071-4690-b8d2-343748eebf98";
        private static string API_URI = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/map";

        public static string Get(string symbols)
        {
            var URL = new UriBuilder(API_URI);

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = string.Join(",", symbols); 

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }
    }
}
