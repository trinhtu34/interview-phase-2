using Application.DTOs;
using Application.Feature.Customer.Commands;
using Application.Feature.Customer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDTO>>> GetCustomers()
    {
        var customers = await _mediator.Send(new GetListCustomerQuery());
        return Ok(customers);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] CreateCustomerDTO dto)
    {
        var command = new CreateCustomerCommand(dto.FullName, dto.BirthDay, dto.Email, dto.PhoneNumber, dto.Address);

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCustomers), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int id, [FromBody] UpdateCustomerDTO dto)
    {
        var command = new UpdateCustomerCommand(id, dto.FullName, dto.BirthDay, dto.Email, dto.PhoneNumber, dto.Address);

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        var command = new DeleteCustomerCommand(id);
        var result = await _mediator.Send(command);
        
        if (!result)
            return NotFound();
            
        return NoContent();
    }
}