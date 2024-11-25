using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenAIServer.Infrastructures;
using OpenAIServer.Interfaces;

namespace OpenAIServer.Controllers
{
    [EnableCors("AllowAll")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageAIController : ControllerBase
    {
        private readonly ILogger<ImageAIController> logger;
        private readonly IImageAIRepository imageAIRepository;

        public ImageAIController(ILogger<ImageAIController> logger, IImageAIRepository imageAIRepository)
        {
            this.logger = logger;
            this.imageAIRepository = imageAIRepository;
        }

        [HttpGet("weapons-image/{weaponsModel}", Name = "GetWeaponsImageUrl")]
        public async Task<ActionResult<string>> GetWeaponsImageUrl([FromRoute] string weaponsModel)
        {
            string name = weaponsModel.ToLower();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ImageAIException("name is to short or ", "null");
            }

            return await imageAIRepository.getUrl($"weapons {weaponsModel}");
            //return "https://weaponsimages.blob.core.windows.net/images-service/logo_ukraine-armed-forces.png";
        }
    }
}
