using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeRepository fuelTypeRepository;
        public FuelTypeController(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FuelTypeDto dto)
        {
            try
            {
                FuelType fuelType = new FuelType()
                {
                    Name = dto.Name,
                };
                return Ok(await fuelTypeRepository.Create(fuelType));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{fuelTypeID}")]
        public async Task<IActionResult> Delete(int fuelTypeID)
        {
            try
            {
                return Ok(await fuelTypeRepository.Delete(fuelTypeID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{fuelTypeID}")]
        public async Task<IActionResult> Get(int fuelTypeID)
        {
            try
            {
                return Ok(await fuelTypeRepository.Get(fuelTypeID));
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
                return Ok(await fuelTypeRepository.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{fuelTypeID}")]
        public async Task<IActionResult> Update(FuelTypeDto dto, int fuelTypeID)
        {
            try
            {
                FuelType fuelType = new FuelType()
                {
                    Name = dto.Name
                };
                return Ok(await fuelTypeRepository.Update(fuelType, fuelTypeID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
