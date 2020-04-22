using Meme_Platform.Core;
using Meme_Platform.Core.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meme_Platform_Discord_Plugin.Services
{
    public class WebhookRequestService : IRequestService
    {
        private readonly ILogger<PostEventHandler> _logger;

        public WebhookRequestService(ILogger<PostEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task ExecutePost(string webhookUrl, PostModel payload, UIConfig uIConfig)
        {
            try
            {
                HttpClient client = new HttpClient();
                
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(uIConfig.SiteName), "username");
                    content.Add(new StringContent(uIConfig.SiteLogo), "avatar_url");
                    content.Add(new StringContent(payload.Title), "content");
                    content.Add(new StreamContent(new MemoryStream(payload.Content.Data)), "file", $"file.{payload.Content.Extension}");

                    await client.PostAsync(webhookUrl, content);

                    client.Dispose();
                };

                _logger.LogInformation("The message was succesfully send to the discord channel.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"The following message error has occurred: {ex.Message}.");
            }

        }
    }
}
