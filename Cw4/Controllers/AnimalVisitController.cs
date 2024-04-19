using System.Runtime.CompilerServices;

namespace Tutorial4.Controllers;

using Cw4.Database;
using Cw4.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/[controller]")]
public class AnimalVisitController : ControllerBase
{
    [HttpGet("{animalId:int}")]
    public IActionResult GetAnimalVisits(int animalId)
    {
        var list = StaticDb.AnimalVisits.Where(x => x.animal.Id == animalId).ToList();
        return Ok(list);
    }
    
    [HttpPost]
    public IActionResult CreateAnimalVisit(NewAnimalVisit newVisit)
    {
        var animal = StaticDb.SelectAnimal(newVisit.animalId);
        if (animal == null)
        {
            return BadRequest("Animal does not exist");
        }

        var visit = new AnimalVisit()
        {
            animal = animal,
            visitCost = newVisit.visitCost,
            visitDate = newVisit.visitDate,
            visitDescription = newVisit.visitDescription
        };
        StaticDb.AnimalVisits.Add(visit);
        return Ok(visit);
    }
}