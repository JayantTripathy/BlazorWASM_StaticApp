using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using BlazorWASM_StaticApp.Models;
using System.Net.Http;
using System.Net;
using System.Text;

namespace BlazorWASM_FunctionApp
{
    public class Function1
    {
   
        [FunctionName("GetCricketers")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                var jsondata = File.ReadAllText("cricketers.json");

                var result = JsonConvert.DeserializeObject<List<Cricketer>>(jsondata);

                var json = JsonConvert.SerializeObject(result, Formatting.Indented);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

