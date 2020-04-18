using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meme_Platform_Discord_Plugin.Models
{
    /// <summary>
    /// Discord Webhook Request Model
    /// <see cref="https://discordapp.com/developers/docs/resources/webhook"/> for more information
    /// </summary>
    public class DiscordWebhookRequestModel
    {
        /// <summary>
        /// Username shown in discord
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The avatar shown in discord
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Content that is shown in discord as message
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// File send to discord
        /// </summary>
        //[JsonProperty("file")]
        //public File File { get; set; }
    }
}
