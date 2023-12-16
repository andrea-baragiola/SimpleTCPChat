using Microsoft.AspNetCore.Mvc;
using WebApiServer.Models;


namespace WebApiServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatStorage _chatStorage;

        public ChatController(IChatStorage chatStorage)
        {
            _chatStorage = chatStorage;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<string>> GetMessages()
        {
            return Ok(_chatStorage.AllMessages);
        }

        [HttpPost("post")]
        public ActionResult PostMessage([FromBody] Message message)
        {
            _chatStorage.AllMessages.Add($"{message.MessageSender}: {message.Content}");
            return Ok();
        }
    }
}
