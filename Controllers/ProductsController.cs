using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.NetCore.DTO;
using Akka.NetCore.Messages;
using Akka.NetCore.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Akka.NetCore.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IActorRef productsManagerActor;

        public ProductsController(ProductsManagerActorProvider productsManagerActor)
        {
            this.productsManagerActor = productsManagerActor();
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> Get()
        {
            var books = await productsManagerActor.Ask<IEnumerable<ProductDTO>>(GetProducts.Instance);
            return Ok(books);
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await productsManagerActor.Ask(new GetProductById(id));

            switch (result)
            {
                case ProductDTO product:
                    return Ok(product);
                default:
                    return NotFound();
            }
        }

        [HttpPost]
        [Route("api/products")]
        public IActionResult Post([FromBody] CreateProduct command)
        {
            productsManagerActor.Tell(command);
            return Accepted();
        }
    }
}