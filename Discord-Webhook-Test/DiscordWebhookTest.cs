using Meme_Platform.Core;
using Meme_Platform.Core.Models;
using Meme_Platform_Discord_Plugin;
using Meme_Platform_Discord_Plugin.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net.Http;

namespace Discord_Webhook_Test
{
    public class DiscordWebhookTest
    {
        private Mock<IConfiguration> _configuration;
        private IRequestService _requestService;
        private Mock<ILogger<PostEventHandler>> _logger;

        private PostModel payload = new PostModel { 
            Title = "Discord Plugin",
            Content = new ContentModel { 
                Data = new HttpClient().GetAsync("NOTE: URL to image you want to download and convert as bynary").Result.Content.ReadAsByteArrayAsync().Result,
                Extension = "jpeg"
            }
        };

        [SetUp]
        public void Setup()
        {
            _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "DiscordPlugin:WebhookUrl")]).Returns("NOTE: Webhook url to discord channel");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "UI:Name")]).Returns("NOTE: Name you want to see displayed in discord");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "UI:Logo")]).Returns("NOTE: Logo that you want displayed");
            _logger = new Mock<ILogger<PostEventHandler>>();
            _requestService = new WebhookRequestService(_logger.Object);
        }

        [Test]
        public void PostToDiscordTest()
        {
            new PostEventHandler(_logger.Object, _configuration.Object, _requestService, new UIConfig(_configuration.Object)).Execute(payload);
        }
    }
}