using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Controllers
{
    [Route("api/Names")]
    public class NamesController: Controller
    {
        //[HttpGet("api/Names")]
        public JsonResult GetNames()
        {
            return new JsonResult(new List<object>()
            {
                new {id=1, Name="Mike"},
                new {id=2, Name="Tom"}
            });
        }
    }
}
