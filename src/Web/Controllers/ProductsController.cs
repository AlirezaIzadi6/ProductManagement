using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Application.DTOs;
using Application.Features.Products.Create;
using Application.Features.Products.Delete;
using Application.Features.Products.get;
using Application.Features.Products.GetAll;
using Application.Features.Products.Update;
using Web.DTOs;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ProductDto>> Post(CreateProductDto createProductDto)
    {
        var command = _mapper.Map<CreateProductCommand>(createProductDto);
        string userId = GetRequestUserId(User)!;
        command.CreatedByUserId = userId;

        var response = await _mediator.Send(command);
        if (!response.Succeded)
        {
            return BadRequest(new
            {
                message = response.Message,
                errors = response.Errors
            });
        }

        return Ok(response.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var query = new GetProductByIdQuery(id);
        var response = await _mediator.Send(query);

        if (!response.Succeded) return NotFound();

        return Ok(response.Data);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] string? creator=null)
    {
        var query = new GetAllProductsQuery { CreatedByUserId=creator };
        var response = await _mediator.Send(query);

        return Ok(response.Data);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(UpdateProductDto updateProductDto, int id)
    {
        var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
        string userId = GetRequestUserId(User)!;
        command.RequestUserId = userId;

        if (command.Id != id) return BadRequest(new
            {
                message = "Invalid id parameter"
            });

        var response = await _mediator.Send(command);
        if (!response.Succeded)
        {
            return BadRequest(new
            {
                message = response.Message,
                errors = response.Errors
            });
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand { Id = id};
        string userId = GetRequestUserId(User)!;
        command.UserId = userId;

        var response = await _mediator.Send(command);

        if (!response.Succeded)
        {
            // Return not found wether product does not exist or the user does not have delete access.
            return NotFound();
        }

        return Ok();
    }

    private string? GetRequestUserId(ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
