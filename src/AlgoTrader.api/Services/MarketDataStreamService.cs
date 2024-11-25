using System.Net.WebSockets;
using System.Text;

namespace AlgoTrader.api.Services
{
    public class MarketDataStreamService : IMarketDataStreamService
    {
        // TODO: Handle how received market data is stored/manipulated and passed on to the trading service
        private ClientWebSocket _webSocket;
        public event Action<string> OnMarketDataReceived;

        public async Task ConnectAsync(string uri, CancellationToken cancellationToken)
        {
            _webSocket = new ClientWebSocket();

            // Connect to the WebSocket server
            await _webSocket.ConnectAsync( new Uri(uri), cancellationToken);
            Console.WriteLine($"Connected to WebSocket server: {uri}");

            // Start receiving data from server
            await ReceiveDataAsync(cancellationToken);
        }

        private async Task ReceiveDataAsync(CancellationToken cancellationToken)
        {
            var buffer = new byte[4096];

            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                if (result.MessageType == WebSocketMessageType.Close) 
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
                    Console.WriteLine("WebSocket connection closed.");
                    break;
                }

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    // Trigger the event for received market data
                    // TODO: Change the event invoke action to store and pass the data instead
                    OnMarketDataReceived?.Invoke(message);
                }
            }
        }
    }
}
