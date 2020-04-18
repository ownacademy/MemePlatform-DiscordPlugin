using Meme_Platform_Discord_Plugin.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meme_Platform_Discord_Plugin.Services
{
    internal class WebhookRequestService : IRequestService
    {
        private readonly ILogger<PostEventHandler> _logger;

        public WebhookRequestService(ILogger<PostEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task ExecutePost(string WebhookUrl, DiscordWebhookRequestModel requestModel)
        {
            try
            {
                HttpClient client = new HttpClient();
                //2 minute timeout on wait for response
                client.Timeout = new TimeSpan(0, 2, 0);
                //Create an HttpRequestMessage object and pass it into SendAsync()
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.Content = new StringContent(JsonConvert.SerializeObject(requestModel), System.Text.Encoding.UTF8, "application/json");
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri(WebhookUrl);

                HttpResponseMessage response = await client.SendAsync(message);
                var result = await response.Content.ReadAsStringAsync();
                //deserialize the result into proper object type

                //_logger.LogInformation("The message was succesfully send to the discord channel.");
            }
            catch (Exception ex)
            {
                //_logger.LogError($"The following message error has occurred: {ex.Message}.");
            }

        }
    }
}
