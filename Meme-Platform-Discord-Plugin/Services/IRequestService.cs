using Meme_Platform.Core;
using Meme_Platform.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meme_Platform_Discord_Plugin.Services
{
    public interface IRequestService
    {
        public Task ExecutePost(string webhookUrl, PostModel payload, UIConfig uIConfig);
    }
}
