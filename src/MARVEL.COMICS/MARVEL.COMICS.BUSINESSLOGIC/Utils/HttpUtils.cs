using MARVEL.COMICS.BUSINESSLOGIC.Models.Token;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MARVEL.COMICS.BUSINESSLOGIC.Utils
{
    public class HttpUtils
    {
        private readonly HttpClient _httpClient;

        public HttpUtils()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> Post(string route, string payload, string authorization = "")
        {
            if (string.IsNullOrEmpty(authorization) == false)
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authorization);
            }

            using StringContent jsonContent = new StringContent(payload, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _httpClient.PostAsync(route, jsonContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Get(string route, string authorization = "")
        {
            if (string.IsNullOrEmpty(authorization) == false)
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authorization);
            }

            using HttpResponseMessage response = await _httpClient.GetAsync(route);

            string result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<TokenOutput> GetToken(string route, decimal applicationId, string applicationSecret)
        {
            var payload = new Application { Id = applicationId, Secret = applicationSecret };

            var json = JsonConvert.SerializeObject(payload);

            var output = await this.Post(route, json);

            if (string.IsNullOrEmpty(output) == false)
            {
                return JsonConvert.DeserializeObject<TokenOutput>(output);
            }

            return null;

        }
    }
}
