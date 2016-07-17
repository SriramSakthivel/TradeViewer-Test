using System;
using TradeViewer.Core.Data;

namespace TradeViewer.Infrastructure.Data
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