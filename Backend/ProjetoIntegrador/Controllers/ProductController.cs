using Microsoft.AspNetCore.Mvc;
using Source.Dtos;
using Source.Entities;
using Source.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : Controller
    {
        /// <summary>
        ///     Insert or Update Product
        /// </summary>
        /// <returns>Response Data</returns>
        /// <response code="204">The request was accepted.</response>
        /// <response code="400">The request was unsuccessful.</response>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrUpdate([FromBody] ProductRequestDto request)
        {
            try
            {
                await productService.CreateOrUpdateAsync(request);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///     Delete Product
        /// </summary>
        /// <returns>Response Data</returns>
        /// <response code="204">The request was accepted.</response>
        /// <response code="400">The request was unsuccessful.</response>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await productService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///     Get All Products
        /// </summary>
        /// <returns>Response Data</returns>
        /// <response code="200">The request was accepted.</response>
        /// <response code="400">The request was unsuccessful.</response>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<Product>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await productService.GetAllProducts());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
