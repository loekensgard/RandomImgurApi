using RandomImgurApi.Extensions;
using System;
using System.Text.Json.Serialization;

namespace RandomImgurApi.Models
{
    public class Imgur
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime Datetime { get; set; }

        [JsonPropertyName("link")]
        public Uri Link { get; set; }
    }
}
