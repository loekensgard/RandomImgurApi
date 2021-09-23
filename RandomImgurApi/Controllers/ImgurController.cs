using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomImgurApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RandomImgurApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImgurController : ControllerBase
    {

        private readonly ILogger<ImgurController> _logger;
        private readonly ImgurService _imgurService;

        public ImgurController(ILogger<ImgurController> logger, ImgurService imgurService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _imgurService = imgurService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _imgurService.GetImage());
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetImage()
        {
            var imagedata = await _imgurService.GetImage();

            if (!imagedata.Success)
                return NotFound();

            return Redirect(imagedata.Data.Link.ToString());
        }
    }
}
