using Meme_Platform.Core.Models;
using Meme_Platform_Discord_Plugin;
using NUnit.Framework;

namespace Discord_Webhook_Test
{
    public class DiscordWebhookTest
    {
        //post mode
        //Iconfiguration

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostToDiscordTest()
        {
            new PostEventHandler(null, null).Execute(new PostModel { });
        }
    }
}