using Cw4.Database;
using Cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = StaticDb.Animals;
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        Animal? animals = StaticDb.SelectAnimal(id);
        if (animals == null) return NotFound();

        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        var result = StaticDb.CreateAnimal(animal);
        if (!result) return BadRequest("Could not create new animal");

        return Created("", StaticDb.SelectAnimal(animal.Id));
    }

    // Bez ID w URI aby nie można było zmieniać ID zwierzęcia.
    [HttpPut]
    public IActionResult EditAnimal(Animal animal)
    {
        var result = StaticDb.UpdateAnimal(animal);
        if (!result) return BadRequest("No such animal");

        return Ok(StaticDb.SelectAnimal(animal.Id));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var result = StaticDb.DeleteAnimal(id);
        if (!result) return BadRequest("No such animal");

        return NoContent();
    }
}