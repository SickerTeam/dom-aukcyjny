using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("Auction/{id}/[controller]")]
    public class BidController(IBidService bidService) : ControllerBase
    {
        private readonly IBidService _bidService = bidService;
        private readonly Dictionary<int, HashSet<WebSocket>> _auctionConnections = [];

        [HttpGet]
        public async Task Get(int id)
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var auctionId = id;
                Console.WriteLine("Auction ID: " + auctionId);
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var buffer = new byte[1024 * 4];
                
                if (!_auctionConnections.TryGetValue(auctionId, out var webSockets))
                {
                    webSockets = [];
                    _auctionConnections[auctionId] = webSockets;
                }

                webSockets.Add(webSocket);

                var bids = await _bidService.GetAllBidsForAuctionAsync(auctionId);
                var bidsJson = JsonSerializer.Serialize(bids);
                Console.WriteLine("ALL BIDS FROM DB: " + bidsJson);
                buffer = Encoding.UTF8.GetBytes(bidsJson);
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, bidsJson.Length), WebSocketMessageType.Text, true, CancellationToken.None);

                StringBuilder receivedData = new();

                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    
                    var bufferMemory = new Memory<byte>(buffer);

                    // Slice the memory to only include up to result.Count
                    var slicedBufferMemory = bufferMemory[..result.Count];

                    // Convert the sliced memory to a string
                    var jsonString = Encoding.UTF8.GetString(slicedBufferMemory.Span);

                    // Append the received data to the StringBuilder
                    receivedData.Append(jsonString);

                    // Check if the received data contains a complete JSON object
                    if (receivedData.ToString().EndsWith('}'))
                    {
                        Console.WriteLine(receivedData.ToString());
                        // Deserialize the JSON string into a BidRegistrationDTO
                        var bidRegistrationDTO = JsonSerializer.Deserialize<BidRegistrationDTO>(receivedData.ToString());
                        if (bidRegistrationDTO != null)
                        {
                            Console.WriteLine(bidRegistrationDTO.Amount);
                            Console.WriteLine(bidRegistrationDTO.UserId);
                            Console.WriteLine(bidRegistrationDTO.AuctionId);
                            // await AddBidAsync(bidRegistrationDTO);
                        }
                        else
                        {
                            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        receivedData.Clear();
                    }
                }
                webSockets.Remove(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
        private async Task AddBidAsync(BidRegistrationDTO bidRegistrationDTO)
        {
            var bidDTO = await _bidService.AddBidAsync(bidRegistrationDTO);
            Console.WriteLine("Bid was registered: " + bidDTO);
            if (_auctionConnections.TryGetValue(bidRegistrationDTO.AuctionId, out var webSockets))
            {
                var bidJson = JsonSerializer.Serialize(bidDTO);
                Console.WriteLine("Bid was serialized: " + bidDTO);
                var buffer = Encoding.UTF8.GetBytes(bidJson);
                foreach (var webSocket in webSockets)
                {
                    if (webSocket.State == WebSocketState.Open)
                    {
                        await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, bidJson.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                        Console.WriteLine("Shit send AF");
                    }
                }
            }
        }
    }
}