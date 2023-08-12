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
    public class MasterCashierController : Controller
    {
        private readonly ICashierRepository _cashierRepository;

        public MasterCashierController(ICashierRepository cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }

        #region Cashier
        [HttpGet(Name = "Cashier")]
        public IActionResult Get()
        {
            var products = _cashierRepository.GetCashier();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "GetCashier")]
        public IActionResult Get(int id)
        {
            var categories = _cashierRepository.GetCashierById(id);
            return new OkObjectResult(categories);
        }

        [HttpPost(Name = "InsertCashier")]
        public IActionResult Post([FromBody] Cashier cashier)
        {
            using (var scope = new TransactionScope())
            {
                _cashierRepository.InsertCashier(cashier);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = cashier.Id }, cashier);
            }
        }

        [HttpPut(Name = "UpdateCashier")]
        public IActionResult Put([FromBody] Cashier cashier)
        {
            if (cashier != null)
            {
                using (var scope = new TransactionScope())
                {
                    _cashierRepository.UpdateCashier(cashier);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "DeletedCashier")]
        public IActionResult Delete(int id)
        {
            _cashierRepository.DeleteCashier(id);
            return new OkResult();
        }

        #endregion
    }
}
