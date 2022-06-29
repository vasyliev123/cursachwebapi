using Newtonsoft.Json;
using WebApi.Constant;
using WebApi.Model;

namespace WebApi.Client
{  
    public class ArtistIdClient
    {
        HttpClient _client;
        public ArtistIdClient()
        {
               _client = new HttpClient();
            
        }
        public async Task<ArtistIdModel> ArtistIdGet(string artist)
        {
            ArtistIdModel? result = new ArtistIdModel();
           
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://api.spotify.com/v1/search?q={artist}&type=artist"))
                {
                   
                try
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json");
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {Constants.apikey}");
                    var response = await _client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var content = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<ArtistIdModel>(content);
                    return result;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return result;
                }
                }
            
        }
    }
}
