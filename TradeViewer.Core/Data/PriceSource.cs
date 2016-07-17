using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeViewer.Core.Data
{
    public class PriceSource : IPriceSource
    {
        private readonly IList<IPriceSubscriber> subscribers = new List<IPriceSubscriber>();
        private readonly object locker = new object();
        private volatile bool stopPublish;

        private readonly IPriceGenerator priceGenerator;
        public PriceSource(IPriceGenerator priceGenerator)
        {
            this.priceGenerator = priceGenerator;
        }

        public void Subscribe(IPriceSubscriber subscriber)
        {
            lock (locker)
            {
                if (!subscribers.Contains(subscriber))
                {
                    subscribers.Add(subscriber);
                }
            }
        }

        public void Unsubscribe(IPriceSubscriber subscriber)
        {
            lock (locker)
            {
                subscribers.Remove(subscriber);
            }
        }

        public async Task StartPublishingAsync()
        {
            while (!stopPublish)
            {
                IPriceSubscriber[] subscribersCopy;
                lock (locker)
                {
                    subscribersCopy = subscribers.ToArray();
                }

                foreach (var subscriber in subscribersCopy)
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