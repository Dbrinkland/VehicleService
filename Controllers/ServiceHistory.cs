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
using Microsoft.Extensions.DependencyInjection;
using Controllers;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceHistoryController : ControllerBase
{
    public List<ServiceHistory> ServiceHistory = new List<ServiceHistory>()
    {
        new ServiceHistory
        {
            ServiceReferenceId = 1,
            ServiceDate = new DateTime(2020, 1, 12, 13, 45, 50),
            ServiceDescription = "Første 3-måneders service",
            ServiceWorkerName = "Juan"
        },
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration _config;

    public ServiceHistoryController(ILogger<WeatherForecastController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }


    [HttpPost("ServiceHistory"), DisableRequestSizeLimit]
    public async Task<IActionResult> Post([FromBody] ServiceHistory? serviceHistory)
    {
        _logger.LogInformation("Tilføj service historik til specifikt køretøj");

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
            ServiceHistory.Add(newServiceHistory);
        }

        _logger.LogInformation("Ny service historik tilføjet.");

        return Ok(serviceHistory);

    }


}

