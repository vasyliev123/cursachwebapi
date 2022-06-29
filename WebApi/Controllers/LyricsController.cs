using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Client;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LyricsController : ControllerBase
    {
        [HttpGet(Name = "GetLyrics")]
        public LyricsModel LyricsGet(string artist, string title)
        {
            LyricsClient client = new LyricsClient();

            return client.GetLyricsAsync(artist, title).Result;
        }
        

        [HttpPost(Name = "PostSmth")]
        public async Task PostSmth()
        {
            Console.WriteLine("PostSmth");
        }
        [HttpDelete(Name = "DeleteSmth")]
        public async Task DeleteSmth()
        {
            Console.WriteLine("DeleteSmth");
        }
         
    }
}
