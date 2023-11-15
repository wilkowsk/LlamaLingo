using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using LlamaLingo.Models;

namespace LlamaLingo.Pages
{
    public partial class Index
    {
        private HubConnection hubConnection;
        private List<UserMessage> userMessages = new();
        private string usernameInput;
        private string messageInput;
        private bool isUserReadonly = false;
        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/chathub")).Build();
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                InvokeAsync(() =>
                {
                    userMessages.Add(new UserMessage { Username = user, Message = message, CurrentUser = user == usernameInput, DataSent = DateTime.Now });
                    StateHasChanged();
                });
            });
            await hubConnection.StartAsync();
        }

        private async System.Threading.Tasks.Task Send()
        {
            if (!string.IsNullOrEmpty(usernameInput) && !string.IsNullOrEmpty(messageInput))
            {
                await hubConnection.SendAsync("SendMessage", usernameInput, messageInput);
                isUserReadonly = true;
                messageInput = string.Empty;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}