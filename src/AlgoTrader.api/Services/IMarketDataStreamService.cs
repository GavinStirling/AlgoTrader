namespace AlgoTrader.api.Services
{
    public interface IMarketDataStreamService
    {
        Task ConnectAsync(string uri, CancellationToken cancellationToken);
        event Action<string> OnMarketDataReceived;
    }
}
