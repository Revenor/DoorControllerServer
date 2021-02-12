using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace DoorServer.Controllers
{
    [ApiController]
    public class DoorController : ControllerBase
    {
        
        private readonly ILogger<DoorController> _logger;

        public DoorController(ILogger<DoorController> logger)
        {
            _logger = logger;
        }
        
        [Route("api/user/{uname}/OpenDoor")]
        [HttpPost]
        public IActionResult Post(string uname, string type)
        {
            using var db = new Db();

            if (string.IsNullOrEmpty(type))
            {
                if (Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4() is var ipv4 != null)
                {
                    _logger.Log(LogLevel.Error, $"{ipv4} | {uname} tried to open the door with an invalid device");
                }
                //else
              //  {
              //      _logger.Log(LogLevel.Error, $"{Request.HttpContext.Connection.RemoteIpAddress} | {uname} tried to open the door with an invalid device");
               // }
                return BadRequest("Type cannot be Null Or Empty");
            }

            EntityEntry<DoorOpensCollection> number = db.Ints.Add(new DoorOpensCollection()
            {
                DateTimeOfOpening = DateTime.Now,
                Type = type,
                NameOfUser = uname 
            });

            db.SaveChanges();
            
            return Ok(number.Entity);
        }
        
        
        [Route("api/GetDoorOpens")]
        [HttpGet]
        public async Task<List<DoorOpensCollection>> Get()
        {
            await using var db = new Db();

            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem

            List<DoorOpensCollection> ints = db.Ints.AsEnumerable().ToList();
            
            return ints;
        }
    }
}
