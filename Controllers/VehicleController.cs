using Microsoft.AspNetCore.Mvc;
using Model;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Text;
using System.Threading.Channels;
using System.Text.Json;
using System.Net;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private static List<Vehicle> Vehicles = new List<Vehicle>()
    {
        new Vehicle
        {
            VehicleId = 1,
            VehicleBrand = "Mercedes",
            VehicleRegNr = "VJ30535",
            MilesDriven = 100
        },
        new Vehicle
        {
            VehicleId = 2,
            VehicleBrand = "Audi",
            VehicleRegNr = "BK21211",
            MilesDriven = 35000
        }
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration _config;

    public VehicleController(ILogger<WeatherForecastController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }


    [HttpPost("addvehicle"), DisableRequestSizeLimit]
    public async Task<IActionResult> Post([FromBody] Vehicle? vehicle)
    {
        _logger.LogInformation("addVehicle funktion ramt");

        var newVehicle = new Vehicle // opretter det vehicle objekt der sendes fra Postman body input felt
        {
            VehicleId = vehicle.VehicleId,
            VehicleBrand = vehicle.VehicleBrand,
            VehicleRegNr = vehicle.VehicleRegNr,
            MilesDriven = vehicle.MilesDriven
        };
        _logger.LogInformation("nyt vehicle objekt lavet");


        if (newVehicle.VehicleId == 0)
        {
            return BadRequest("Invalid ID");
        }
        else
        {
            Vehicles.Add(newVehicle);
        }
        _logger.LogInformation("nyt vehicle objekt added til Vehicles list");


        return Ok(newVehicle);

    }


    [HttpGet("getallvehicles"), DisableRequestSizeLimit]
    public async Task<IActionResult> GetAllVehicles() //skal måske laves om til at returne en list (public list<vehicle> GetAllVehicles()
    {
        _logger.LogInformation("getAllVehicles funktion ramt");

        if (Vehicles == null)
        {
            return BadRequest("Vehicles list is empty");
        }


        return Ok(Vehicles.OrderBy(a => a.VehicleId));
    }


    [HttpGet("getvehicle/{id}"), DisableRequestSizeLimit]
    public async Task<IActionResult> GetVehicle(int id) //skal måske laves om til at returne en list (public list<vehicle> GetAllVehicles()
    {
        _logger.LogInformation("getVehicle funktion ramt");

        Vehicle vehicle = new Vehicle(); //initialiserer nyt vehicle objekt
        vehicle = Vehicles.FirstOrDefault(a => a.VehicleId == id)!; //sætter vehicle til matchende id

        _logger.LogInformation("ønsket vehicle objejt sat til vehicle objekt med id");


        return Ok(vehicle);
    }


}
