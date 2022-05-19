using Microsoft.AspNetCore.SignalR;
using Barbershop;

namespace Barbershop.Hubs
{
    public class SignalR : Hub
    {
        public async Task addUser(string customer)
        {
            myQue.add(customer);
            var currentArray = myQue.current.ToArray();
            await Clients.All.SendAsync("Update", currentArray);
        }
        public async Task removeUser()
        {
            myQue.remove();
            var currentArray = myQue.current.ToArray();
            await Clients.All.SendAsync("Update", currentArray);
        }
        public async Task BroadcastMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            var currentArray = myQue.current.ToArray();
            await Clients.All.SendAsync("Update", currentArray);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}