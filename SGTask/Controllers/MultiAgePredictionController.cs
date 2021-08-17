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
            //Was unable to parse the API Response to the correct data type so i am doing it in a messy way to reach a functional conclusion
            var namesSplit = response.Content.Split(new string[] { "{\"name\":\"" }, StringSplitOptions.None);

            List<AgePrediction> predictionList = new List<AgePrediction>();

            for (int i = 1; i < namesSplit.Length; i++)
            {
                var nameAgeSplit =  namesSplit[i].Split(new string[] { "\",\"age\":" }, StringSplitOptions.None);
                //Name is saved. the age and count are remaining.
                string name = nameAgeSplit[0];
                var agesSplit = nameAgeSplit[1].Split(new string[] { "," }, StringSplitOptions.None);
                var age = agesSplit[0];

                AgePrediction a = new AgePrediction { Name = name, Age = int.Parse(age) };
                predictionList.Add(a);
            }

            MultiAgePrediction prediction = new MultiAgePrediction();



            return prediction;
        }
    }
}
