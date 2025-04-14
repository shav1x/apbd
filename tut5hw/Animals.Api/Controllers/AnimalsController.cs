using Animals.Api.Contracts.Requests;
using Animals.Api.Data;
using Animals.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Api.Controllers;


[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private readonly List<Animal> _animals = AnimalsRepository.Animals;
    private readonly List<Visit> _visits = VisitsRepository.Visits;

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var animal = _animals.FirstOrDefault(x => x.id == id);
        if (animal is null)
            return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult Create(CreateAnimalRequest request)
    {
        var id = _animals.Max(x => x.id) + 1;
        var animal = new Animal { id = id, name = request.Name, category = request.Category, weight = request.Weight, furcolor = request.Furcolor};
        _animals.Add(animal);
        return CreatedAtAction(nameof(Get), new { id = id }, animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateAnimalRequest request)
    {
        var animal = _animals.FirstOrDefault(x => x.id == id);
        if (animal is null)
            return NotFound();
        animal.name = request.Name;
        animal.category = request.Category;
        animal.weight = request.Weight;
        animal.furcolor = request.Furcolor;
        return Ok(animal);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var animal = _animals.FirstOrDefault(x => x.id == id);
        if (animal is null)
            return NotFound();
        _animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id:int}/visits")]
    public IActionResult GetAllAnimalVisits(int id)
    {
        var visits = _visits.Where(x => x.animalId == id).ToList();
        return Ok(visits);
    }

    [HttpGet("{animalId:int}/visits/{visitId:int}")]
    public IActionResult GetAnimalVisit(int animalId, int visitId)
    {
        var visit = _visits.FirstOrDefault(x => x.animalId == animalId && x.id == visitId);
        if (visit is null)
            return NotFound();
        return Ok(visit);
    }
}
