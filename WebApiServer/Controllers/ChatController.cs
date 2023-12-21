using Microsoft.AspNetCore.Mvc;
using WebApiServer.Models;
using WebApiServer.Storage;


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

        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<string>> GetMessages(int roomId)
        {
            return Ok(_chatStorage.GetRoomMessages(roomId));
        }


        [HttpPost("post")]
        public ActionResult PostMessage([FromBody] Message message)
        {
            _chatStorage.AddMessage(message);
            return Ok();
        }
    }
}
