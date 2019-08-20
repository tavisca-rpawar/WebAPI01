using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "No input";
        }

        [HttpGet("{greet}/{name}")]
        public ActionResult<string> Get(string greet, string name)
        {
            return greet == "Hello" ? $"Hi {name}" : "No hi";
        }

    }
}