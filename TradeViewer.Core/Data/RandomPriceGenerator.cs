using System;

namespace TradeViewer.Core.Data
{
    public class RandomPriceGenerator : IPriceGenerator
    {
        private const int MaxPrice = 100;
        private readonly Random priceGenerator = new Random();

        public decimal GeneratePrice()
        {
            decimal price = (decimal)priceGenerator.NextDouble() * MaxPrice;
            return Math.Round(price, 4);
        }
    }
}