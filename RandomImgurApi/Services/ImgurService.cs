using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ImgurService> _logger;

        public ImgurService(HttpClient httpClient, RandomStringGenerator randomStringGenerator, ILogger<ImgurService> logger)
        {
            _httpClient = httpClient;
            _randomStringGenerator = randomStringGenerator;
            _logger = logger;
        }


        public async Task<Imgur> GetImage()
        {
            return await Policy
                .Handle<Exception>()
                .RetryAsync(10,(resp, count) =>
                {
                    _logger.LogError(resp, "Failed to find image");
                })
                .ExecuteAsync(async () => {
                    var hash = _randomStringGenerator.RandomString(5);
                    return await _httpClient.GetFromJsonAsync<Imgur>($"3/image/{hash}");
                        });
        }


    }
}
