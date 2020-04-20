using Meme_Platform.Core.Models;
using Meme_Platform_Discord_Plugin;
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
        private Mock<ILogger<PostEventHandler>> _logger;

        private PostModel payload = new PostModel { 
            Title = "Test title",
            Owner = new ProfileModel { 
                ProfilePictureUrl = "https://giantbomb1.cbsistatic.com/uploads/square_small/8/87790/3068872-doom.png",
                Nickname = "Doomguy"
            },
            Content = new ContentModel { 
                Data = new HttpClient().GetAsync("https://cdn.mos.cms.futurecdn.net/8s4zT24dY2bQUcVXwpipxL.jpg").Result.Content.ReadAsByteArrayAsync().Result,
                Extension = "jpeg"
            }
        };
        [SetUp]
        public void Setup()
        {
            _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "DiscordPlugin:WebhookUrl")]).Returns("https://discordapp.com/api/webhooks/701482359203299329/HhCaCMlY9kOXEEpJ0jIjuiLRxE3Cyqm8Q3I4W7C5b6AVENqp_jZDWkYBY68Nd2jIp5oh");
            _logger = new Mock<ILogger<PostEventHandler>>();
        }

        [Test]
        public void PostToDiscordTest()
        {
            new PostEventHandler(_logger.Object, _configuration.Object).Execute(payload);
        }
    }
}