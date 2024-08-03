using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult AddImages([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(file, carImage);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAllImages()
        {
            var result = _carImageService.GetAllCarImage();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetCarImageByCarId(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetImageByID(int Id)
        {
            var result = _carImageService.GetCarImageById(Id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult UpdateImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(file, carImage);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteImage(CarImage carImage)
        {
            var carDeleteImage = _carImageService.GetCarImageById(carImage.Id).Data;

            var result = _carImageService.DeleteCarImage(carDeleteImage);

            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
