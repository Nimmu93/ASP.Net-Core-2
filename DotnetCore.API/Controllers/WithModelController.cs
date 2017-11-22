using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Controllers
{
    [Route("api/WithModel")]
    public class WithModelController : Controller
    {
        //[HttpGet("api/Names")]
        public JsonResult GetNames()
        {
            return new JsonResult(NamesDataStore.Current.Names);
        }
        [HttpGet("{id}")]
        public JsonResult GetName(int id)
        {
            return new JsonResult(
                NamesDataStore.Current.Names.FirstOrDefault(c=> c.Id ==id)
                );
        }
    }

}