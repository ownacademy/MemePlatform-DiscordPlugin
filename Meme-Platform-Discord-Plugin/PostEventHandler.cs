using Meme_Platform.Core;
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
        private readonly IRequestService _requestService;
        private readonly UIConfig _uIConfig;

        private string _webHookUrl => _configuration["DiscordPlugin:WebhookUrl"];

        public PostEventHandler(ILogger<PostEventHandler> logger, 
            IConfiguration configuration,
            IRequestService requestService,
            UIConfig uIConfig)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
            _uIConfig = uIConfig ?? throw new ArgumentNullException(nameof(uIConfig));
        }

        public void Execute(PostModel payload)
        {
            _requestService.ExecutePost(_webHookUrl, payload, _uIConfig);
        }
    }
}
