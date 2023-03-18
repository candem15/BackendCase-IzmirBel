using Application.Dtos.Product;
using Application.Features.Commands.Product.CreateProduct;
using Application.Features.Commands.Product.SoftDeleteProduct;
using Application.Features.Commands.Product.UpdateProduct;
using Application.Features.Queries.Product.GetAllProducts;
using Application.Features.Queries.Product.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllProductsQueryRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetById/{Id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetProductByIdQueryRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }


        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] SoftDeleteProductCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

    }
}
