using System;
using System.Collections.Generic;

namespace StockDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a dictionary of stocks key: ticker name; value: company name
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("AEO", "American Eagle Outfitters");
            stocks.Add("ZM", "Zoom");
            stocks.Add("ETSY", "Etsy");
            stocks.Add("MRNA", "Moderna");
            stocks.Add("GME", "GameStop Corp");

            //create a list of purchaces, accepting three values: ticker name, number of shares, price per share
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GM", shares: 150, price: 23.21));
            purchases.Add((ticker: "GM", shares: 32, price: 17.87));
            purchases.Add((ticker: "GM", shares: 80, price: 19.02));
            purchases.Add((ticker: "CAT", shares: 12, price: 16.45));
            purchases.Add((ticker: "AEO", shares: 40, price: 20.56));
            purchases.Add((ticker: "ZM", shares: 60, price: 45.01));
            purchases.Add((ticker: "ETSY", shares: 50, price: 30.45));
            purchases.Add((ticker: "MRNA", shares: 90, price: 12.56));
            purchases.Add((ticker: "GME", shares: 80, price: 19.02));
            purchases.Add((ticker: "ETSY", shares: 30, price: 40.67));
            purchases.Add((ticker: "AEO", shares: 80, price: 13.02));

            //create an ownership dictionary: the key being the ticker name, the value being the shares * prices from purchaces
            Dictionary<string, double> ownershipReport = new Dictionary<string, double>();

            //loop over your list of purchaces. for each purchace, set the dictionary value in owernshipReport to share * price.
            //if the company already has an entry in the owndership dictionary, add the new total to that total
            //if the company does not yet exist in the ownership dictionary, create that entry in the dictionary. key: ticker name value: total Value
            foreach ((string ticker, int shares, double price) p in purchases)
            {
                var totalValue = p.shares * p.price;

                if (ownershipReport.ContainsKey(p.ticker))
                {
                    ownershipReport[p.ticker] += totalValue;
                    Console.WriteLine($"{p.ticker} {totalValue}");
                }
                else
                {
                    ownershipReport.Add(p.ticker, totalValue);
                    Console.WriteLine($"{p.ticker} {totalValue}");
                }
            }

            //print your total results. loop over owndership reports and check them against the stock dictionary to get the full company name. 
            //if they match, print the company name interpolated with the value from the ownership table
            Console.WriteLine("///////////////Ownership Report////////////////");


            foreach (var own in ownershipReport)
            {
                foreach (var stock in stocks)
                {
                    if (own.Key == stock.Key)
                    {
                        Console.WriteLine($"{stock.Value}: {own.Value}");
                    }
                }
            }
        }
    }
}
