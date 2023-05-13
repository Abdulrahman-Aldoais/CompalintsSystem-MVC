using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.Hubs
{
    public class NotefcationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Context.Items.Add(Context.UserIdentifier, Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Context.Items.Remove(Context.UserIdentifier);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
