using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Controllers
{
    [Route("api/IActionResult")]
    public class IActionResultController :Controller
    {
        [HttpGet()]
        public IActionResult GetNames()
        {
            var temp = new JsonResult(NamesDataStore.Current.Names);
            temp.StatusCode = 200;
            return temp;
        }
        [HttpGet("{id}")]
        public IActionResult GetName(int id)
        {
            var NameToReturn = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == id);
            if (NameToReturn == null)
            {
                return NotFound();
            }
            return Ok(NameToReturn);
        }
    }
}
