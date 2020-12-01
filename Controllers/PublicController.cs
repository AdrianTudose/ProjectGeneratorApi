using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProjectGeneratorApi.Generators;
using ProjectGeneratorApi.Models.Component;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

using System.Xml.Linq;
using System;
using System.IO;
using System.Text;
using ProjectGeneratorApi.Models.Component;
using System.Collections.Generic;

namespace ProjectGeneratorApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet("PutFrontendComponent")]
        public IActionResult LatestProjects(string component)
        {
            Console.WriteLine("---");
            Console.WriteLine("string");
            Console.WriteLine(component);
            VueComponent deserializeComponent = JsonConvert.DeserializeObject<VueComponent>(component);
            Console.WriteLine("deserialized:");
            new ComponentGenerator(deserializeComponent, JsonConvert.SerializeObject(component));




            return Ok(component);
        }


    }
}
