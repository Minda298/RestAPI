using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.DBContexts;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.Repositroy
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int Id)
        {
            var product = _dbContext.Products.Find(Id);
            _dbContext.Products.Remove(product);
            Save();
        }

        public IEnumerable<Products> GetProduct()
        {
            return _dbContext.Products.ToList();
        }

        public Products GetProductById(int Id)
        {
            return _dbContext.Products.FirstOrDefault(x=>x.Id == Id);
        }

        public void InsertProduct(Products data)
        {
            _dbContext.Add(data);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Products data)
        {
            _dbContext.Entry(data).State = EntityState.Modified;
            Save();
        }
    }
}
