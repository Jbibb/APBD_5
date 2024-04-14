using APBD_5.Classes;
using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Controllers;

[ApiController]
[Route("animals")]
public class AnimalController : ControllerBase
{
    private IMockDatabase _mockDatabase;

    public AnimalController(IMockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        
        return Ok(_mockDatabase.GetAllAnimals());
    }

    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        var animal = _mockDatabase.GetAnimalDetails(id);
        if (animal is null)
            return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        _mockDatabase.AddAnimal(animal);
        return Created($"animals/{animal.Id}", animal);
    }

    [HttpPut("{id}")]
    public IActionResult Replace(int id, Animal animal)
    {
        _mockDatabase.RemoveAnimal(id);
        _mockDatabase.AddAnimal(animal);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        var result = _mockDatabase.RemoveAnimal(id);
        if (result is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}