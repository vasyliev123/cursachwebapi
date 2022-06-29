using Microsoft.AspNetCore.Mvc;
using WebApi.Client;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Mp3Controller : ControllerBase
    {
        [HttpGet(Name = "GetMp3")]
        public byte[] Mp3Get(string text)
        {
            MP3Client client = new MP3Client();

            return client.GetMP3Async(text).Result;
        }

    }
}
