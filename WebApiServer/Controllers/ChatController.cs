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
        public ActionResult<IEnumerable<Message>> GetMessages(int roomId)
        {
            return Ok(_chatStorage.GetRoomMessages(roomId));
        }

        [HttpGet("rooms")]
        public ActionResult<IEnumerable<int>> GetRoomsIds()
        {
            return Ok(_chatStorage.GetRoomsIds());
        }


        [HttpPost("post")]
        public ActionResult PostMessage([FromBody] Message message)
        {
            _chatStorage.AddMessage(message);
            return Ok();
        }

        [HttpPost("createroom")]
        public ActionResult CreateRoom()
        {
            _chatStorage.AddRoom();
            return Ok();
        }
    }
}
