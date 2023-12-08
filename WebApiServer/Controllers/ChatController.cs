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

        [HttpGet("new")]
        public ActionResult<IEnumerable<string>> GetNewMessages()
        {
            return Ok(_chatStorage.NewMessages);
        }

        [HttpPost("post")]
        public ActionResult PostMessage([FromBody] string message)
        {
            _chatStorage.NewMessages.Add(message);
            return Ok();
        }


        //// GET: api/<ChatController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ChatController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ChatController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ChatController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ChatController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
