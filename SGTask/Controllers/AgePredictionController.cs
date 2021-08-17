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

        [HttpGet ("{name}")]
        public AgePrediction Get(string name)
        {
            var client = new RestClient("https://api.agify.io/");

            var request = new RestRequest("?name=" + name, Method.GET);
            
            RestResponse response = (RestResponse)client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();

            AgePrediction prediction = deserial.Deserialize<AgePrediction>(response);
            return prediction;
        }
    }
}
