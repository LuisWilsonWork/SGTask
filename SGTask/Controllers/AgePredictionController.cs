using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgePredictionController : ControllerBase
    {
        

        private readonly ILogger<AgePredictionController> _logger;

        public AgePredictionController(ILogger<AgePredictionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public AgePrediction Get()
        {
            return new AgePrediction
            {
                Name = "Luis",
                Age = 26
                
            };




        }
    }
}
