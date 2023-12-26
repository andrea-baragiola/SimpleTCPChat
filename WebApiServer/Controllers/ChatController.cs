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


        [HttpGet("rooms")]
        public ActionResult<IEnumerable<int>> GetRoomsIds()
        {
            return Ok(_chatStorage.GetRoomsIds());
        }

        [HttpPost("createroom")]
        public ActionResult CreateRoom()
        {
            _chatStorage.AddRoom();
            return Ok();
        }

        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<Message>> GetMessages(int roomId)
        {
            try
            {
                IEnumerable<Message> messages = _chatStorage.GetRoomMessages(roomId);
                return Ok(messages);
            }
            catch
            {
                return NotFound($"Impossibile to retrieve messages for room { roomId }");
            }
        }

        [HttpPost("post")]
        public ActionResult PostMessage([FromBody] Message message)
        {
            try
            {
                _chatStorage.AddMessage(message);
                return Ok();
            }
            catch
            {
                return NotFound($"Impossibile to post messages into room {message.RoomId}");
            }


        }

    }
}
