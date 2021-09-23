using System;
using System.Linq;

namespace RandomImgurApi.Services
{
    public class RandomStringGenerator
    {
        private readonly Random _random = new();

        public string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
