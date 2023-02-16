using Microsoft.AspNetCore.Mvc;
using ContactManagementAssistant.ChatGptClient;
using ContactManagementAssistant.CurlUtil;

namespace ContactManagementAssistant.Controllers
{
    [ApiController]
    [Route("mycontroller")]
    public class ContactsManagementController : ControllerBase
    {

        private readonly ILogger<ContactsManagementController> _logger;
        private IChatGptClient chatGptClient;
            
        public ContactsManagementController(ILogger<ContactsManagementController> logger, 
            IChatGptClient chatGptClient)
        {
            this._logger = logger;
            this.chatGptClient = chatGptClient;
        }

        [HttpGet(Name = "getGptResponseTest")]
        public async Task<string> Get()
        {
            return await chatGptClient.Create("add abc to my contacts he lives in 123 street, New York, Usa using microsoft graph api").ConfigureAwait(false);
        }

        [HttpPost(Name = "contactQuery")]
        public async Task<string> Post([FromBody] string prompt)
        {
            var res = await chatGptClient.Create(prompt).ConfigureAwait(false);
            var request = ParseCurl.Parse(res);
            return "abc";
        }
    }
}