using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        public VehicleTypeController(IVehicleTypeRepository vehicleTypeRepository)
        {
            this.vehicleTypeRepository = vehicleTypeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleTypeDto dto)
        {
            try
            {
                VehicleType vehicleType = new VehicleType()
                {
                    Name = dto.Name,
                };
                return Ok(await vehicleTypeRepository.Create(vehicleType));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{vehicleTypeID}")]
        public async Task<IActionResult> Delete(int vehicleTypeID)
        {
            try
            {
                return Ok(await vehicleTypeRepository.Delete(vehicleTypeID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{vehicleTypeID}")]
        public async Task<IActionResult> Get(int vehicleTypeID)
        {
            try
            {
                return Ok(await vehicleTypeRepository.Get(vehicleTypeID));
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
                return Ok(await vehicleTypeRepository.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{vehicleTypeID}")]
        public async Task<IActionResult> Update(VehicleTypeDto dto, int vehicleTypeID)
        {
            try
            {
                VehicleType vehicleType = new VehicleType()
                {
                    Name = dto.Name,
                };
                return Ok(await vehicleTypeRepository.Update(vehicleType, vehicleTypeID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
