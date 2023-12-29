using Microsoft.AspNetCore.Mvc;
using WebApiServer.Models;
using DBAccessLibrary.Storage;
using AutoMapper;
using Microsoft.Data.SqlClient;


namespace WebApiServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatStorage _chatStorage;
        private readonly IMapper _mapper;

        public ChatController(IChatStorage chatStorage, IMapper mapper)
        {
            _chatStorage = chatStorage;
            _mapper = mapper;


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
        public ActionResult<IEnumerable<APIMessage>> GetMessages(int roomId)
        {
            try
            {
                IEnumerable<DBAMessage> messages = _chatStorage.GetRoomMessages(roomId);
                var apiMessages = _mapper.Map<IEnumerable<APIMessage>>(messages);
                return Ok(apiMessages);
            }
            catch
            {
                return NotFound($"Impossible to retrieve messages for room {roomId}");
            }
        }

        [HttpPost("post")]
        public ActionResult PostMessage([FromBody] APIMessage message)
        {
            try
            {
                var dbaMessage = _mapper.Map<DBAMessage>(message);
                _chatStorage.AddMessage(dbaMessage);
                return Ok();
            }
            catch
            {
                return NotFound($"Impossibile to post messages into room {message.RoomId}");
            }


        }

    }
}
