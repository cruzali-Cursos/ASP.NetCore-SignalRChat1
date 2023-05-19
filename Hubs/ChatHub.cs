using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat1.Hubs
{
    public class ChatHub : Hub
    {
        // Esta funcion se ejecutará desde JS.

        // Distribuye el mensaje a todos los clientes conectados

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
