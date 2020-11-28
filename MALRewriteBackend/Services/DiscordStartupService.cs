using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MALRewriteBackend.Services
{
    public class DiscordStartupService : IHostedService
    {
        private readonly DiscordSocketClient _client;
        private readonly IConfiguration _configuration;

        public DiscordStartupService(DiscordSocketClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var token = _configuration["Tokens:Discord"];

            if (string.IsNullOrWhiteSpace(token))
            {
                return;
            }
            
            try
            {
                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();
            }
            catch
            {
                Console.WriteLine("Token not found!");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.LogoutAsync();
            await _client.StopAsync();
        }
    }
}