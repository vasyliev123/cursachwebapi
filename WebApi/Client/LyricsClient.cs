
using WebApi.Constant;
using WebApi.Model;
using Newtonsoft.Json;

namespace WebApi.Client
{
    public class LyricsClient
    {
        HttpClient _client;
        private static string _adress;
        private static string _apikey;

        public LyricsClient()
        {
            _adress = Constants.adress;
            _apikey = Constants.apikey;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
        }
        public async Task<LyricsModel> GetLyricsAsync(string artist, string title)
        {
            LyricsModel? result = new LyricsModel();
             
            result.Lyrics = "no lyrics found";
            
            try
            {
                var responce = await _client.GetAsync($"/v1/{artist}/{title}");
                responce.EnsureSuccessStatusCode();
                var content = responce.Content.ReadAsStringAsync().Result;

                //convert to json
                result = JsonConvert.DeserializeObject<LyricsModel>(content);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR ERROR{e}");
                return result;
            }
        }

    }
}
