using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeViewer.Core.Data
{
    public class PriceSource : IPriceSource
    {
        private readonly IList<IPriceSubscriber> subscribers = new List<IPriceSubscriber>();
        private readonly IPriceGenerator priceGenerator;

        private volatile bool stopPublish;
        public PriceSource(IPriceGenerator priceGenerator)
        {
            this.priceGenerator = priceGenerator;
        }

        public void Subscribe(IPriceSubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(IPriceSubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public async Task StartPublishingAsync()
        {
            while (!stopPublish)
            {
                foreach (var subscriber in subscribers)
                {
                    decimal price = priceGenerator.GeneratePrice();
                    subscriber.PriceUpdated(price);
                }
                await Task.Delay(1000);
            }
        }

        public void StopPublishing()
        {
            stopPublish = true;
        }
    }
}