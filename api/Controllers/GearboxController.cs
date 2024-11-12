using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearboxController : ControllerBase
    {
        private readonly IGearboxRepository gearboxRepository;
        public GearboxController(IGearboxRepository gearboxRepository)
        {
            this.gearboxRepository = gearboxRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GearboxDto dto)
        {
            try
            {
                Gearbox gearbox = new Gearbox()
                {
                    Type = dto.Type,
                    Speeds = dto.Speeds,
                };
                return Ok(await gearboxRepository.Create(gearbox));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{gearboxID}")]
        public async Task<IActionResult> Delete(int gearboxID)
        {
            try
            {
                return Ok(await gearboxRepository.Delete(gearboxID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{gearboxID}")]
        public async Task<IActionResult> Get(int gearboxID)
        {
            try
            {
                return Ok(await gearboxRepository.Get(gearboxID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await gearboxRepository.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{gearboxID}")]
        public async Task<IActionResult> Update(GearboxDto dto, int gearboxID)
        {
            try
            {
                Gearbox gearbox = new Gearbox()
                {
                    Type = dto.Type,
                    Speeds = dto.Speeds,
                };
                return Ok(await gearboxRepository.Update(gearbox,gearboxID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
