using Polly;
using RandomImgurApi.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RandomImgurApi.Services
{
    public class ImgurService
    {
        private readonly HttpClient _httpClient;
        private readonly RandomStringGenerator _randomStringGenerator;

        public ImgurService(HttpClient httpClient, RandomStringGenerator randomStringGenerator)
        {
            _httpClient = httpClient;
            _randomStringGenerator = randomStringGenerator;
        }


        public async Task<Imgur> GetImage()
        {
            return await Policy
                .Handle<Exception>()
                .RetryAsync(10,(resp, count) =>
                {
                    Console.WriteLine(resp.Message);
                })
                .ExecuteAsync(async () => {
                    var hash = _randomStringGenerator.RandomString(5);
                    return await _httpClient.GetFromJsonAsync<Imgur>($"3/image/{hash}");
                        });
        }


    }
}
