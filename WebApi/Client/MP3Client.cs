using WebApi.Constant;
using WebApi.Model;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WebApi.Client
{
    public class MP3Client
    {

        public async Task<byte[]> GetMP3Async(string text)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://voicerss-text-to-speech.p.rapidapi.com/?key=4181cd8366824ac69566e1d48eb4e97e&src={text}&hl=en-us&r=0&c=mp3&f=8khz_8bit_mono"),
                Headers =
    {
        { "X-RapidAPI-Key", "f9319d662dmsh714ab35a10bdf07p1faeb1jsnaf87613a4e69" },
        { "X-RapidAPI-Host", "voicerss-text-to-speech.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsByteArrayAsync();
              
                return await content;
            }
        }
    }
}
