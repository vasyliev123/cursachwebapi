using Microsoft.AspNetCore.Mvc;
using WebApi.Client;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistIdController : ControllerBase
    {
        [HttpGet(Name = "GetArtistId")]
        public ArtistIdModel ArtistIdGet(string artist)
        {
            ArtistIdClient client = new ArtistIdClient();

            return client.ArtistIdGet(artist).Result;
        }
    }
}
