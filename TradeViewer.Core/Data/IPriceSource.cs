using System.Threading.Tasks;

namespace TradeViewer.Core.Data
{
    public interface IPriceSource
    {
        void Subscribe(IPriceSubscriber subscriber);
        void Unsubscribe(IPriceSubscriber subscriber);
        Task StartPublishingAsync();
        void StopPublishing();
    }
}