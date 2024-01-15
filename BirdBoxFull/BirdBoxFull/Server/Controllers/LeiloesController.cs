using BirdBoxFull.Server.Services.ServicoProduto;
using BirdBoxFull.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdBoxFull.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeiloesController : ControllerBase
    {
        public IServicoProduto _productService;
        public LeiloesController(IServicoProduto productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Leilao>>> GetLeiloes()
        {
            return Ok(await _productService.GetAllLeiloes());
        }

        [HttpGet("{codLeilao}")]
        public async Task<ActionResult<Leilao>> GetLeilao(string codLeilao)
        {
            return Ok(await _productService.GetLeilao(codLeilao));
        }

        [HttpPost("upload/image")] // Updated route
        public async Task<ActionResult> UploadImages(List<LeilaoImage> images)
        {
            try
            {
                // Process the request and save the images to the database using the ProductService
                await _productService.UploadImages(images);

                return Ok("Images uploaded successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


    }
}
