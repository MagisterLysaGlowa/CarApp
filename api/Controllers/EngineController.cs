using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineRepository engineRepository;
        public EngineController(IEngineRepository engineRepository)
        {
            this.engineRepository = engineRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EngineDto dto)
        {
            try
            {
                Engine engine = new Engine()
                {

                    Capacity = dto.Capacity,
                    Horsepower = dto.Horsepower,
                    Torque = dto.Torque,
                    Cylinders = dto.Cylinders,
                    FuelTypeID = dto.FuelTypeID
                };
                return Ok(await engineRepository.Create(engine));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{engineID}")]
        public async Task<IActionResult> Delete(int engineID)
        {
            try
            {
                return Ok(await engineRepository.Delete(engineID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{engineID}")]
        public async Task<IActionResult> Get(int engineID)
        {
            try
            {
                return Ok(await engineRepository.Get(engineID));
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
                return Ok(await engineRepository.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{engineID}")]
        public async Task<IActionResult> Update(EngineDto dto, int engineID)
        {
            try
            {
                Engine engine = new Engine()
                {

                    Capacity = dto.Capacity,
                    Horsepower = dto.Horsepower,
                    Torque = dto.Torque,
                    Cylinders = dto.Cylinders,
                    FuelTypeID = dto.FuelTypeID
                };
                return Ok(await engineRepository.Update(engine, engineID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
