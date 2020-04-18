using Meme_Platform.Core.Models;
using Meme_Platform.IL.Events;
using Meme_Platform_Discord_Plugin.Models;
using Meme_Platform_Discord_Plugin.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace Meme_Platform_Discord_Plugin
{
    public class PostEventHandler : IPostCreatedEventHandler
    {
        private readonly ILogger<PostEventHandler> _logger;
        private readonly IConfiguration _configuration;
        public string WebHookUrl => _configuration["DiscordPlugin:WebhookUrl"];

        public PostEventHandler(ILogger<PostEventHandler> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async void Execute(PostModel payload)
        {
            var requestBody = new DiscordWebhookRequestModel {
                Username = "Super Saiyan",
                AvatarUrl = "https://images.everyeye.it/img-screenshot/super-dragon-ball-heroes-v1-553454-160x160.jpg",
                Content = "kamehameha"
            };
            var url = "https://discordapp.com/api/webhooks/700794589715497060/rFsq-fE1p9QCpLksCHRNzHWqVoz6yi2jy32VDzndbYf6oKsDw_Wm-7WZ9o8r8fM_cdsj";
            new WebhookRequestService(_logger).ExecutePost(url , requestBody).GetAwaiter().GetResult();
        }
    }
}
