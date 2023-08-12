using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WebApiMicroservice.Models;
using WebApiMicroservice.Repositroy;

namespace WebApiMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public MasterProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region Product
        [HttpGet(Name ="Product")]
        public IActionResult Get()
        {
            var products = _productRepository.GetProduct();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new OkObjectResult(product);
        }

        [HttpPost(Name ="InsertProduct")]
        public IActionResult Post([FromBody] Products product)
        {
            using (var scope = new TransactionScope())
            {
                _productRepository.InsertProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
        }

        [HttpPut(Name ="UpdateProduct")]
        public IActionResult Put([FromBody] Products product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}", Name ="DeletedProduct")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }

        #endregion
    }
}
