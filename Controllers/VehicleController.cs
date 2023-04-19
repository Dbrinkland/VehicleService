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
    public List<Vehicle> Vehicles = new List<Vehicle>()
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

        return Ok(vehicle);

    }


    [HttpPost("servicehistory/{id}"), DisableRequestSizeLimit]
    public async Task<IActionResult> Post([FromBody] ServiceHistory? serviceHistory, int id)
    {
        _logger.LogInformation("Tilføj service historik til specifikt køretøj");

        var vehicle = Vehicles.FirstOrDefault(a => a.VehicleId == id);

        var newServiceHistory = new ServiceHistory //Opretter specifik service historik til gældende køretøj
        {

            ServiceReferenceId = serviceHistory.ServiceReferenceId,
            ServiceDate = serviceHistory.ServiceDate,
            ServiceDescription = serviceHistory.ServiceDescription,
            ServiceWorkerName = serviceHistory.ServiceWorkerName

        };

        _logger.LogInformation("Ny service kontrakt oprettet på den pågældende bil.");

        if (newServiceHistory.ServiceReferenceId == 0)
        {
            return BadRequest("Invalid ID (Not Null).");
        }
        else
        {
            //ServiceHistory.Add(newServiceHistory);
            vehicle.ServiceHistory.Add(newServiceHistory);
        }

        _logger.LogInformation("Ny service historik tilføjet.");

        return Ok(serviceHistory);

    }
}