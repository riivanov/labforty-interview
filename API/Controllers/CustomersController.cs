using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    APIDbContext _context;

    public CustomersController(APIDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var customers = _context.Customers.ToList();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        _context.Customers.Remove(customer);
        _context.SaveChanges();
        return NoContent();
    }
}
