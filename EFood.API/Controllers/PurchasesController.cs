using EFood.Domain.Exceptions;
using EFood.Domain.Interfaces;
using EFood.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Http;
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
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseBc _purchaseBc;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchasesController(IPurchaseBc purchaseBc, IPurchaseRepository purchaseRepository)
        {
            _purchaseBc = purchaseBc;
            _purchaseRepository = purchaseRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Create([FromBody] Purchase purchase)
        {
            try
            {
                await _purchaseBc.Create(purchase);
                return CreatedAtRoute("GetPurchase", new { id = purchase.Id }, purchase);
            }
            catch (ProductNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (PurchaseItemsNotInformedException e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Purchase>>> Get()
        {
            return Ok(await _purchaseRepository.Get());
        }

        [HttpGet("{id}", Name = "GetPurchase")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Purchase), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Purchase>> Get([FromRoute] long id)
        {
            var product = await _purchaseRepository.Get(id);

            if (product != null)
                return Ok(product);
            else
                return NotFound();
        }
    }
}
