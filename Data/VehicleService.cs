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

/* Begyndelse på DB context -> Nedenstående sørger for at ServiceReferenceId refererer til VehicleId

namespace DbContext

var context = new DbContext()
{
    var vehicle = context.Vehicle.Include(b => b.ServiceHistory).FirstOrDefault(b => b.Id == 1);

};

*/

