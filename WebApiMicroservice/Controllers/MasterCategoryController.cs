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
    public class MasterCategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public MasterCategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region Category
        [HttpGet(Name = "Category")]
        public IActionResult Get()
        {
            var products = _categoryRepository.GetCategories();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var categories = _categoryRepository.GetCategoriesById(id);
            return new OkObjectResult(categories);
        }

        [HttpPost(Name = "InsertCategory")]
        public IActionResult Post([FromBody] Categories categories)
        {
            using (var scope = new TransactionScope())
            {
                _categoryRepository.InsertCategories(categories);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = categories.Id }, categories);
            }
        }

        [HttpPut(Name = "UpdateCategory")]
        public IActionResult Put([FromBody] Categories categories)
        {
            if (categories != null)
            {
                using (var scope = new TransactionScope())
                {
                    _categoryRepository.UpdateCategories(categories);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "DeletedCategory")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategories(id);
            return new OkResult();
        }

        #endregion
    }
}
