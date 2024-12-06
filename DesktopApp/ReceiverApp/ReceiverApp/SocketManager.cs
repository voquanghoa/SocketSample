using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiverApp
{
    public enum MessageType
    {
        MaYTe
    }

    public class SocketMessage
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType Type { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

    }

    public delegate void SocketMessageReceivedHandler(SocketMessage message);

    public class SocketManager
    {
        public static SocketManager Instance { get; } = new SocketManager();

        public const int Port = 6721;
        public const int BufferSize = 1024 * 10;

        public event SocketMessageReceivedHandler EventReceived;

        private readonly CancellationTokenSource cancellationTokenSource = new();
        private readonly TcpListener listener = new(System.Net.IPAddress.Any, Port);

        public void Start()
        {
            listener.Start();
            Console.WriteLine($"Listening on port {Port}");

            _ = StartListening();
        }

        private async Task StartListening()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    using var client = await listener.AcceptTcpClientAsync(cancellationTokenSource.Token);

                    await ReadSocket(client);

                    client.Close();
                } 
                catch (Exception ex)
                {
                    await Console.Error.WriteLineAsync(ex.Message);
                }

            }
        }

        private async Task ReadSocket(TcpClient client)
        {
            await using var stream = client.GetStream();
            var buffer = new byte[BufferSize]; //10Kb chắc đủ rồi
            var bytesRead = stream.Read(buffer, 0, buffer.Length);

            var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Received: {message}");

            var data = JsonSerializer.Deserialize<SocketMessage>(message);


            if (data is { Type: MessageType.MaYTe })
            {
                EventReceived?.Invoke(data);
            }
        }


        public void Close()
        {
            cancellationTokenSource.Cancel();
            listener.Stop();
        }
    }
}
