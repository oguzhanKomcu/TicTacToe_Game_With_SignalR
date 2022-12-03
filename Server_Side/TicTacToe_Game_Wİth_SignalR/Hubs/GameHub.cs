using Microsoft.AspNetCore.SignalR;
using TicTacToe_Game_Wİth_SignalR.Data;
using TicTacToe_Game_Wİth_SignalR.Models;

namespace TicTacToe_Game_Wİth_SignalR.Hubs
{
    public class GameHub : Hub
    {
        public async Task GetNickName(string nickName)
        {
            Client client = new Client();
            client.ConnectionId = Context.ConnectionId;
            client.NickName = nickName;

            ClientSource.Clients.Add(client);
           
            await Clients.All.SendAsync("clients", ClientSource.Clients);

        }
        //Message send func
        public async Task SendMessageAsync(string message, string clientName)
        {
            clientName = clientName.Trim();
            Client senderClient = ClientSource.Clients.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId);
            if (clientName == "All")
            {
                await Clients.All.SendAsync("receiveMessage", message, senderClient.NickName);
            }
            else
            {
                Client client = ClientSource.Clients.FirstOrDefault(C => C.NickName == clientName);
                await Clients.Client(client.ConnectionId).SendAsync("receiveMessage", message, senderClient.NickName);
                //45
            }
        }

 
    }
}
