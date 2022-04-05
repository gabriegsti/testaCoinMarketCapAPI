
using System;
using System.Net;
using System.Web;

class CSharpExample
{
    private static string API_KEY = "";

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(makeAPICall());
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static string makeAPICall()
    {
        var URL = new UriBuilder(" https://pro-api.coinmarketcap.com/v1/global-metrics/quotes/historical");

        var queryString = HttpUtility.ParseQueryString(string.Empty);
        queryString["start"] = "1";
        queryString["limit"] = "5000";
        queryString["convert"] = "USD";

        URL.Query = queryString.ToString();

        var client = new WebClient();
        client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
        client.Headers.Add("Accepts", "application/json");
        return client.DownloadString(URL.ToString());

    }

}

