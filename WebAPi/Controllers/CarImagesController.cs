using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImagesService.GetAllByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add( [FromForm] Image image ,[FromForm] CarImage carImages)
        {
            var result = _carImagesService.Add(image,carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carImagesService.Delete(new CarImage {Id=id });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update( CarImage carImages)
        {
            var result = _carImagesService.Update(carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
