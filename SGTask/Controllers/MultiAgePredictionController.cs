using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
    public class MultiAgePredictionController : ControllerBase
    {


        private readonly ILogger<MultiAgePredictionController> _logger;

        public MultiAgePredictionController(ILogger<MultiAgePredictionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{names}")]
        public MultiAgePrediction Get(string names)
        {
            var client = new RestClient("https://api.agify.io/");

            var nameList = names.Split(',');
            string requestString = "?";

            foreach (string name in nameList)
            {
                requestString += "name[]=" + name + "&"; // API Works with the extra ampersand. generally would remove the final one however functionality remains
            }

            var request = new RestRequest(requestString, Method.GET);

            RestResponse response = (RestResponse)client.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();
            var prediction = JsonConvert.DeserializeObject<MultiAgePrediction>(response.ToString());
            
            return prediction;
        }
    }
}
