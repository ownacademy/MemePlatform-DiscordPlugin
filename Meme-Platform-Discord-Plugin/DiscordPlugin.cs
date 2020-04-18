using Meme_Platform.IL;
using Microsoft.Extensions.DependencyInjection;

namespace Meme_Platform_Discord_Plugin
{
    class DiscordPlugin : IPlugin
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public string GetDescription()
        {
            return "This plugin repost the post of meme platform to discord through webhook url";
        }

        public string GetName()
        {
            return "Meme Platform Discord Plugin";
        }

        public string GetVersion()
        {
            return "1.0.0";
        }
    }
}
