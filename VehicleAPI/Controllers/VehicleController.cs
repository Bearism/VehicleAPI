using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Services;
using AutoMapper;

namespace VehicleAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleServices _vehicleService;
    private readonly IMapper _mapper;

    public VehicleController (IVehicleServices vehicleService, IMapper mapper)
    {
        _vehicleService = vehicleService;
        _mapper = mapper;
    }

    [HttpGet("cars")]
    public IActionResult GetCars([FromQuery] string Color, [FromQuery] int Wheels)
    {
        var cars = _vehicleService.GetCarsByColorAndWheels (Color, Wheels);
        return Ok(cars);
    }

    [HttpGet("boats")]
    public IActionResult GetBoats([FromQuery] string Color)
    {
        var boats = _vehicleService.GetBoatsByColor(Color);
        return Ok(boats);
    }

    [HttpGet("buses")]
    public IActionResult GetBuses([FromQuery] string Color)
    {
        var buses = _vehicleService.GetBusesByColor(Color);
        return Ok(buses);
    }

    [HttpPost("cars/{id}/headlights")]
    public IActionResult UpdateHeadlights(int id)
    {
        _vehicleService.UpdateCarHeadlights(id);
        return Ok();
    }
    [HttpPost("boats")]
    public async Task<IActionResult> AddBoatAsync([FromQuery]BoatDTO boat)
    { 
        Boat boat1 = _mapper.Map<Boat>(boat);
        await _vehicleService.AddBoat(boat1);
        return CreatedAtAction(nameof(GetBoats), new { id = boat1.Id }, boat1);
    }


    [HttpDelete("cars/{id}")]
    public IActionResult DeleteCar(int id)
    {
        _vehicleService.DeleteCar(id);
        return Ok();
    }

}
