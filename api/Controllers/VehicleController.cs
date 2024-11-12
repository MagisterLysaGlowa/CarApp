using api.Dto;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleDto dto)
        {
            try
            {
                Vehicle vehicle = new Vehicle()
                {
                    Model = dto.Model,
                    Year = dto.Year,
                    Color = dto.Color,
                    GearboxID = dto.GearboxID,
                    Mileage = dto.Mileage,
                    EngineID = dto.EngineID,
                    SeatingCapacity = dto.SeatingCapacity,
                    BodyType = dto.BodyType,
                    VIN = dto.VIN,
                    Price = dto.Price,
                    VehicleTypeID = dto.VehicleTypeID,
                };
                return Ok(await vehicleRepository.Create(vehicle));
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{vehicleID}")]
        public async Task<IActionResult> Delete(int vehicleID)
        {
            try
            {
                return Ok(await vehicleRepository.Delete(vehicleID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{vehicleID}")]
        public async Task<IActionResult> Get(int vehicleID)
        {
            try
            {
                return Ok(await vehicleRepository.Get(vehicleID));
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
                return Ok(await vehicleRepository.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{vehicleID}")]
        public async Task<IActionResult> Update(VehicleDto dto,int vehicleID)
        {
            try
            {
                Vehicle vehicle = new Vehicle()
                {
                    Model = dto.Model,
                    Year = dto.Year,
                    Color = dto.Color,
                    GearboxID = dto.GearboxID,
                    Mileage = dto.Mileage,
                    EngineID = dto.EngineID,
                    SeatingCapacity = dto.SeatingCapacity,
                    BodyType = dto.BodyType,
                    VIN = dto.VIN,
                    Price = dto.Price,
                    VehicleTypeID = dto.VehicleTypeID
                };
                return Ok(await vehicleRepository.Update(vehicle, vehicleID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
