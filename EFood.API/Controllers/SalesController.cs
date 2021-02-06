using EFood.Domain.Exceptions;
using EFood.Domain.Interfaces;
using EFood.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EFood.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleBc _saleBc;

        public SalesController(ISaleRepository saleRepository, ISaleBc saleBc)
        {
            _saleRepository = saleRepository;
            _saleBc = saleBc;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] Sale sale)
        {
            try
            {
                await _saleBc.Create(sale);
                return CreatedAtRoute("GetSale", new { id = sale.Id }, sale);
            }
            catch (ProductNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (ProductQuantityUnavailableException e) 
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}", Name = "GetSale")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Sale>> Get([FromRoute] long id)
        {
            var sale = await _saleRepository.Get(id);

            if (sale != null)
                return Ok(sale);
            else
                return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Sale>>> Get()
        {
            return Ok(await _saleRepository.Get());
        }

    }
}
