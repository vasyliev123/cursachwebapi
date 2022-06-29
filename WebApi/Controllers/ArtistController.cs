using Microsoft.AspNetCore.Mvc;
using WebApi.Client;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        [HttpGet(Name = "GetArtist")]
        public ArtistModel ArtistGet(string id)
        {
            ArtistClient client = new ArtistClient();

            return client.GetArtistAsync(id).Result;
        }
        
    }
}
