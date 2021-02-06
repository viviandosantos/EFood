using EFood.Domain.Interfaces;
using EFood.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalogue.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IProductBc _productBc;

        public ProductsController(IProductRepository productRepository, IProductBc productBc)
        {
            _productRepository = productRepository;
            _productBc = productBc;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult Create([FromBody] Product product)
        {
            _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPost("categories/{categoryId}/discount")]
        public async Task<ActionResult> ApplyDiscountByCategory([FromRoute] long categoryId, [FromQuery] decimal percent) 
        {
            await _productBc.ReadjustPriceByCategory(categoryId, -percent);
            return Ok();
        }

        [HttpPost("categories/{categoryId}/increase")]
        public async Task<ActionResult> ApplyIncreaseByCategory([FromRoute] long categoryId, [FromQuery] decimal percent)
        {
            await _productBc.ReadjustPriceByCategory(categoryId, percent);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public ActionResult Edit([FromBody] Product product)
        {
            _productRepository.Edit(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Get([FromRoute] long id) 
        {
            var product = await _productRepository.Get(id);

            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }

        [HttpGet("categories/{categoryId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetByCategory([FromQuery] long categoryId)
        {
            var product = await _productRepository.GetByCategory(categoryId);

            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            return Ok(await _productRepository.Get());
        }

        [HttpGet("report")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> Report([FromQuery] DateTime? minDate, DateTime? maxDate) 
        {
            return Ok(await _productRepository.GenerateReport(minDate, maxDate));
        }
    }
}
