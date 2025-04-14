using Animals.Api.Contracts.Requests;
using Animals.Api.Data;
using Animals.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Api.Controllers;

[ApiController]
[Route("api/visits")]
public class VisitsController : ControllerBase
{
    private readonly List<Animal> _animals = AnimalsRepository.Animals;
    private readonly List<Visit> _visits = VisitsRepository.Visits;
    
    [HttpGet]
    public IActionResult GetAllVisits()
    {
        return Ok(_visits);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var visit = _visits.FirstOrDefault(x => x.id == id);
        if (visit is null)
            return NotFound();
        return Ok(visit);
    }

    [HttpPost]
    public IActionResult Create(CreateVisitRequest request)
    {
        var id = _visits.Max(x => x.id) + 1;
        if (_animals.FirstOrDefault(x => x.id == request.AnimalId) is null)
            return NotFound();
        var visit = new Visit { id = id, animalId = request.AnimalId, date = request.Date, description = request.Description, price = request.Price };
        _visits.Add(visit);
        return CreatedAtAction(nameof(Get), new { id = id }, visit);
    }
}
