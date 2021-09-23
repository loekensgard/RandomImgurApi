using Microsoft.AspNetCore.Mvc;
using RandomImgurApi.Services;
using System.Threading.Tasks;

namespace RandomImgurApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImgurController : ControllerBase
    {
        private readonly ImgurService _imgurService;

        public ImgurController(ImgurService imgurService)
        {
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
