using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.Repositroy
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProduct();
        Products GetProductById(int Id);
        void InsertProduct(Products data);
        void UpdateProduct(Products data);
        void DeleteProduct(int Id);
        void Save();
    }
}
