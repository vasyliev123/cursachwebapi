
using Newtonsoft.Json;
using WebApi.Constant;
using WebApi.Model;

namespace WebApi.Client
{
    public class ArtistClient 
    {
        
        HttpClient _client;
        private static string _adress;
        private static string _apikey;

        public ArtistClient()
        {
             
            _client = new HttpClient();
            
        }
        public async Task<ArtistModel> GetArtistAsync(string id)
        {
            ArtistModel? result = new ArtistModel();
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://api.spotify.com/v1/artists/{id}/albums"))
            {
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {Constants.apikey}");

                var response = await _client.SendAsync(request);
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ArtistModel>(content);
                return result;
            }
             
        }
    }
}

