using AutoMapper;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
        {
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public PictureController(IPictureService pictureService, IMapper mapper)
        {
            _pictureService = pictureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPicturesAsync()
        {
            var pictures = await _pictureService.GetPicturesAsync();
            return Ok(_mapper.Map<IEnumerable<PictureDTO>>(pictures));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPicturesByIdAsync(int id)
        {
            var picture = await _pictureService.GetPicturesByIdAsync(id);
            return Ok(_mapper.Map<PictureDTO>(picture));
        }

        [HttpPost]
        public async Task<IActionResult> AddPicturesAsync([FromBody] PictureRegistrationDTO pictureDto)
        {
            await _pictureService.AddPicturesAsync(pictureDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicturesAsync(int id)
        {
            await _pictureService.DeletePicturesAsync(id);
            return Ok();
        }
    }

}
