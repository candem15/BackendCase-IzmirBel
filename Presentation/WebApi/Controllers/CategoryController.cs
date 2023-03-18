using Application.Dtos.Category;
using Application.Features.Commands.Category.CreateCategory;
using Application.Features.Commands.Category.SoftDeleteCategory;
using Application.Features.Commands.Category.UpdateCategory;
using Application.Features.Queries.Category.GetAllCategories;
using Application.Features.Queries.Category.GetCategoryById;
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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllCategoriesQueryRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetById/{Id}")]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetCategoryByIdQueryRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }


        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] SoftDeleteCategoryCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

    }
}
