using Meme_Platform.Core.Models;
using Meme_Platform.IL.Events;
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
        private string _webHookUrl => _configuration["DiscordPlugin:WebhookUrl"];

        public PostEventHandler(ILogger<PostEventHandler> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Execute(PostModel payload)
        {
            new WebhookRequestService(_logger).ExecutePost(_webHookUrl, payload).GetAwaiter().GetResult();
        }
    }
}
