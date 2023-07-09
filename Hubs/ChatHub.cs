using Microsoft.AspNetCore.SignalR;
using SignalRChat1.Models;
using System.Threading.Tasks;

namespace SignalRChat1.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;

        public ChatHub()
        {
            _botUser = "MyChat Bot";
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
            await Clients.Group(userConnection.Room)
                        .SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} se ha unido {userConnection.Room}");
        }

        // Esta funcion se ejecutará desde JS.
        // Distribuye el mensaje a todos los clientes conectados

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
