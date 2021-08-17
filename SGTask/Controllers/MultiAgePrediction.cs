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
    public class MutliAgePredictionController : ControllerBase
    {


        private readonly ILogger<MutliAgePredictionController> _logger;

        public MutliAgePredictionController(ILogger<MutliAgePredictionController> logger)
        {
            _logger = logger;
        }

        [HttpGet ("{names}")]
        public MutliAgePredictionController Get(string names)
        {
            var client = new RestClient("https://api.agify.io/");

            var request = new RestRequest("?name=" + name, Method.GET);
            
            RestResponse response = (RestResponse)client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();

            MutliAgePredictionController prediction = deserial.Deserialize<MutliAgePredictionController>(response);
            return prediction;
        }
    }
}
