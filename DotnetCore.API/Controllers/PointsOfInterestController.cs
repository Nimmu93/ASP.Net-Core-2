using DotnetCore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Controllers
{
    [Route("api/WithModel")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{NameId}/pointofinterest")]
        public IActionResult GetPointOfInterest(int NameId)
        {
            try
            {
                throw new Exception("Exception sample");
                var Name = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == NameId);
                if (Name == null)
                {
                    _logger.LogInformation($"Name with id{NameId} wasn't found when accessing points of interest.");
                    return NotFound();
                }
                return Ok(Name.PointOfInterest);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {NameId}.", ex);
                return StatusCode(500, "A problem happned while handling your request.");
            }
           
        }
        [HttpGet("{NameId}/pointofinterest/{id}")]
        public IActionResult GetPointOfInterest(int NameId, int id)
        {
            var Name = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == NameId);
            if (Name == null)
            {
                return NotFound();
            }
            var pointOfInterest = Name.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if (Name == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
        [HttpPost("{NameId}/pointofinterest",Name ="GetPointOfInterest")]
        //name is declared to give a reference to createat route helper method.
        public IActionResult CreatePointOfInterest(int NameId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            //restrict entering the same description
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }
            //ModelState library contains state of the model and model binding validation
            if (!ModelState.IsValid)
            {
                //return the modelState to get the customized error masgs
                return BadRequest(ModelState);
            }
            var Name = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == NameId);
            if (Name ==null)
            {
                return NotFound();
            }
            //mapping
            var maxPointOfInterestId = NamesDataStore.Current.Names.SelectMany(c => c.PointOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            Name.PointOfInterest.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest",new { NameId = NameId, id = finalPointOfInterest.Id },finalPointOfInterest);
        }
        
        //full update
        [HttpPut("{NameId}/pointofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int NameId,int id, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            //restrict entering the same description
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }
            //ModelState library contains state of the model and model binding validation
            if (!ModelState.IsValid)
            {
                //return the modelState to get the customized error masgs
                return BadRequest(ModelState);
            }
            var Name = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == NameId);
            if (Name == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = Name.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }


        //Partial update
        [HttpPatch("{NameId}/pointofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int NameId,int id, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var Name = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == NameId);
            if (Name == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = Name.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };
            patchDoc.ApplyTo(pointOfInterestToPatch,ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(pointOfInterestToPatch);

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }

        //Delete
        [HttpDelete("{NameId}/pointofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int NameId,int id)
        {
            var Name = NamesDataStore.Current.Names.FirstOrDefault(c => c.Id == NameId);
            if (Name == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = Name.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            Name.PointOfInterest.Remove(pointOfInterestFromStore);

            return NoContent();
        }
    }
}
