using Microsoft.AspNetCore.SignalR;
using Barbershop.Data;

namespace Barbershop.Hubs
{
    public class SignalR : Hub
    {
        public async Task addUser(string user)
        {
            myQue.addUser(user);
            await Clients.All.SendAsync("Update", myQue.current);
        }

        public async Task rmUser()
        {
            myQue.rmUser();
            await Clients.All.SendAsync("Update", myQue.current);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.All.SendAsync("Update", myQue.current);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}