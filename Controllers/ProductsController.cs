using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureDemo.Application.Features.Products.Commands;
using CleanArchitectureDemo.Application.Features.Products.Queries;

namespace CleanArchitectureDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            return Ok();
        }
    }
}