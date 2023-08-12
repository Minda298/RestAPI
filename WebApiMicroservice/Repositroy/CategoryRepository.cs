using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.DBContexts;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.Repositroy
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;

        public CategoryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCategories(int Id)
        {
            var categories = _dbContext.Categories.Find(Id);
            _dbContext.Categories.Remove(categories);
            Save();
        }

        public IEnumerable<Categories> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Categories GetCategoriesById(int Id)
        {
            return _dbContext.Categories.FirstOrDefault(x => x.Id == Id);
        }

        public void InsertCategories(Categories data)
        {
            _dbContext.Add(data);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCategories(Categories data)
        {
            _dbContext.Entry(data).State = EntityState.Modified;
            Save();
        }
    }
}
