using Microsoft.AspNetCore.Mvc;


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
        public ActionResult PostMessage([FromBody] string message)
        {
            _chatStorage.AllMessages.Add(message);
            return Ok();
        }
    }
}
